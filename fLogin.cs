using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongGyM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassword.Text;
            if (userName == "dangcaokien" && passWord == "1")
            {
                fAdmin f = new fAdmin();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
