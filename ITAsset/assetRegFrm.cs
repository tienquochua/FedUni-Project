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
    public partial class assetRegFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable  vendorTable;
        private TextBox curText;

        public assetRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            txtItemName.MaxLength = 50;
            txtPurLocation.MaxLength = 70;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            cbbVendor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void GetVendorName()
        {
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            cbbVendor.DataSource = vendorTable;
            cbbVendor.DisplayMember = "VendorName";
            cbbVendor.ValueMember = "VendorID";
        }
        private void CheckLeaseAgreementAndExecute()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd3 = new SqlCommand("INSERT INTO [AssetView] (VendorID, AssetName, PurchaseDate, PurchaseLocation, Status, LeaseAgreement, LastUpdate, UserID, Archive) VALUES(@vid,@aname,@purdate,@purloc,@status,@agreement,@lastup,@uid,0)", conn);
            cmd3.Parameters.AddWithValue("@vid", cbbVendor.SelectedValue);
            cmd3.Parameters.AddWithValue("@aname", txtItemName.Text);
            cmd3.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd3.Parameters.AddWithValue("@purloc", txtPurLocation.Text);
            cmd3.Parameters.AddWithValue("@status", cbbStatus.SelectedItem);
            cmd3.Parameters.AddWithValue("@agreement", txtAgreement.Text);
            cmd3.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
            cmd3.Parameters.AddWithValue("@uid", loginFrm.staffIDValue);
            if (txtAgreement.Text == "" || txtAgreement.Text == "Lease Agreement")
            {
                MessageBox.Show("Please enter Lease Agreement ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else
            {
                conn.Open();
                cmd3.ExecuteReader();
                MessageBox.Show("Item registered successfully ");
                txtItemName.Clear();
                txtPurLocation.Clear();
                cbbVendor.SelectedIndex = -1;
                cbbStatus.SelectedIndex = -1;
                conn.Close();
                txtAgreement.Enabled = false;
            }
        }
        private void ExecuteCommandWithoutAgreement()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [AssetView] (VendorID, AssetName, PurchaseDate, PurchaseLocation, Status, LastUpdate, UserID, Archive) VALUES(@vid,@aname,@purdate,@purloc,@status,@lastup,@uid,0)", conn);
            cmd2.Parameters.AddWithValue("@vid", cbbVendor.SelectedValue);
            cmd2.Parameters.AddWithValue("@aname", txtItemName.Text);
            cmd2.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
            cmd2.Parameters.AddWithValue("@purloc", txtPurLocation.Text);
            cmd2.Parameters.AddWithValue("@status", cbbStatus.SelectedItem);
            cmd2.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@uid", loginFrm.staffIDValue);
            conn.Open();
            cmd2.ExecuteReader();
            MessageBox.Show("Item registered successfully ");
            txtItemName.Clear();
            txtPurLocation.Clear();
            cbbVendor.SelectedIndex = -1;
            cbbStatus.SelectedIndex = -1;
            conn.Close();

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
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Item is already existed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtItemName.Text == "Item Name" || cbbVendor.Text == "" || cbbStatus.Text == "" || txtPurLocation.Text == "" || txtPurLocation.Text == "Purchase Location")
                MessageBox.Show("Please enter all the detail");
            else
                ExecuteCommand();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vendorAddBtn_Click(object sender, EventArgs e)
        {
            vendorRegFrm f2 = new vendorRegFrm();
            f2.FormClosed += new FormClosedEventHandler(assetRegFrm_FormClosed);
            f2.ShowDialog();
        }
       
        private void statusCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex == 1)
                txtAgreement.Enabled = true;
            else
                txtAgreement.Enabled = false;
        }

        private void assetRegFrm_Load(object sender, EventArgs e)
        {
            GetVendorName();
            cbbVendor.SelectedIndex = -1;
        }

        private void assetRegFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetVendorName();
            cbbVendor.SelectedIndex = -1;
        }
        private void assetRegFrm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void CurText_Click(object sender, EventArgs e)
        {
            curText = (TextBox)sender;
            if (curText.Text.Trim() =="Item Name" || curText.Text.Trim() == "Purchase Location" || curText.Text.Trim() == "Lease Agreement")
                curText.Text = string.Empty;
        }
    }
}
