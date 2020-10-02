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
    public partial class archiveFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable assetTable;
        int curRow;

        public static string IDValue = "";
        public archiveFrm()
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
                    btn.BackColor = Color.FromArgb(255, 0, 0);
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
              "WHERE av.Archive = 1");
            dataGridView1.DataSource = assetTable;
        }

        private void archiveFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetDataInformation();
            dataGridView1.Rows[0].Selected = false;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            searchCbb.SelectedIndex = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                curRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[curRow];
                IDValue = row.Cells[0].Value.ToString();
            }
            catch (Exception) { }
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

        private void toAssetBtn_Click(object sender, EventArgs e)
        {
            if (IDValue == "")
                MessageBox.Show("Please select item to send to Asset Menu ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult res = MessageBox.Show("Do you want to send this item to Asset Menu ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [AssetView] SET Archive = 0  WHERE AssetID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(IDValue));
                    cmd.ExecuteReader();
                    conn.Close();
                    GetDataInformation();
                    IDValue = "";
                }
            }
        }

       
    }
}
