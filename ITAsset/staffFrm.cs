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

namespace ITAsset
{
    public partial class staffFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable staffTable;
        int curRow;
        public static string ValueForText1 = "";
        public static string ValueForText2 = "";
        public static string ValueForText3 = "";
        public static string ValueForText4 = "";
        public static string ValueForText5 = "";
        public static string ValueForText6 = "";
        public staffFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
        }

        private void staffFrm_Activated(object sender, EventArgs e)
        {
            staffTable = objDTB.ReadData("SELECT UserID AS 'ID', FullName AS 'Staff Name', Username, Password, Authentication, Email FROM [User]");
            dataGridView1.DataSource = staffTable;
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = staffTable.DefaultView;
            dv.RowFilter = string.Format("{0} like '%{1}%'", searchCbb.Text, searchTxt.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void staffFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffRegFrm f1 = new staffRegFrm();
            f1.FormClosed += new FormClosedEventHandler(staffFrm_FormClosed);
            f1.ShowDialog();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            curRow = dataGridView1.CurrentRow.Index;
            DataRow dataRow = staffTable.Rows[curRow];
            ValueForText1 = dataRow[0].ToString();
            ValueForText2 = dataRow[1].ToString();
            ValueForText3 = dataRow[2].ToString();
            ValueForText4 = dataRow[3].ToString();
            ValueForText5 = dataRow[4].ToString();
            ValueForText6 = dataRow[5].ToString();
            this.Hide();
            staffUpdateFrm f2 = new staffUpdateFrm();
            f2.FormClosed += new FormClosedEventHandler(staffFrm_FormClosed);
            f2.ShowDialog();
        }
    }
}
