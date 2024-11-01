using System;
using System.Windows.Forms;

namespace PAMSMU
{
    public partial class frmAuthenticationKey : Form
    {
        public frmAuthenticationKey()
        {
            InitializeComponent();
        }

        private void btnValidation_Click(object sender, EventArgs e)
        {
            if (tbAuthenticationKey.Text.Trim() == Global.User.SaveKey)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
