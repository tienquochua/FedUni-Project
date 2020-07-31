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
    public partial class vendorRegFrm : Form
    {
        string strConn;
        public vendorRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            vendorTxt.MaxLength = 50;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr = null;
            
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [Vendor] WHERE VendorName = '" + vendorTxt.Text + "'", conn);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Vendor] (VendorName) VALUES ('" + vendorTxt.Text + "' ) ; ", conn);
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                MessageBox.Show("Vendor is already exist ");
            }
            else
            {
                conn.Close();
                conn.Open();
                cmd2.ExecuteReader();
                MessageBox.Show("Vendor is successfully added ");
                conn.Close();
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
