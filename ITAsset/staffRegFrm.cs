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
using System.Security.Cryptography;

namespace ITAsset
{
    public partial class staffRegFrm : Form
    {
        string strConn;
        MD5 md5Encryption;

        public staffRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            txtPassword.UseSystemPasswordChar = true;
            txtUsername.MaxLength = 20;
            txtPassword.MaxLength = 20;
            cbbAuth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbAuth.SelectedIndex = 0;
            md5Encryption = new MD5();

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtEmail.Text == "" ) 
                MessageBox.Show("Please enter all the detail");
            else
            {
                // connect to database and execute sql command
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataReader dr = null;
                string passwords = md5Encryption.encrypt(txtPassword.Text);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Username FROM [User] WHERE Username=@username", conn);
                cmd1.Parameters.AddWithValue("@username", txtUsername.Text);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [User] (FullName, Username, Password, Authentication, Email) " +
                    "VALUES(@name,@username,@password,@authentication,@email)", conn);
                cmd2.Parameters.AddWithValue("@name", txtName.Text);
                cmd2.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd2.Parameters.AddWithValue("@password", passwords);
                cmd2.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
                cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
                
                //check if user name is existed, else execute sql command 2
                dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Username is already existed !");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    cmd2.ExecuteReader();
                    MessageBox.Show("Staff registered successfully ");
                    conn.Close();
                }
                
            }

        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void staffRegFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) saveBtn_Click(sender, e);
        }
    }
}
