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
    public partial class AssetUpdateForm : Form
    {
        string strConn;
        database objDTB;
        DataTable vendorTable;
        int curRow;
        public AssetUpdateForm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);

        }

        private void AssetUpdateForm_Load(object sender, EventArgs e)
        {
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            vendorCbb.DataSource = vendorTable;
            vendorCbb.DisplayMember = "VendorName";
            vendorCbb.ValueMember = "VendorID";
            vendorCbb.SelectedIndex = -1;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            itemID.Text = assetFrm.ValueForText1;
            itemTxt.Text = assetFrm.ValueForText2;
            dateTimePicker1.Value = DateTime.Parse(assetFrm.ValueForText3);
            purLocationTxt.Text = assetFrm.ValueForText5;
            vendorCbb.SelectedIndex = vendorCbb.FindStringExact(assetFrm.ValueForText4);
            statusCbb.SelectedIndex= statusCbb.FindStringExact(assetFrm.ValueForText6);

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            //objDTB.UpdateData(vendorTable, "SELECT * FROM [Vendor]");
            //MessageBox.Show("Update Complete");
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr = null;
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [AssetView] SET VendorID=@vname, AssetName= @aname, PurchaseDate=@purdate, PurchaseLocation=@purloc, Status=@status, LastUpdate=@lastup  WHERE AssetID=@id", conn);
            cmd.Parameters.AddWithValue("@id",itemID.Text);
            cmd.Parameters.AddWithValue("@aname", itemTxt.Text);
            cmd.Parameters.AddWithValue("@vname", vendorCbb.SelectedValue);
            cmd.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
            cmd.Parameters.AddWithValue("@status", statusCbb.SelectedItem);
            cmd.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
            dr = cmd.ExecuteReader();
            this.Hide();
            assetFrm f1 = new assetFrm();
            f1.ShowDialog();

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            assetFrm f1 = new assetFrm();
            f1.ShowDialog();
        }
    }
}
