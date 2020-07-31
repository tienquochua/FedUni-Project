using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITAsset
{
    public partial class homeFrm : Form
    {
        public homeFrm()
        {
            InitializeComponent();
        }

        private void assetBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            assetFrm f1 = new assetFrm();
            f1.FormClosed += new FormClosedEventHandler(homeFrm_FormClosed);
            f1.ShowDialog();
            
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void homeFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffFrm f2 = new staffFrm();
            f2.FormClosed += new FormClosedEventHandler(homeFrm_FormClosed);
            f2.ShowDialog();
        }
    }
}
