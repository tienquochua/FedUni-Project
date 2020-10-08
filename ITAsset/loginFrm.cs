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
using ITAsset.Entity;

namespace ITAsset
{
    public partial class loginFrm : Form
    {
        public static int staffIDValue;
        public static string authValue = "";
        string strConn;
        Hash hash;
        TextBox curText;

        public loginFrm()
        {
            InitializeComponent();
            this.ControlBox = false;
            txtUsername.MaxLength = 20;
            txtPassword.MaxLength = 20;
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            hash = new Hash();
        }
        private void Login()
        {
            User user = FindUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (user != null)
            {
                staffIDValue = user.UserID;
                authValue = user.Authentication;
                this.Hide();

                homeFrm f1 = new homeFrm();
                f1.FormClosed += new FormClosedEventHandler(loginFrm_FormClosed);
                f1.ShowDialog();

                return;
            }

            MessageBox.Show("Username or Password is incorrect!\r\nPlease contact ithelpdesk@atmc.edu.au for access.", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Clear();
        }

        private User FindUser(string username, string password)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT UserID, Authentication FROM [User] where Username=@uname and Password=@pass ", conn);
            cmd1.Parameters.AddWithValue("@uname", username);
            cmd1.Parameters.AddWithValue("@pass", hash.md5(password));
            SqlDataReader dr = cmd1.ExecuteReader(CommandBehavior.SingleRow);

            User user = null;
            if (dr.Read())
            {
                user = new User();
                user.UserID = (int) dr["UserID"];
                user.Authentication = dr["Authentication"].ToString();
            }

            conn.Close();

            return user;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "Username" || txtPassword.Text.Trim() == "Password" || txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Insert username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            else
            {
                Login();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel Login process ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loginBtn_Click(sender, e);
        }
        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) loginBtn_Click(sender, e);
        }
        private void loginFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtPassword.Text = "Password";
            txtUsername.Text = "Username";
            txtPassword.UseSystemPasswordChar = false;
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != "Password")
                txtPassword.UseSystemPasswordChar = true;
        }

        private void loginFrm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void curText_Click(object sender, EventArgs e)
        {
            curText = (TextBox)sender;
            if (curText.Text.Trim() == "Username" || curText.Text.Trim() == "Password")
                curText.Text = string.Empty;
        }
    }
}
