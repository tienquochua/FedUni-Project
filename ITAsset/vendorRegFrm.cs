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
            txtVendor.MaxLength = 50;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Color.FromArgb(78, 184, 206);
                    btn.ForeColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [Vendor] WHERE VendorName = @vendor", conn);
            cmd1.Parameters.AddWithValue("@vendor", txtVendor.Text);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Vendor] (VendorName) VALUES (@vendor) ", conn);
            cmd2.Parameters.AddWithValue("@vendor", txtVendor.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
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

        private void txtVendor_Click(object sender, EventArgs e)
        {
            if (txtVendor.Text.Trim() == "Vendor Name")
                txtVendor.Text = string.Empty;
        }

        private void vendorRegFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void vendorRegFrm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
