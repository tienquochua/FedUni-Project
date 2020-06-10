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

namespace ITAsset
{
    public partial class assetFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable assetTable;
        int curRow;
        public static string ValueForText1 = "";
        public static string ValueForText2 = "";
        public static string ValueForText3 = "";
        public static string ValueForText4 = "";
        public static string ValueForText5 = "";
        public static string ValueForText6 = "";
        public assetFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
        }
        private void assetFrm_Activated(object sender, EventArgs e)
        {
            assetTable = objDTB.ReadData("SELECT av.AssetID AS 'Item No.', av.AssetName AS 'Item', av.PurchaseDate AS 'Purchase Date', v.VendorName AS 'Vendor', av.PurchaseLocation AS 'Purchase Location', av.Status, av.LastUpdate AS 'Last Update' " +
               "FROM [AssetView] av INNER JOIN [Vendor] v " +
               "ON av.VendorID= v.VendorID");
            dataGridView1.DataSource = assetTable;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            assetRegFrm f2 = new assetRegFrm();
            f2.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            f2.ShowDialog();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            curRow = dataGridView1.CurrentRow.Index;
            DataRow dataRow = assetTable.Rows[curRow];
            ValueForText1 = dataRow[0].ToString();
            ValueForText2 = dataRow[1].ToString();
            ValueForText3 = dataRow[2].ToString();
            ValueForText4 = dataRow[3].ToString();
            ValueForText5 = dataRow[4].ToString();
            ValueForText6 = dataRow[5].ToString();
            AssetUpdateForm f3 = new AssetUpdateForm();
            f3.ShowDialog();

        }

        private void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
