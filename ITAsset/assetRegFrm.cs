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
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            vendorTable = objDTB.ReadData("SELECT * FROM [Vendor]");
            vendorCbb.DataSource = vendorTable;
            vendorCbb.DisplayMember = "VendorName";
            vendorCbb.ValueMember = "VendorID";
            vendorCbb.SelectedIndex = -1;
            this.vendorCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.statusCbb.DropDownStyle = ComboBoxStyle.DropDownList;
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

                SqlCommand cmd = new SqlCommand("INSERT INTO [AssetView] (VendorID, AssetName, PurchaseDate, PurchaseLocation, Status, LastUpdate) VALUES(@vid,@aname,@purdate,@purloc,@status,@lastup)", conn);
                cmd.Parameters.AddWithValue("@vid", vendorCbb.SelectedValue);
                cmd.Parameters.AddWithValue("@aname", itemNameTxt.Text);
                cmd.Parameters.AddWithValue("@purdate", dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@purloc", purLocationTxt.Text);
                cmd.Parameters.AddWithValue("@status", statusCbb.GetItemText(statusCbb.SelectedItem));
                cmd.Parameters.AddWithValue("@lastup", DateTime.Now.ToString());
                dr = cmd.ExecuteReader();
                MessageBox.Show("Item registered successfully ");
                itemNameTxt.Clear();
                purLocationTxt.Clear();
                vendorCbb.SelectedIndex = -1;
                statusCbb.SelectedIndex = -1;
                conn.Close();
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


    }
}
