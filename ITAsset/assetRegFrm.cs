﻿using System;
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
        
        public assetRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            itemNameTxt.MaxLength = 50;
            purLocationTxt.MaxLength = 70;

        }
        private void assetRegFrm_Activated(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            vendorCbb.DataSource = vendorTable;
            vendorCbb.DisplayMember = "VendorName";
            vendorCbb.ValueMember = "VendorID";
            vendorCbb.SelectedIndex = -1;
            vendorCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCbb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (itemNameTxt.Text == "" || vendorCbb.Text == "" || statusCbb.Text == "" || purLocationTxt.Text == "")
                MessageBox.Show("Please enter all the detail");
            else
            {
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataReader dr = null;
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM [AssetView] WHERE VendorID=@vid AND AssetName= @aname AND PurchaseDate=@purdate AND PurchaseLocation=@purloc AND Status=@status AND LeaseAgreement = @agreement  ", conn);
                cmd1.Parameters.AddWithValue("@aname", itemNameTxt.Text);
                cmd1.Parameters.AddWithValue("@vid", vendorCbb.SelectedValue);
                cmd1.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
                cmd1.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
                cmd1.Parameters.AddWithValue("@status", statusCbb.SelectedItem);
                cmd1.Parameters.AddWithValue("@agreement", txtAgreement.Text);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [AssetView] (VendorID, AssetName, PurchaseDate, PurchaseLocation, Status, LeaseAgreement, LastUpdate, UserID) VALUES(@vid,@aname,@purdate,@purloc,@status,@agreement,@lastup,@uid)", conn);
                cmd2.Parameters.AddWithValue("@vid", vendorCbb.SelectedValue);
                cmd2.Parameters.AddWithValue("@aname", itemNameTxt.Text);
                cmd2.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
                cmd2.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
                cmd2.Parameters.AddWithValue("@status", statusCbb.SelectedItem);
                cmd2.Parameters.AddWithValue("@agreement", txtAgreement.Text);
                cmd2.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
                cmd2.Parameters.AddWithValue("@uid", loginFrm.staffIDValue);
                dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    conn.Close();
                    MessageBox.Show("Item is already existed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    cmd2.ExecuteReader();
                    MessageBox.Show("Item registered successfully ");
                    itemNameTxt.Clear();
                    purLocationTxt.Clear();
                    vendorCbb.SelectedIndex = -1;
                    statusCbb.SelectedIndex = -1;
                    conn.Close();
                }
                
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void vendorAddBtn_Click(object sender, EventArgs e)
        {
            vendorRegFrm f2 = new vendorRegFrm();
            f2.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtAgreement_TextChanged(object sender, EventArgs e)
        {

        }

        private void assetRegFrm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
