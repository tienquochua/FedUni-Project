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
    public partial class staffUpdateFrm : Form
    {
        public staffUpdateFrm()
        {
            InitializeComponent();
        }

        private void staffUpdateFrm_Activated(object sender, EventArgs e)
        {
            staffID.Text = staffFrm.ValueForText1;
            
        }
    }
}
