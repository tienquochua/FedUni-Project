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
    public partial class vendorRegFrm : Form
    {
        string strConn;
        database objDTB;
        public vendorRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            vendorTxt.MaxLength = 50;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr = null;
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Vendor] (VendorName) VALUES ('" + vendorTxt.Text + "' ) ; ", conn);
            dr = cmd.ExecuteReader();
            MessageBox.Show("New Vendor added successfully ");

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}