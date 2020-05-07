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
    public partial class loginFrm : Form
    {
        public loginFrm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtUsername.MaxLength = 10;
            txtPassword.MaxLength = 10;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local)\\MSSQLSERVER01;Initial Catalog=.ITASSET;Integrated Security=True");
            SqlDataReader dr = null;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] where Username='" + txtUsername.Text.Trim() + "'and Password='" + txtPassword.Text.Trim() + "'", conn);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                this.Hide();
                homeFrm f1 = new homeFrm();
                f1.ShowDialog();
            }
            else
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Insert username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
                else MessageBox.Show("Username or Password is incorrect!", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy bỏ quá trình đăng nhập?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
