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
        public assetFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
        }

        private void assetFrm_Load(object sender, EventArgs e)
        {
            assetTable = objDTB.ReadData("SELECT ad.AssetID AS 'Item No.', ad.AssetName AS 'Item', ad.PurchaseDate AS 'Purchase Date', v.VendorName AS 'Vendor', v.VendorLocation AS 'Purchase Location', av.Status, av.LastUpdate AS 'Last Update' " +
                "FROM [AssetDetail] ad, [AssetView] av, [Vendor] v " +
                "WHERE ad.AssetID=av.AssetID AND v.VendorID=av.VendorID");
            dataGridView1.DataSource = assetTable;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeFrm f1 = new homeFrm();
            f1.ShowDialog();
            
        }
    }
}
