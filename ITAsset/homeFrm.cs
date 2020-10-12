using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ITAsset
{
    public partial class homeFrm : Form
    {
        private IconButton curBtn;
        private Panel leftBorderBtn;
        private Form activeForm;
        public homeFrm()
        {
            InitializeComponent();
            //random = new Random();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.ControlBox = false;
            // Reduce flicker in Form graphic
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Text = string.Empty;
            //Timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }
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
                    //Icon Current Child Form
                    iconCurChildFrm.IconChar = curBtn.IconChar;
                    iconCurChildFrm.IconColor = color;

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
                curBtn.ImageAlign = ContentAlignment.MiddleLeft;
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
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
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
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurChildFrm.IconChar = IconChar.Home;
            iconCurChildFrm.IconColor = Color.MediumPurple;
            lbTitle.Text = "Home";
        }
        
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
