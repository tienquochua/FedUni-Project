using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ITAsset
{
    public partial class assetFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable assetTable;
        int curRow;
        
        public static string ID = "";
        public static string ItemName = "";
        public static string PurDate = "";
        public static string Vendor = "";
        public static string PurLoc = "";
        public static string Status = "";
        public static string LeaseAgree = "";
        public assetFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Color.FromArgb(30, 144, 255);
                    btn.ForeColor = Color.White;
                }
            }
        }
        private void GetDataInformation()
        {
            assetTable = objDTB.ReadData("SELECT av.AssetID AS 'Item No.', av.AssetName AS 'Item', av.PurchaseDate AS 'Purchase Date', v.VendorName AS 'Vendor', av.PurchaseLocation AS 'Purchase Location', av.Status, av.LeaseAgreement AS 'Lease Agreement', av.LastUpdate AS 'Last Update', u.FullName AS 'Responsible Staff', u.Email " +
               "FROM [AssetView] av " +
               "INNER JOIN [Vendor] v ON av.VendorID= v.VendorID " +
               "INNER JOIN [User] u ON av.UserID = u.UserID " +
               "WHERE av.Archive = 0");
            dataGridView1.DataSource = assetTable;
            dataGridView1.ClearSelection();
        }
        private void SendToArchive()
        {
            DialogResult res = MessageBox.Show("Do you want to send this item to Archive ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [AssetView] SET Archive = 1  WHERE AssetID=@id", conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ID));
                cmd.ExecuteReader();
                conn.Close();
                GetDataInformation();
                ID = "";
            }
        }
        private void assetFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetDataInformation();
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            searchCbb.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                curRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[curRow];
                ID = row.Cells[0].Value.ToString();
                ItemName = row.Cells[1].Value.ToString();
                PurDate = row.Cells[2].Value.ToString();
                Vendor = row.Cells[3].Value.ToString();
                PurLoc = row.Cells[4].Value.ToString();
                Status = row.Cells[5].Value.ToString();
                LeaseAgree = row.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
            assetRegFrm f2 = new assetRegFrm();
            f2.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            f2.ShowDialog();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (ID == "")
                MessageBox.Show("Please select item to update ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                AssetUpdateForm f3 = new AssetUpdateForm();
                f3.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                f3.ShowDialog();
                ID = "";
            }
        }

        private void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetDataInformation();
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = assetTable.DefaultView;
            dv.RowFilter = string.Format("[{0}] like '%{1}%'", searchCbb.Text, searchTxt.Text);
            dataGridView1.DataSource = dv.ToTable();
            dataGridView1.ClearSelection();
        }

        private void searchCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTxt.Focus();
        }

        private void toArchiveBtn_Click(object sender, EventArgs e)
        {
            if (ID == "")
                MessageBox.Show("Please select item to send to Archive ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SendToArchive(); 
            }
        }
    }
}
