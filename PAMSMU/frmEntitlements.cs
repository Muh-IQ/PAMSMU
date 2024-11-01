using PAMSMU_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PAMSMU
{
    public partial class frmEntitlements : Form
    {
        private int _PersonID;
        private DataTable _dataTable;
        public frmEntitlements(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _ProcessPieceOfGround()
        {
            _dataTable = new DataTable();
            _dataTable = clsEntitlements.GetPieceOfGround(_PersonID);
            if (_dataTable.Rows.Count > 0)
            {
                DataRow dataRow = _dataTable.Rows[0];
                string Date = dataRow["تاريخ"].ToString();
                string Excuses = dataRow["أعذار"].ToString();

                string PoorService = dataRow["سوء خدمة"].ToString();
                string Vacation = dataRow["أجازة"].ToString();

                lbWorthPieceOfLand.Text = Date;

                if (Date == "يستحق")
                {
                    if (Excuses == "لا يوجد")
                    {
                        plPieceOfGround.BackColor = Color.MediumSeaGreen;
                        lblBut_He_Has.Visible = false;
                        lbBecause1.Visible = false;
                        lbAnd.Visible = false;
                        lbBecause2.Visible = false;
                    }
                    else
                    {
                        plPieceOfGround.BackColor = Color.RosyBrown;
                        lblBut_He_Has.Visible = true;
                        lbBecause1.Visible = true;
                        lbBecause1.Text = (PoorService == "سوء خدمة") ? "سوء خدمة" : "أجازة";

                        if (Vacation == "أجازة" && lbBecause1.Text != "أجازة")
                        {
                            lbAnd.Visible = true;
                            lbBecause2.Visible = true;
                            lbBecause2.Text = "أجازة";
                        }
                    }
                    return;
                }
                plPieceOfGround.BackColor = Color.Crimson;
            }
        }
        private void _ProcessAnnualBonus()
        {
            _dataTable = clsEntitlements.GetAnnualBonus(_PersonID);
            if (_dataTable.Rows.Count > 0)
            {
                DataRow dataRow = _dataTable.Rows[0];
                string PoorService = dataRow["PoorService"].ToString();
                string Date = dataRow["Date"].ToString();

                lbAnnualBonus.Text = Date;

                if (Date == "يستحق")
                {
                    if (PoorService == "لا يوجد")
                    {
                        plAnnualBonus.BackColor = Color.MediumSeaGreen;
                        lblBut_He_Has_AnnualBonus.Visible = false;
                        lbBecauseAnnualBonus.Visible = false;

                    }
                    else
                    {
                        plAnnualBonus.BackColor = Color.RosyBrown;
                        lblBut_He_Has_AnnualBonus.Visible = true;
                        lbBecauseAnnualBonus.Visible = true;
                        lbBecauseAnnualBonus.Text = PoorService;

                    }
                    return;
                }
                plAnnualBonus.BackColor = Color.Crimson;
            }
        }
        private void _ProcessPromotion()
        {
            _dataTable = clsEntitlements.GetPromotion(_PersonID);
            if (_dataTable.Rows.Count > 0)
            {
                DataRow dataRow = _dataTable.Rows[0];
                string PoorService = dataRow["PoorService"].ToString();
                string Date = dataRow["Date"].ToString();

                lbPromotion.Text = Date;

                if (Date == "يستحق")
                {
                    if (PoorService == "لا يوجد")
                    {
                        plPromotion.BackColor = Color.MediumSeaGreen;
                        lblBut_He_Has_Promotion.Visible = false;
                        lbBecausePromotion.Visible = false;

                    }
                    else
                    {
                        plPromotion.BackColor = Color.RosyBrown;
                        lblBut_He_Has_Promotion.Visible = true;
                        lbBecausePromotion.Visible = true;
                        lbBecausePromotion.Text = "سوء خدمة";

                    }
                    return;
                }
                plPromotion.BackColor = Color.Crimson;
            }
        }
        private void frmEntitlements_Load(object sender, EventArgs e)
        {
            _ProcessPieceOfGround();

            _ProcessAnnualBonus();
            
            _ProcessPromotion();
        }
    }
}
