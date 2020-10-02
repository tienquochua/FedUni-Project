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
        TextBox curText;
        public AssetUpdateForm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            cbbVendor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void GetDataInformation()
        {
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            cbbVendor.DataSource = vendorTable;
            cbbVendor.DisplayMember = "VendorName";
            cbbVendor.ValueMember = "VendorID";
            lblItemID.Text = assetFrm.ID;
            txtItemName.Text = assetFrm.ItemName;
            dateTimePicker1.Value = DateTime.Parse(assetFrm.PurDate);
            txtPurLocation.Text = assetFrm.PurLoc;
            cbbVendor.SelectedIndex = cbbVendor.FindStringExact(assetFrm.Vendor);
            cbbStatus.SelectedIndex = cbbStatus.FindStringExact(assetFrm.Status);
            txtAgreement.Text = assetFrm.LeaseAgree;
            if (txtAgreement.Text == "")
                txtAgreement.Text = "Lease Agreement";
        }
        private void CheckLeaseAgreementAndExecute()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd2 = new SqlCommand("UPDATE [AssetView] SET VendorID=@vid, AssetName=@aname, PurchaseDate=@purdate, PurchaseLocation=@purloc, Status=@status, LeaseAgreement=@agreement, LastUpdate=@lastup, UserID=@uid  WHERE AssetID=@id", conn);
            cmd2.Parameters.AddWithValue("@id", lblItemID.Text);
            cmd2.Parameters.AddWithValue("@aname", txtItemName.Text);
            cmd2.Parameters.AddWithValue("@vid", cbbVendor.SelectedValue);
            cmd2.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd2.Parameters.AddWithValue("@purloc", txtPurLocation.Text);
            cmd2.Parameters.AddWithValue("@status", cbbStatus.SelectedItem);
            cmd2.Parameters.AddWithValue("@agreement", txtAgreement.Text);
            cmd2.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@uid", loginFrm.staffIDValue);
            if (txtAgreement.Text == "" || txtAgreement.Text == "Lease Agreement")
            {
                MessageBox.Show("Please enter Lease Agreement ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                cmd2.ExecuteReader();
                MessageBox.Show("Update Complete");
                conn.Close();
                this.Close();
            }
        }
        private void ExecuteCommandWithoutAgreement()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd3 = new SqlCommand("UPDATE [AssetView] SET VendorID=@vid, AssetName=@aname, PurchaseDate=@purdate, PurchaseLocation=@purloc, Status=@status, LastUpdate=@lastup, UserID=@uid  WHERE AssetID=@id", conn);
            cmd3.Parameters.AddWithValue("@id", lblItemID.Text);
            cmd3.Parameters.AddWithValue("@aname", txtItemName.Text);
            cmd3.Parameters.AddWithValue("@vid", cbbVendor.SelectedValue);
            cmd3.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd3.Parameters.AddWithValue("@purloc", txtPurLocation.Text);
            cmd3.Parameters.AddWithValue("@status", cbbStatus.SelectedItem);
            cmd3.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
            cmd3.Parameters.AddWithValue("@uid", loginFrm.staffIDValue);
            conn.Open();
            cmd3.ExecuteReader();
            MessageBox.Show("Update Complete");
            conn.Close();
            this.Close();
        }
        private void ExecuteCommand()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr;
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [AssetView] WHERE VendorID=@vid AND AssetName= @aname AND PurchaseDate=@purdate AND PurchaseLocation=@purloc AND Status=@status", conn);
            cmd1.Parameters.AddWithValue("@aname", txtItemName.Text);
            cmd1.Parameters.AddWithValue("@vid", cbbVendor.SelectedValue);
            cmd1.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd1.Parameters.AddWithValue("@purloc", txtPurLocation.Text);
            cmd1.Parameters.AddWithValue("@status", cbbStatus.SelectedItem);
            cmd1.Parameters.AddWithValue("@agreement", txtAgreement.Text);
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                MessageBox.Show("No information has been changed, update fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Close();
                //Check if status is "Borrowed"
                if (cbbStatus.SelectedIndex == 1)
                {
                    CheckLeaseAgreementAndExecute();
                }
                else
                {
                    ExecuteCommandWithoutAgreement();
                }
            }
        }
        private void AssetUpdateForm_Load(object sender, EventArgs e)
        {
            GetDataInformation();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || cbbVendor.Text == "" || cbbStatus.Text == "" || txtPurLocation.Text == "")
                MessageBox.Show("Please enter all the detail");
            else
            {
                ExecuteCommand();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AssetUpdateForm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Remove default text when click
        private void CurText_Click(object sender, EventArgs e)
        {
            curText = (TextBox)sender;
            if (curText.Text.Trim() == "Item Name" || curText.Text.Trim() == "Purchase Location" || curText.Text.Trim() == "Lease Agreement")
                curText.Text = string.Empty;
        }

        private void statusCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex == 1)
                txtAgreement.Enabled = true;
            else
                txtAgreement.Enabled = false;
        }

        private void AssetUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetDataInformation();
            cbbVendor.SelectedIndex = -1;
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            vendorRegFrm f2 = new vendorRegFrm();
            f2.FormClosed += new FormClosedEventHandler(AssetUpdateForm_FormClosed);
            f2.ShowDialog();
        }
    }
}
