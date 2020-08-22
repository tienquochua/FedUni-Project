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
    public partial class loginFrm : Form
    {
        public static string ValueForText1 = "";
        public static string ValueForText2 = "";
        string strConn;
        database objDTB;
        DataTable userTable;
        MD5 md5Encryption;
        public loginFrm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtUsername.MaxLength = 20;
            txtPassword.MaxLength = 20;
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            md5Encryption = new MD5();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr = null;
            string password = md5Encryption.encrypt(txtPassword.Text);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [User] where Username=@uname and Password=@pass ", conn);
            cmd1.Parameters.AddWithValue("@uname", txtUsername.Text);
            cmd1.Parameters.AddWithValue("@pass", password);
            SqlCommand cmd2 = new SqlCommand("SELECT FullName, Email FROM [User] where Username=@uname and Password=@pass ", conn);
            cmd2.Parameters.AddWithValue("@uname", txtUsername.Text);
            cmd2.Parameters.AddWithValue("@pass", password);
            
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Insert username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            else
            {
                dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    conn.Close();
                    userTable = objDTB.ReadData("SELECT FullName, Email FROM [User] where Username ='" + txtUsername.Text + "'and Password ='" + password + "' ");
                    ValueForText1 = Convert.ToString(userTable.Rows[0][0]);
                    ValueForText2 = Convert.ToString(userTable.Rows[0][1]);
                    this.Hide();
                    homeFrm f1 = new homeFrm();
                    f1.FormClosed += new FormClosedEventHandler(loginFrm_FormClosed);
                    f1.ShowDialog();
                }
                else MessageBox.Show("Username or Password is incorrect!\r\nPlease contact ithelpdesk@atmc.edu.au for access.", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();

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
        }
    }
}
