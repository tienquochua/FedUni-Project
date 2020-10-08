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
        int IDValue = 0 ;
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
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
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

        private void SendToAsset()
        {
            DialogResult res = MessageBox.Show("Do you want to unarchive this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [AssetView] SET Archive = 0  WHERE AssetID=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDValue);
                cmd.ExecuteReader();
                conn.Close();
                IDValue = 0;
            }
        }
        private void archiveFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetDataInformation();
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            cbbSearch.SelectedIndex = 0;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                curRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[curRow];
                IDValue = (int) row.Cells[0].Value;
            }
            catch (Exception) { }
        }
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = assetTable.DefaultView;
            dv.RowFilter = string.Format("[{0}] like '%{1}%'", cbbSearch.Text, txtSearch.Text);
            dataGridView1.DataSource = dv.ToTable();
            dataGridView1.ClearSelection();
        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnToAsset_Click(object sender, EventArgs e)
        {
            if (IDValue == 0)
                MessageBox.Show("Please select item to send back to Asset Menu ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SendToAsset();
                GetDataInformation();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "Enter text here")
                txtSearch.Text = string.Empty;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = assetTable.DefaultView;
            dv.RowFilter = string.Format("[{0}] like '%{1}%'", cbbSearch.Text, txtSearch.Text);
            dataGridView1.DataSource = dv.ToTable();
            dataGridView1.ClearSelection();
        }
    }
}
