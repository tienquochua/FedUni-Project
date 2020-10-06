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
    public partial class staffRegFrm : Form
    {
        string strConn;
        Hash hash;
        TextBox curText;

        public staffRegFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            txtName.MaxLength = 50;
            txtUsername.MaxLength = 20;
            txtEmail.MaxLength = 30;
            cbbAuth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbAuth.SelectedIndex = -1;
            hash = new Hash();
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

        private void InsertIntoDataBase()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [User] (FullName, Username, Password, Authentication, Email) " +
                "VALUES(@name,@username,@password,@authentication,@email)", conn);
            cmd2.Parameters.AddWithValue("@name", txtName.Text);
            cmd2.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd2.Parameters.AddWithValue("@password", hash.md5(txtPassword.Text));
            cmd2.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
            conn.Open();
            cmd2.ExecuteReader();
            MessageBox.Show("Staff registered successfully ");
            conn.Close();
        }

        private void ExecuteCommand()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [User] WHERE Username=@username", conn);
            cmd1.Parameters.AddWithValue("@username", txtUsername.Text);
            //check if user name is existed, else execute sql command 2
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Username is already existed !");
                conn.Close();
            }
            else
            {
                conn.Close();
                InsertIntoDataBase();
                txtName.Text = "Staff Name";
                txtPassword.Text = "Password";
                txtUsername.Text = "Username";
                txtEmail.Text = "Email Address";
                cbbAuth.SelectedIndex = -1;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtName.Text == "Staff Name" || txtUsername.Text == "" || txtUsername.Text == "Username" || txtPassword.Text == "" || txtPassword.Text == "Password" || txtEmail.Text == "" || txtEmail.Text == "Email") 
                MessageBox.Show("Please enter all the detail");
            else
            {
                ExecuteCommand();
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Enter Password")
                txtPassword.UseSystemPasswordChar = true;
        }

        private void staffRegFrm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void staffRegFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void curText_Click(object sender, EventArgs e)
        {
            curText = (TextBox)sender;
            if (curText.Text.Trim() == "Staff Name" || curText.Text.Trim() == "Username" || curText.Text.Trim() == "Password" || curText.Text.Trim() == "Email Address")
                curText.Text = string.Empty;
        }
    }
}
