using PAMSMU_Business;
using System;
using System.Windows.Forms;

namespace PAMSMU
{
    public partial class frmMain : Form
    {
        private int _PersonID;
        private frmLogin _frmLogin;
        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _frmLogin = login;
        }

        private bool _FindByName()
        {
            clsPerson person = clsPerson.FindByName(tbFullName.Text.Trim());
            if (person != null)
            {
                _PersonID = person.PersonID;
                return true;
            }
            return false;
        }
        private bool _FindByStatisticalNumber()
        {
            clsPerson person = clsPerson.FindByStatisticalNumber(tbStatisticalNumber.Text.Trim());
            if (person != null)
            {
                _PersonID = person.PersonID;
                return true;
            }
            return false;
        }




        private void Team_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTeam form = new frmTeam();
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFullName.Text) && string.IsNullOrEmpty(tbStatisticalNumber.Text))
            {
                MessageBox.Show("رجاءاً ادخل الرقم الاحصائي او الاسم الكامل", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(tbFullName.Text))
            {
                if (_FindByName())
                {
                    btnShowMilitaryRecord.Enabled = true;
                    btnEntitlements.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لا يوجد منتسب , حاول مرة اخرى ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnShowMilitaryRecord.Enabled = false;
                    btnEntitlements.Enabled = false;
                }
            }
            if (!string.IsNullOrEmpty(tbStatisticalNumber.Text))
            {
                if (_FindByStatisticalNumber())
                {
                    btnShowMilitaryRecord.Enabled = true;
                    btnEntitlements.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لا يوجد منتسب , حاول مرة اخرى ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnShowMilitaryRecord.Enabled = false;
                    btnEntitlements.Enabled = false;
                }
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblNumberOfPeople.Text = clsPerson.NumberOfPeople().ToString();
            tbFullName.Enabled = rbFullName.Checked;
            tbStatisticalNumber.Enabled = rbStatisticalNumber.Checked;
        }

        private void rbStatisticalNumber_CheckedChanged(object sender, EventArgs e)
        {
            tbStatisticalNumber.Enabled = rbStatisticalNumber.Checked;
            tbFullName.Text = string.Empty;
        }

        private void rbFullName_CheckedChanged(object sender, EventArgs e)
        {
            tbFullName.Enabled = rbFullName.Checked;
            tbStatisticalNumber.Text = string.Empty;
        }

        private void tbStatisticalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnOpeningMilitaryRecord_Click(object sender, EventArgs e)
        {
            frmMilitaryRecord f = new frmMilitaryRecord();
            this.Hide();
            f.ShowDialog();
            if (f.IsSave)
            {
                frmMain_Load(null, null);
            }
            this.Show();
        }

        private void btnShowMilitaryRecord_Click(object sender, EventArgs e)
        {
            frmMilitaryRecord f = new frmMilitaryRecord(_PersonID);
            this.Hide();
            f.ShowDialog();
            if (f.IsSave)
            {
                frmMain_Load(null, null);
                btnSearch.PerformClick();
            }
            if (f.IsDeleted)
            {
                btnShowMilitaryRecord.Enabled = false;
                btnEntitlements.Enabled = false;
            }
            this.Show();
        }

        private void tbShowEntitlements_Click(object sender, EventArgs e)
        {
            frmEntitlements entitlements = new frmEntitlements(_PersonID);
            this.Hide();
            entitlements.ShowDialog();
            this.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Global.User = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
