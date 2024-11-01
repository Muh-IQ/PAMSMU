using PAMSMU_Business;
using System;
using System.Windows.Forms;

namespace PAMSMU
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("رجاءاً أدخل أسم المستخدم و الرمز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsUser user = clsUser.FindByUserNameAndPassword(tbUserName.Text.Trim(), tbPassword.Text);
            if (user != null)
            {
                Global.User = user;

                tbPassword.Text = string.Empty;
                tbUserName.Text = string.Empty;
                frmMain f = new frmMain(this);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("تحقق من أسم المستخدم او الرمز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // new Form2().ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTeam form = new frmTeam();
            form.ShowDialog();
        }
    }
}
