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
    public partial class AssetUpdateForm : Form
    {
        string strConn;
        database objDTB;
        DataTable vendorTable;
        public AssetUpdateForm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
        }

        private void AssetUpdateForm_Activated(object sender, EventArgs e)
        {
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            vendorCbb.DataSource = vendorTable;
            vendorCbb.DisplayMember = "VendorName";
            vendorCbb.ValueMember = "VendorID";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            itemID.Text = assetFrm.ValueForText1;
            itemTxt.Text = assetFrm.ValueForText2;
            dateTimePicker1.Value = DateTime.Parse(assetFrm.ValueForText3);
            purLocationTxt.Text = assetFrm.ValueForText5;
            vendorCbb.SelectedIndex = vendorCbb.FindStringExact(assetFrm.ValueForText4);
            statusCbb.SelectedIndex = statusCbb.FindStringExact(assetFrm.ValueForText6);
            vendorCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            txtAgreement.Text = assetFrm.ValueForText7;

        }
       
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (itemTxt.Text == "" || vendorCbb.Text == "" || statusCbb.Text == "" || purLocationTxt.Text == "")
                MessageBox.Show("Please enter all the detail");
            else
            {
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataReader dr = null;
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM [AssetView] WHERE VendorID=@vid AND AssetName= @aname AND PurchaseDate=@purdate AND PurchaseLocation=@purloc AND Status=@status AND LeaseAgreement=@agreement  ", conn);
                cmd1.Parameters.AddWithValue("@aname", itemTxt.Text);
                cmd1.Parameters.AddWithValue("@vid", vendorCbb.SelectedValue);
                cmd1.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
                cmd1.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
                cmd1.Parameters.AddWithValue("@status", statusCbb.SelectedItem);
                cmd1.Parameters.AddWithValue("@agreement", txtAgreement.Text);
                SqlCommand cmd2 = new SqlCommand("UPDATE [AssetView] SET VendorID=@vid, AssetName=@aname, PurchaseDate=@purdate, PurchaseLocation=@purloc, Status=@status, LeaseAgreement=@agreement, LastUpdate=@lastup, UserID=@uid  WHERE AssetID=@id", conn);
                cmd2.Parameters.AddWithValue("@id", itemID.Text);
                cmd2.Parameters.AddWithValue("@aname", itemTxt.Text);
                cmd2.Parameters.AddWithValue("@vid", vendorCbb.SelectedValue);
                cmd2.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
                cmd2.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
                cmd2.Parameters.AddWithValue("@status", statusCbb.SelectedItem);
                cmd2.Parameters.AddWithValue("@agreement", txtAgreement.Text);
                cmd2.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
                cmd2.Parameters.AddWithValue("@uid",loginFrm.staffIDValue);
                dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    conn.Close();
                    MessageBox.Show("No information has been changed, update fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    dr = cmd2.ExecuteReader();
                    MessageBox.Show("Update Complete");
                    conn.Close();
                    this.Close();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
