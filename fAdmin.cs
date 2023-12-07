using System;
using FontAwesome.Sharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Calendar.v3.Data;
using System.Runtime.InteropServices;

namespace QLPhongGyM
{
    public partial class fAdmin : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public fAdmin()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);
            //form
            /*this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;*/
            /*this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;*/
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(154, 28, 28);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // icon chill home
                IconChillHome.IconChar = currentBtn.IconChar;
                IconChillHome.IconColor = color;

            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(218, 49, 49);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDeskTop.Controls.Add(childForm);
            panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblchillHome.Text = childForm.Text;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new fKhachHang());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new fSanPham());
        }

        private void btnGoiTap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new fGoiTap());
        }

        private void btnLichLam_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new fLichLam());
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new fKhuyenMai());
        }
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
        DisableButton();
        leftBorderBtn.Visible = false;
        IconChillHome.IconChar = IconChar.Home;
        IconChillHome.IconColor = Color.MediumPurple;
        lblchill.Text = "Home";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitelBar_MouseDown(object sender, MouseEventArgs e)
        {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblchill_Click(object sender, EventArgs e)
        {

        }
    }
}
