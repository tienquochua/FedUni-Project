using FontAwesome.Sharp;
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
        //private Button curBtn;
        private IconButton curBtn;
        private Panel leftBorderBtn;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public homeFrm()
        {
            InitializeComponent();
            //random = new Random();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }
        // Form Style 1
       /* private Color SelectThemeColor()
         {
             int index = random.Next(Theme.ColorList.Count);
             while (tempIndex == index)
             {
                 index = random.Next(Theme.ColorList.Count);
             }
             tempIndex = index;
             string color = Theme.ColorList[index];
             return ColorTranslator.FromHtml(color);
         }*/
         /*private void ActivateButton(object btnSender)
         {
             if(btnSender !=null)
             {
                 if(curBut != (Button)btnSender)
                 {
                     DisableButton();
                     Color color = SelectThemeColor();
                     curBut = (Button)btnSender;
                     curBut.BackColor = color;
                     curBut.ForeColor = Color.White;
                     curBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                     panelTitleBar.BackColor = color;
                     panelLogo.BackColor = Theme.ChangeColorBrightness(color, -0.3);
                     Theme.PrimColor = color;
                     Theme.SecColor = Theme.ChangeColorBrightness(color, -0.3);
                 }
             }
         }
         private void DisableButton()
         {
             foreach(Control previousBtn in panelMenu.Controls)
             {
                 if(previousBtn.GetType() == typeof(Button))
                 {
                     previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                     previousBtn.ForeColor = Color.Gainsboro;
                     previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                 }
             }
         }*/
        private struct RBGColors
        {
            public static Color color1 = Color.FromArgb(30, 144, 255);
            public static Color color2 = Color.FromArgb(255, 165, 0);
            public static Color color3 = Color.FromArgb(255, 0, 0);
        }
        private void ActivateButton(object btnSender, Color color)
        {
            if (btnSender != null)
            {
                if (curBtn != (IconButton)btnSender)
                {
                    DisableButton();
                    curBtn = (IconButton)btnSender;
                    curBtn.BackColor = Color.FromArgb(51, 51, 76);
                    curBtn.ForeColor = color;
                    curBtn.TextAlign = ContentAlignment.MiddleCenter;
                    curBtn.IconColor = color;
                    curBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    curBtn.ImageAlign = ContentAlignment.MiddleRight;
                    //Left border button
                    leftBorderBtn.BackColor = color;
                    leftBorderBtn.Location = new Point(0, curBtn.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();
                }
            }
        }
        private void DisableButton()
        {
            if (curBtn != null)
            {
                curBtn.BackColor = Color.FromArgb(51, 51, 76);
                curBtn.ForeColor = Color.Gainsboro;
                curBtn.TextAlign = ContentAlignment.MiddleLeft;
                curBtn.IconColor = Color.Gainsboro;
                curBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                curBtn.ImageAlign = ContentAlignment.MiddleRight;
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
        }
        private void assetBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color1);
            OpenChildForm(new assetFrm(), sender);
        }
        private void staffBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color2);
            OpenChildForm(new staffFrm(), sender);
        }
        private void archiveBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color3);
            OpenChildForm(new archiveFrm(), sender);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void homeFrm_Load(object sender, EventArgs e)
        {
            if (loginFrm.authValue == "Super User")
                btnStaff.Enabled = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
        }
    }
}
