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
    public partial class staffFrm : Form
    {
        string strConn;
        database objDTB;
        DataTable staffTable;
        int curRow;
        public static string IDValue = "";
        public staffFrm()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objDTB = new database(strConn);
            
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Color.FromArgb(255, 165, 0);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void GetDataInformation()
        {
            staffTable = objDTB.ReadData("SELECT UserID AS 'ID', FullName AS 'Staff Name', Username, Authentication, Email FROM [User]");
            dataGridView1.DataSource = staffTable;
            dataGridView1.ClearSelection();
            dataGridView1.FirstDisplayedCell = null;
        }
        private void DeleteStaffData()
        {
            DialogResult res = MessageBox.Show("Do you want to delete this staff information ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE UserID = @id", conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(IDValue));
                cmd.ExecuteReader();
                conn.Close();
                GetDataInformation();
                IDValue = "";
            }
        }
        private void staffFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetDataInformation();
            cbbSearch.SelectedIndex = 0;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                curRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[curRow];
                IDValue = row.Cells[0].Value.ToString();
            }
            catch (Exception) { };
            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = staffTable.DefaultView;
            dv.RowFilter = string.Format("[{0}] like '%{1}%'", cbbSearch.Text, txtSearch.Text.Trim());
            dataGridView1.DataSource = dv.ToTable();
            dataGridView1.ClearSelection();
        }

        private void staffFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetDataInformation();
            IDValue = "";
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            staffRegFrm f1 = new staffRegFrm();
            f1.FormClosed += new FormClosedEventHandler(staffFrm_FormClosed);
            f1.ShowDialog();
        }
        
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (IDValue == "")
                MessageBox.Show("Please select staff to update ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (IDValue == "1")
                MessageBox.Show("Admin account cannot be updated ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                staffUpdateFrm f2 = new staffUpdateFrm();
                f2.FormClosed += new FormClosedEventHandler(staffFrm_FormClosed);
                f2.ShowDialog();
            }
            
        }

        private void searchCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
                
            if (IDValue == "")
                MessageBox.Show("Please select staff to delete ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (IDValue == "1")
                MessageBox.Show("Admin account cannot be deleted ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (IDValue == loginFrm.staffIDValue.ToString())
                MessageBox.Show("You are using this account, can't be deleted ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                DeleteStaffData();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            GetDataInformation();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "Enter text here")
                txtSearch.Text = string.Empty;
        }
    }
}
