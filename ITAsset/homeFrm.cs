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
            f1.ShowDialog();
            
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrm f2 = new loginFrm();
            f2.ShowDialog();

        }
    }
}
