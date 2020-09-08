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
        MD5 md5Encryption;
        public staffUpdateFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            md5Encryption = new MD5();
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dr = null;
            string passwords = md5Encryption.encrypt(txtPassword.Text);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM [User] WHERE FullName=@name AND Authentication=@authentication AND Email=@email  ", conn);
            cmd1.Parameters.AddWithValue("@name", txtName.Text);
            cmd1.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
            SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET FullName=@name, Authentication=@authentication, Email=@email WHERE UserID=@id " , conn);
            cmd2.Parameters.AddWithValue("@id", staffID.Text);
            cmd2.Parameters.AddWithValue("@name", txtName.Text);
            cmd2.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
            SqlCommand cmd3 = new SqlCommand("UPDATE [User] SET FullName=@name, Password=@password, Authentication=@authentication, Email=@email WHERE UserID=@id ", conn);
            cmd3.Parameters.AddWithValue("@id", staffID.Text);
            cmd3.Parameters.AddWithValue("@name", txtName.Text);
            cmd3.Parameters.AddWithValue("@password", passwords);
            cmd3.Parameters.AddWithValue("@authentication", cbbAuth.SelectedItem);
            cmd3.Parameters.AddWithValue("@email", txtEmail.Text);
            if (txtName.Text == "" || txtEmail.Text == "")
                MessageBox.Show("Please enter all the detail");
            else
            {
                if (txtPassword.Text == "")
                {
                    conn.Open();
                    dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        conn.Close();
                        MessageBox.Show("No information has been changed, update fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        cmd2.ExecuteReader();
                        MessageBox.Show("Update Complete");
                        conn.Close();
                        this.Close();
                    }
                }
                else
                {
                        conn.Close();
                        conn.Open();
                        cmd3.ExecuteReader();
                        MessageBox.Show("Update Complete");
                        conn.Close();
                        this.Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
