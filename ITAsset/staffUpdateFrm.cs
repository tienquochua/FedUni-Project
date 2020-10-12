using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITAsset
{
    public partial class staffUpdateFrm : Form
    {
        DataTable staffTable;
        string strConn;
        database objDTB;
        Hash hash;
        TextBox curText;
        public staffUpdateFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            txtName.MaxLength = 50;
            txtUsername.MaxLength = 20;
            txtEmail.MaxLength = 30;
            hash = new Hash();
        }

        private void staffUpdateFrm_Activated(object sender, EventArgs e)
        {
            staffID.Text = staffFrm.IDValue;
            staffTable = objDTB.ReadData("SELECT FullName, Username, Authentication, Email FROM [User] WHERE UserID = '" + Convert.ToInt32(staffID.Text) + "'");
            txtName.Text = staffTable.Rows[0][0].ToString();
            txtUsername.Text = staffTable.Rows[0][1].ToString();
            cbbAuth.SelectedIndex = cbbAuth.FindStringExact(staffTable.Rows[0][2].ToString());
            txtEmail.Text = staffTable.Rows[0][3].ToString();
            cbbAuth.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void UpdateWithPassword()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd3 = new SqlCommand("UPDATE [User] SET FullName=@name, Password=@password, Authentication=@authentication, Email=@email WHERE UserID=@id ", conn);
            cmd3.Parameters.AddWithValue("@id", staffID.Text);
            cmd3.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmd3.Parameters.AddWithValue("@password", hash.md5(txtPassword.Text.Trim()));
            cmd3.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd3.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            conn.Open();
            cmd3.ExecuteReader();
            MessageBox.Show("Update Complete");
            conn.Close();
            this.Close();
        }

        private void UpdateWithoutPassword()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET FullName=@name, Authentication=@authentication, Email=@email WHERE UserID=@id ", conn);
            cmd2.Parameters.AddWithValue("@id", staffID.Text);
            cmd2.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmd2.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd2.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            conn.Open();
            cmd2.ExecuteReader();
            MessageBox.Show("Update Complete");
            conn.Close();
            this.Close();
        }

        private void ExecuteCommand()
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [User] WHERE FullName=@name AND Authentication=@authentication AND Email=@email  ", conn);
            cmd1.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmd1.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd1.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            if (txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == "New Password")
            {
                conn.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    conn.Close();
                    MessageBox.Show("No information has been changed, update fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Close();
                    UpdateWithoutPassword();
                }
            }
            else
            {
                conn.Close();
                UpdateWithPassword();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtEmail.Text.Trim() == "")
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != "New Password")
                txtPassword.UseSystemPasswordChar = true;
        }
        private void staffUpdateFrm_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void staffUpdateFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void curText_Click(object sender, EventArgs e)
        {
            curText = (TextBox)sender;
            if (curText.Text.Trim() == "New Password")
                curText.Text = string.Empty;
        }
    }
}
