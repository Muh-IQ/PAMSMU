using PAMSMU_Business;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PAMSMU
{
    public partial class frmMilitaryRecord : Form
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;
        private clsPerson _clsPerson;
        private int _PersonID;
        
        private clsAdministrative _clsAdministrative;
        private clsSocial _clsSocial;
        private clsScientific _clsScientific;
        private clsLegal _clsLegal;
        private clsServiceDetails _clsServiceDetails;

        public bool IsDeleted = false;
        public bool IsSave = false;
        public frmMilitaryRecord()
        {
            InitializeComponent();
            _Mode = _enMode.AddNew;
        }
        public frmMilitaryRecord(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = _enMode.Update;
        }

        private void _ResetDefulteValue()
        {
            {
                _clsAdministrative = new clsAdministrative();
                _clsSocial = new clsSocial();
                _clsPerson = new clsPerson();
                _clsScientific = new clsScientific();
                _clsLegal = new clsLegal();
                _clsServiceDetails = new clsServiceDetails();
            }

            cbRank.DisplayMember = "Name";
            cbRank.DataSource = clsRank.GetAllRank();
            btnDeletePerson.Visible = false;
            //Administrative
            {
                tbFullName.Text = string.Empty;
                tbSurname.Text = string.Empty;
                dtpDateOfBirth.Value = DateTime.Now;
                tbMotherFullName.Text = string.Empty;
                dtpOrderForAppointment.Value = DateTime.Now;
                dtpHistoryOfTheDiwaniOrder.Value = DateTime.Now;
                dtpStartDate.Value = DateTime.Now;
                lblPreviousUnit.Text = "[????????]"; 
                tbEmployeeID.Text = string.Empty;
                tbStatisticalNumber.Text = string.Empty;
                dtpDateOfIssueOfTheID.Value = DateTime.Now;
                tbCurrentUnit.Text = string.Empty;
                tbPlaceOfBirth.Text = string.Empty;
                cbRank.SelectedIndex = 0;
                tbBloodType.Text = string.Empty;
                dtpdateOfLastPromotion.Value = DateTime.Now;
                tbIDNumber.Text = string.Empty;
                tbUnifiedNumber.Text = string.Empty;
                tbSeniority.Text = string.Empty;
            }

            //Social
            {
                //Childrens
                {
                    tbNameChildren1.Text = string.Empty;
                    dtpDateOfBirthOfChildren1.Value = DateTime.MinValue.AddYears(2000);
                    tbProfessionChildren1.Text = string.Empty;

                    tbNameChildren2.Text = string.Empty;
                    dtpDateOfBirthOfChildren2.Value = DateTime.MinValue.AddYears(2000);
                    tbProfessionChildren2.Text = string.Empty;

                    tbNameChildren3.Text = string.Empty;
                    dtpDateOfBirthOfChildren3.Value = DateTime.MinValue.AddYears(2000);
                    tbProfessionChildren3.Text = string.Empty;

                    tbNameChildren4.Text = string.Empty;
                    dtpDateOfBirthOfChildren4.Value = DateTime.MinValue.AddYears(2000);
                    tbProfessionChildren4.Text = string.Empty;
                }

                //Cards
                {
                    tbCardNumberForResidence.Text = string.Empty;
                    dtpIssueDateForResidence.Value = DateTime.MinValue.AddYears(2000);
                    tbIssuingAuthorityForResidence.Text = string.Empty;

                    tbCardNumberForUnified.Text = string.Empty;
                    dtpIssueDateForUnified.Value = DateTime.MinValue.AddYears(2000);
                    tbIssuingAuthorityForUnified.Text = string.Empty;

                    tbCardNumberForVoterID.Text = string.Empty;
                    dtpIssueDateForResidence.Value = DateTime.MinValue.AddYears(1900);
                    tbIssuingAuthorityForVoterID.Text = string.Empty;
                }

                tbMaritalStatus.Text = string.Empty;
                tbNumberOfChildren.Text = string.Empty;
                tbPoliticians.Text = string.Empty;
                tbmartyrs.Text = string.Empty;
                tbPreviousResidence.Text = string.Empty;
                tbCurrentResidence.Text = string.Empty;
                tbNearestKnownPointToCurrentResidence.Text = string.Empty;

                tbChosenName.Text = string.Empty;
                tbPhoneNumber.Text = string.Empty;
                tbReligion.Text = string.Empty;
                tbNationalism.Text = string.Empty;
                tbWifesName.Text = string.Empty;
                tbWifesOccupation.Text = string.Empty;
                dtpWifesBirth.Value = DateTime.MinValue.AddYears(1900);
            }

            //Scientific
            {
                tbPrimarySchoolCertificateInformation.Text = string.Empty;
                tbInformationAboutTheIntermediateCertificate.Text = string.Empty;
                tbInformationAboutPreparatoryCertificate.Text = string.Empty;
                tbInformationAboutInstituteCertificate.Text = string.Empty;
                tbCollegeCertificateInformation.Text = string.Empty;
                tbInformationAboutBasicCourse.Text = string.Empty;
                tbInformationAboutOtherCourses.Text = string.Empty;
                tbInformationAboutHigherDegrees.Text = string.Empty;
            }

            //Legal
            {
                tbInvestigativeCouncils.Text = string.Empty;
                tbSanctions.Text = string.Empty;
                tbEntitlements.Text = string.Empty;
                tbAcademicVacations.Text = string.Empty;
                tbInjuries.Text = string.Empty;
                tbSickLeave.Text = string.Empty;
                tbTouristVacations.Text = string.Empty;
                tbReligiousHolidays.Text = string.Empty;
                tbNotes.Text = string.Empty;
                //Acknowledgments
                {
                    tbAcknowledgments1.Text = string.Empty;
                    tbAcknowledgments2.Text = string.Empty;
                    tbAcknowledgments3.Text = string.Empty;
                    tbAcknowledgments4.Text = string.Empty;
                    tbAcknowledgments5.Text = string.Empty;
                }
            }

            //ServiceDetails
            {
                pbImage.ImageLocation = null;
                tbPromotionOrders.Text = string.Empty;
                tbCriminalRestrictions.Text = string.Empty;
                tbGuarantees.Text = string.Empty;
                tbAnnualBonusOrders.Text = string.Empty;
                tbVariables.Text = string.Empty;
                tbServiceEvaluationByUnits.Text = string.Empty;
                tbNotes.Text = string.Empty;
            }

        }

        public override bool ValidateChildren()
        { 
            bool ResultBase = base.ValidateChildren();
            if (pbImage.ImageLocation == null) 
            {
                errorProvider.SetError(lilChooseImage, "الصورة مطلوبة");
                return false;
            }
            else
            {
                errorProvider.SetError(lilChooseImage, null);
            }
            return ResultBase;
        }
        private DateTime _CalculateBonusStartDate()
        {

            DateTime _BonusStartDate = DateTime.Now;
            int SelectedMonth = dtpStartDate.Value.Month;
            int SelectedYear = dtpStartDate.Value.Year;
            int SelectedDay = dtpStartDate.Value.Day;
            if (SelectedMonth >= 7)
            {
                _BonusStartDate = new DateTime(SelectedYear, 7, SelectedDay);
            }

            else if (SelectedMonth >= 1)
            {
                _BonusStartDate = new DateTime(SelectedYear, 1, SelectedDay);
            }

            return _BonusStartDate;
        }

        private bool _HandleImage()
        {
            if (_clsServiceDetails.ImagePath != pbImage.ImageLocation)
            {
                //Update
                if (_clsServiceDetails.ImagePath != null)
                {
                    try
                    {
                        File.Delete(_clsServiceDetails.ImagePath);
                    }
                    catch (Exception IoExp)
                    {
                        MessageBox.Show("خطأ في مسح الصورة القديمة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                //AddNew & Update
                if (pbImage.ImageLocation != null)
                {
                    string Path = pbImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToFolderImage(ref Path))
                    {
                        pbImage.ImageLocation = Path;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("خطأ في تحميل الصورة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        //Load to obj 
        private void _LoadDataToObjectAdministrative()//Add New
        {
            _clsAdministrative.Surname = tbSurname.Text.Trim();
            _clsAdministrative.DateOfBirth = dtpDateOfBirth.Value;
            _clsAdministrative.MotherFullName = tbMotherFullName.Text.Trim();
            _clsAdministrative.DateOfTheAdministrativeOrderForAppointment = dtpOrderForAppointment.Value;
            _clsAdministrative.HistoryOfTheDiwaniOrder = dtpHistoryOfTheDiwaniOrder.Value;
            _clsAdministrative.StartDate = dtpStartDate.Value;
            _clsAdministrative.EmployeeID = tbEmployeeID.Text.Trim();
            _clsAdministrative.DateOfIssueOfTheID = dtpDateOfIssueOfTheID.Value;
            _clsAdministrative.PlaceOfBirth = tbPlaceOfBirth.Text.Trim();
            _clsAdministrative.RankID = cbRank.SelectedIndex + 1;/////////////
            _clsAdministrative.bloodType = tbBloodType.Text.Trim();
            _clsAdministrative.dateOfLastPromotion = dtpdateOfLastPromotion.Value;
            _clsAdministrative.IDNumber = tbIDNumber.Text.Trim();
            _clsAdministrative.UnifiedNumber = tbUnifiedNumber.Text.Trim();
            _clsAdministrative.Seniority = tbSeniority.Text.Trim();

            /////// 

            if (_clsAdministrative.UnitName != tbCurrentUnit.Text && _Mode == _enMode.Update)
            {
                string PreviousUnit = _clsAdministrative.UnitName;
                _clsAdministrative.UnitName = tbCurrentUnit.Text;
                _clsAdministrative.UnitProcessingOperations(PreviousUnit);
                lblPreviousUnit.Text = PreviousUnit;
            }
            else
            {
                _clsAdministrative.UnitName = tbCurrentUnit.Text.Trim();
            }
            _clsAdministrative.BonusStartDate = _CalculateBonusStartDate();
        }
        private void _LoadCards()//Add New
        {
            _clsSocial.AddCard(tbCardNumberForResidence.Text.Trim(), dtpIssueDateForResidence.Value, tbIssuingAuthorityForResidence.Text.Trim(), clsSocial._enCardType.Residence);
            _clsSocial.AddCard(tbCardNumberForUnified.Text.Trim(), dtpIssueDateForUnified.Value, tbIssuingAuthorityForUnified.Text.Trim(), clsSocial._enCardType.Unified);

            if (!string.IsNullOrEmpty(tbCardNumberForVoterID.Text.Trim()) && !string.IsNullOrEmpty(tbIssuingAuthorityForVoterID.Text.Trim()))
            {
                _clsSocial.AddCard(tbCardNumberForVoterID.Text.Trim(),
                    dtpIssueDateForResidence.Value,
                    tbIssuingAuthorityForVoterID.Text.Trim(), clsSocial._enCardType.VoterID);
            }
        }
        private void _LoadChildrens()//Add New
        {
            if (!string.IsNullOrEmpty(tbNameChildren1.Text.Trim()) && !string.IsNullOrEmpty(tbProfessionChildren1.Text.Trim()))
            {
                _clsSocial.AddChildren(tbNameChildren1.Text.Trim(), dtpDateOfBirthOfChildren1.Value, tbProfessionChildren1.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbNameChildren2.Text.Trim()) && !string.IsNullOrEmpty(tbProfessionChildren2.Text.Trim()))
            {
                _clsSocial.AddChildren(tbNameChildren2.Text.Trim(), dtpDateOfBirthOfChildren2.Value, tbProfessionChildren2.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbNameChildren3.Text.Trim()) && !string.IsNullOrEmpty(tbProfessionChildren3.Text.Trim()))
            {
                _clsSocial.AddChildren(tbNameChildren3.Text.Trim(), dtpDateOfBirthOfChildren3.Value, tbProfessionChildren3.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbNameChildren4.Text.Trim()) && !string.IsNullOrEmpty(tbProfessionChildren4.Text.Trim()))
            {
                _clsSocial.AddChildren(tbNameChildren4.Text.Trim(), dtpDateOfBirthOfChildren4.Value, tbProfessionChildren4.Text.Trim());
            }
        }
        private void _LoadDataToObjectSocial()//Add New
        {
            
            _clsSocial.MaritalStatus = tbMaritalStatus.Text.Trim();
            int NumberOfChildren = 0;
            _clsSocial.NumberOfChildren = (int.TryParse(tbNumberOfChildren.Text.Trim(), out NumberOfChildren)) ? NumberOfChildren : 0;
            //if (int.TryParse(tbNumberOfChildren.Text.Trim(),out NumberOfChildren))
            //{
            //        _clsSocial.NumberOfChildren = NumberOfChildren;
            //}
            //else
            //    _clsSocial.NumberOfChildren = NumberOfChildren;
            _clsSocial.politicians = tbPoliticians.Text.Trim();
            _clsSocial.martyrs = tbmartyrs.Text.Trim();
            _clsSocial.PreviousResidence = tbPreviousResidence.Text.Trim();
            _clsSocial.CurrentResidence = tbCurrentResidence.Text.Trim();
            _clsSocial.NearestKnownPointToCurrentResidence = tbNearestKnownPointToCurrentResidence.Text.Trim();
            _clsSocial.ChosenName = tbChosenName.Text.Trim();
            _clsSocial.PhoneNumber = tbPhoneNumber.Text.Trim();
            _clsSocial.Religion = tbReligion.Text.Trim();
            _clsSocial.Nationalism = tbNationalism.Text.Trim();
            _clsSocial.WifesName = tbWifesName.Text.Trim();
            _clsSocial.WifesOccupation = tbWifesOccupation.Text.Trim();
            _clsSocial.WifesBirth = dtpWifesBirth.Value;


            _LoadCards();
            _LoadChildrens();

        }
        private void _LoadDataToObjectScientific()//Add New
        {
            _clsScientific.PrimarySchoolCertificateInformation = tbPrimarySchoolCertificateInformation.Text.Trim();
            _clsScientific.InformationAboutTheIntermediateCertificate = tbInformationAboutTheIntermediateCertificate.Text.Trim();
            _clsScientific.InformationAboutPreparatoryCertificate = tbInformationAboutPreparatoryCertificate.Text.Trim();
            _clsScientific.InformationAboutInstituteCertificate = tbInformationAboutInstituteCertificate.Text.Trim();
            _clsScientific.CollegeCertificateInformation = tbCollegeCertificateInformation.Text.Trim();
            _clsScientific.InformationAboutBasicCourse = tbInformationAboutBasicCourse.Text.Trim();
            _clsScientific.InformationAboutOtherCourses = tbInformationAboutOtherCourses.Text.Trim();
            _clsScientific.InformationAboutHigherDegrees = tbInformationAboutHigherDegrees.Text.Trim();
        }
        private void _LoadDataToObjectAcknowledgments()//Add New
        {
            _clsLegal.NewList = true; // reset List
            if (!string.IsNullOrEmpty(tbAcknowledgments1.Text.Trim()))
            {
                _clsLegal.AddAcknowledgments(tbAcknowledgments1.Text.Trim(), 1);
            }
            if (!string.IsNullOrEmpty(tbAcknowledgments2.Text.Trim()))
            {
                _clsLegal.AddAcknowledgments(tbAcknowledgments2.Text.Trim(), 2);
            }
            if (!string.IsNullOrEmpty(tbAcknowledgments3.Text.Trim()))
            {
                _clsLegal.AddAcknowledgments(tbAcknowledgments3.Text.Trim(), 3);
            }
            if (!string.IsNullOrEmpty(tbAcknowledgments4.Text.Trim()))
            {
                _clsLegal.AddAcknowledgments(tbAcknowledgments4.Text.Trim(), 4);
            }
            if (!string.IsNullOrEmpty(tbAcknowledgments5.Text.Trim()))
            {
                _clsLegal.AddAcknowledgments(tbAcknowledgments5.Text.Trim(), 5);
            }
        }
        private void _LoadDataToObjectLegal()//Add New
        {
            _clsLegal.InvestigativeCouncils = tbInvestigativeCouncils.Text.Trim();
            _clsLegal.Sanctions = tbSanctions.Text.Trim();
            _clsLegal.Entitlements = tbEntitlements.Text.Trim();
            _clsLegal.AcademicVacations = tbAcademicVacations.Text.Trim();
            _clsLegal.Injuries = tbInjuries.Text.Trim();
            _clsLegal.SickLeave = tbSickLeave.Text.Trim();
            _clsLegal.TouristVacations = tbTouristVacations.Text.Trim();
            _clsLegal.ReligiousHolidays = tbReligiousHolidays.Text.Trim();
            _clsLegal.Notes = tbNotes.Text.Trim();

            _LoadDataToObjectAcknowledgments();
        }
        private void _LoadDataToObjectServiceDetails()//Add New
        {
            _clsServiceDetails.ImagePath = pbImage.ImageLocation.ToString();
            _clsServiceDetails.PromotionOrders = tbPromotionOrders.Text.Trim();
            _clsServiceDetails.CriminalRestrictions = tbCriminalRestrictions.Text.Trim();
            _clsServiceDetails.Guarantees = tbGuarantees.Text.Trim();
            _clsServiceDetails.AnnualBonusOrders = tbAnnualBonusOrders.Text.Trim();
            _clsServiceDetails.Variables = tbVariables.Text.Trim();
            _clsServiceDetails.ServiceEvaluationByUnits = tbServiceEvaluationByUnits.Text.Trim();
            _clsServiceDetails.Notes = tbNotes.Text.Trim();
        }
        private void _LoadDataToObject()//Add New
        {
            //Load info Person
            _clsPerson.FullName = tbFullName.Text;
            _clsPerson.StatisticalNumber = tbStatisticalNumber.Text;

            _LoadDataToObjectAdministrative();
            _LoadDataToObjectSocial();
            _LoadDataToObjectScientific();
            _LoadDataToObjectLegal();
            _LoadDataToObjectServiceDetails();
        }


        //Load to Control 
        private void _LoadCardsToControl()
        {
            DataTable dataTable = _clsSocial.GetAllCardsInfo();
            foreach (DataRow row in dataTable.Rows)
            {
                switch ((clsSocial._enCardType)(byte)row["CardType"])
                {
                    case clsSocial._enCardType.Residence:
                        tbCardNumberForResidence.Text = row["CardNumber"].ToString();
                        tbIssuingAuthorityForResidence.Text = row["IssuingAuthority"].ToString();
                        dtpIssueDateForResidence.Value = (DateTime)row["IssueDate"];
                        break;
                    case clsSocial._enCardType.Unified:
                        tbCardNumberForUnified.Text = row["CardNumber"].ToString();
                        tbIssuingAuthorityForUnified.Text = row["IssuingAuthority"].ToString();
                        dtpIssueDateForUnified.Value = (DateTime)row["IssueDate"];
                        break;
                    case clsSocial._enCardType.VoterID:
                        tbCardNumberForVoterID.Text = row["CardNumber"].ToString();
                        tbIssuingAuthorityForVoterID.Text = row["IssuingAuthority"].ToString();
                        dtpIssueDateForVoterID.Value = (DateTime)row["IssueDate"];
                        break;
                    default:
                        break;
                }
            }
        }
        private void _LoadChildrensToControl()//Mode Update
        {
            DataTable dataTable = _clsSocial.GetAllChildrens();
            byte CountRow = (byte)dataTable.Rows.Count;
            if (CountRow > 0)
            {
                DataRow dataRow;
                {
                    dataRow = dataTable.Rows[0];
                    tbNameChildren1.Text = dataRow["FullName"].ToString();
                    tbProfessionChildren1.Text = dataRow["Profession"].ToString();
                    dtpDateOfBirthOfChildren1.Value = (DateTime)dataRow["DateOfBirth"];
                }
                if (CountRow >= 2)
                {
                    dataRow = dataTable.Rows[1];

                    tbNameChildren2.Text = dataRow["FullName"].ToString();
                    tbProfessionChildren2.Text = dataRow["Profession"].ToString();
                    dtpDateOfBirthOfChildren2.Value = (DateTime)dataRow["DateOfBirth"];
                }
                else
                    return;

                if (CountRow >= 3)
                {
                    dataRow = dataTable.Rows[2];

                    tbNameChildren3.Text = dataRow["FullName"].ToString();
                    tbProfessionChildren3.Text = dataRow["Profession"].ToString();
                    dtpDateOfBirthOfChildren3.Value = (DateTime)dataRow["DateOfBirth"];
                }
                else
                    return;
                if (CountRow >= 4)
                {
                    dataRow = dataTable.Rows[3];

                    tbNameChildren4.Text = dataRow["FullName"].ToString();
                    tbProfessionChildren4.Text = dataRow["Profession"].ToString();
                    dtpDateOfBirthOfChildren4.Value = (DateTime)dataRow["DateOfBirth"];
                }

            }
        }
        private void _LoadAdministrative()//Mode Update
        {
            _clsAdministrative = clsAdministrative.Find(_clsPerson.AdministrativeID);
            if (_clsAdministrative != null)
            {
                tbSurname.Text = _clsAdministrative.Surname;
                dtpDateOfBirth.Value = _clsAdministrative.DateOfBirth;
                tbMotherFullName.Text = _clsAdministrative.MotherFullName;
                dtpOrderForAppointment.Value = _clsAdministrative.DateOfTheAdministrativeOrderForAppointment;
                dtpHistoryOfTheDiwaniOrder.Value = _clsAdministrative.HistoryOfTheDiwaniOrder;
                dtpStartDate.Value = _clsAdministrative.StartDate;
                tbEmployeeID.Text = _clsAdministrative.EmployeeID;
                dtpDateOfIssueOfTheID.Value = _clsAdministrative.DateOfIssueOfTheID;
                tbPlaceOfBirth.Text = _clsAdministrative.PlaceOfBirth;
                cbRank.SelectedIndex = _clsAdministrative.RankID - 1;
                tbBloodType.Text = _clsAdministrative.bloodType;
                dtpdateOfLastPromotion.Value = _clsAdministrative.dateOfLastPromotion;
                tbIDNumber.Text = _clsAdministrative.IDNumber;
                tbUnifiedNumber.Text = _clsAdministrative.UnifiedNumber;
                tbSeniority.Text = _clsAdministrative.Seniority;
                ///////

                tbCurrentUnit.Text = _clsAdministrative.UnitName;
                string PreviousUnit = null;
                if ((PreviousUnit = _clsAdministrative.GetLastPreviousUnit()) != null)
                {
                    lblPreviousUnit.Text = PreviousUnit;
                }
            }
            else
            {

                MessageBox.Show("خطأ في تحميل البيانات ", "Error in Administrative", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void _LoadSocial()//Mode Update
        {
            _clsSocial = clsSocial.Find(_clsPerson.SocialID);
            if (_clsSocial != null)
            {
                tbMaritalStatus.Text = _clsSocial.MaritalStatus;
                tbNumberOfChildren.Text = _clsSocial.NumberOfChildren.ToString();
                tbPoliticians.Text = _clsSocial.politicians;
                tbmartyrs.Text = _clsSocial.martyrs;
                tbPreviousResidence.Text = _clsSocial.PreviousResidence;
                tbCurrentResidence.Text = _clsSocial.CurrentResidence;
                tbNearestKnownPointToCurrentResidence.Text = _clsSocial.NearestKnownPointToCurrentResidence;
                tbChosenName.Text = _clsSocial.ChosenName;
                tbPhoneNumber.Text = _clsSocial.PhoneNumber;
                tbReligion.Text = _clsSocial.Religion;
                tbNationalism.Text = _clsSocial.Nationalism;
                tbWifesName.Text = _clsSocial.WifesName;
                tbWifesOccupation.Text = _clsSocial.WifesOccupation;
                dtpWifesBirth.Value = _clsSocial.WifesBirth;

                _LoadChildrensToControl();
                _LoadCardsToControl();
            }
            else
            {

                MessageBox.Show("خطأ في تحميل البيانات ", "Error in Social", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void _LoadScientific()//Mode Update
        {
            _clsScientific = clsScientific.Find(_clsPerson.scientificID);
            if (_clsScientific != null)
            {
                tbPrimarySchoolCertificateInformation.Text = _clsScientific.PrimarySchoolCertificateInformation;
                tbInformationAboutTheIntermediateCertificate.Text = _clsScientific.InformationAboutTheIntermediateCertificate;
                tbInformationAboutPreparatoryCertificate.Text = _clsScientific.InformationAboutPreparatoryCertificate;
                tbInformationAboutInstituteCertificate.Text = _clsScientific.InformationAboutInstituteCertificate;
                tbCollegeCertificateInformation.Text = _clsScientific.CollegeCertificateInformation;
                tbInformationAboutBasicCourse.Text = _clsScientific.InformationAboutBasicCourse;
                tbInformationAboutOtherCourses.Text = _clsScientific.InformationAboutOtherCourses;
                tbInformationAboutHigherDegrees.Text = _clsScientific.InformationAboutHigherDegrees;
            }
            else
            {

                MessageBox.Show("خطأ في تحميل البيانات ", "Error in scientific", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void _LoadLegal()//Mode Update
        {
            _clsLegal = clsLegal.Find(_clsPerson.legalID);
            if (_clsLegal != null)
            {
                tbInvestigativeCouncils.Text = _clsLegal.InvestigativeCouncils;
                tbSanctions.Text = _clsLegal.Sanctions;
                tbEntitlements.Text = _clsLegal.Entitlements;
                tbAcademicVacations.Text = _clsLegal.AcademicVacations;
                tbInjuries.Text = _clsLegal.Injuries;
                tbSickLeave.Text = _clsLegal.SickLeave;
                tbTouristVacations.Text = _clsLegal.TouristVacations;
                tbReligiousHolidays.Text = _clsLegal.ReligiousHolidays;
                tbNotes.Text = _clsLegal.Notes;
                if (_clsLegal.ListAcknowledgments.Count > 0)
                {
                    tbAcknowledgments1.Text = _clsLegal.ListAcknowledgments[0].Acknowledgments;
                }
                if (_clsLegal.ListAcknowledgments.Count > 1)
                {
                    tbAcknowledgments2.Text = _clsLegal.ListAcknowledgments[1].Acknowledgments;
                }
                if (_clsLegal.ListAcknowledgments.Count > 2)
                {
                    tbAcknowledgments3.Text = _clsLegal.ListAcknowledgments[2].Acknowledgments;
                }
                if (_clsLegal.ListAcknowledgments.Count > 3)
                {
                    tbAcknowledgments4.Text = _clsLegal.ListAcknowledgments[3].Acknowledgments;
                }
                if (_clsLegal.ListAcknowledgments.Count > 4)
                {
                    tbAcknowledgments5.Text = _clsLegal.ListAcknowledgments[4].Acknowledgments;
                }

            }
            else
            {

                MessageBox.Show("خطأ في تحميل البيانات ", "Error in Legal", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void _LoadServiceDetails()//Mode Update
        {
            _clsServiceDetails = clsServiceDetails.Find(_clsPerson.ServiceDetailsID);
            if (_clsServiceDetails != null)
            {
                pbImage.ImageLocation = _clsServiceDetails.ImagePath;
                tbPromotionOrders.Text = _clsServiceDetails.PromotionOrders;
                tbCriminalRestrictions.Text = _clsServiceDetails.CriminalRestrictions;
                tbGuarantees.Text = _clsServiceDetails.Guarantees;
                tbAnnualBonusOrders.Text = _clsServiceDetails.AnnualBonusOrders;
                tbVariables.Text = _clsServiceDetails.Variables;
                tbServiceEvaluationByUnits.Text = _clsServiceDetails.ServiceEvaluationByUnits;
                tbNotes.Text = _clsServiceDetails.Notes;
                //Load Units
                {
                    dgvAllUnits.DataSource = _clsAdministrative.AllUnits;
                }
            }
            else
            {

                MessageBox.Show("خطأ في تحميل البيانات ", "Error in Service Details", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void _LoadData()//Mode Update
        {
            _clsPerson = clsPerson.FindByPersonID(_PersonID);
            if (_clsPerson == null)
            {
                MessageBox.Show("خطأ في تحميل البيانات ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Load info Person
            tbFullName.Text = _clsPerson.FullName;
            tbStatisticalNumber.Text = _clsPerson.StatisticalNumber;

            _LoadAdministrative();
            _LoadSocial();
            _LoadScientific();
            _LoadLegal();
            _LoadServiceDetails();

        }


        //save all components
        private bool _Save()
        {
            if (!_clsAdministrative.Save())
                return false;
            if (!_clsSocial.Save())
                return false;
            if (!_clsScientific.Save())
                return false;
            if (!_clsLegal.Save())
                return false;
            if (!_clsServiceDetails.Save())
                return false;
            _clsPerson.AdministrativeID = _clsAdministrative.AdministrativeID;
            _clsPerson.SocialID = _clsSocial.socialID;
            _clsPerson.scientificID = _clsScientific.ScientificID;
            _clsPerson.legalID = _clsLegal.LegalID;
            _clsPerson.ServiceDetailsID = _clsServiceDetails.ServiceDetailsID;
            return _clsPerson.Save();
        }

        private void tbIDNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        private void lilChooseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = open.FileName;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!this.ValidateChildren())
            {
                MessageBox.Show("تحقق من البيانات المدخلة و البيانات التي يجب ادخالها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("هل تريد الحفظ ؟", "حفظ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frmAuthenticationKey key = new frmAuthenticationKey();
                key.ShowDialog();
                if (key.DialogResult != DialogResult.OK)
                {

                    MessageBox.Show("لم يتم الحفظ بسبب مفتاح المصادقة غير صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!_HandleImage())
                {
                    return;
                }
                _LoadDataToObject();
                if (_Save())
                {
                    MessageBox.Show("تم الحفظ بنجاح");
                    _Mode = _enMode.Update;
                    btnDeletePerson.Visible = true;
                    IsSave = true;
                }
                else
                {
                    MessageBox.Show("لم يتم الحفظ");

                }
            }
            else
            {
                MessageBox.Show("تم الغاء الحفظ");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dtpWifesBirth.Value = DateTime.MinValue.AddYears(1753);
            dtpIssueDateForVoterID.Value = DateTime.MinValue.AddYears(1753);

            _ResetDefulteValue();
            if (_Mode == _enMode.Update)
            {
                btnDeletePerson.Visible = true;
                _LoadData();
            }

        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المنتسب ؟", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                frmAuthenticationKey key = new frmAuthenticationKey();
                key.ShowDialog();
                if (key.DialogResult != DialogResult.OK)
                {

                    MessageBox.Show("لم يتم الحذف بسبب مفتاح المصادقة غير صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_clsPerson.DeletePerson())
                {
                    MessageBox.Show("تم الحذف بنجاح");
                    IsDeleted = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لم يتم الحذف ");

                }
            }
            else
            {
                MessageBox.Show("تم الغاء الحذف");
            }

        }

        private void tbFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbMotherFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbStatisticalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbUnifiedNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbMaritalStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbNumberOfChildren_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbCardNumberForResidence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbCardNumberForUnified_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbCardNumberForVoterID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbStatisticalNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Mode == _enMode.Update)
            {
                return;
            }
            if (clsPerson.IsExistStatisticalNumber(tbStatisticalNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbStatisticalNumber, "هذا الرقم الاحصائي مستخدم");
            }
            else
            {
                errorProvider.SetError(tbStatisticalNumber, null);
            }
        }

        private void tbSurname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSurname.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbSurname, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbSurname, null);
            }
        }

        private void tbMotherFullName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMotherFullName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbMotherFullName, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbMotherFullName, null);
            }
        }

        private void tbEmployeeID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmployeeID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbEmployeeID, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbEmployeeID, null);
            }
        }

        private void tbCurrentUnit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentUnit.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbCurrentUnit, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbCurrentUnit, null);
            }
        }

        private void tbPlaceOfBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPlaceOfBirth.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbPlaceOfBirth, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbPlaceOfBirth, null);
            }
        }

        private void tbBloodType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbBloodType.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbBloodType, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbBloodType, null);
            }
        }

        private void tbIDNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbIDNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbIDNumber, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbIDNumber, null);
            }
        }

        private void tbUnifiedNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUnifiedNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbUnifiedNumber, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbUnifiedNumber, null);
            }
        }

        private void tbMaritalStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMaritalStatus.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbMaritalStatus, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbMaritalStatus, null);
            }
        }

        private void tbCurrentResidence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentResidence.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbCurrentResidence, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbCurrentResidence, null);
            }
        }

        private void tbNearestKnownPointToCurrentResidence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNearestKnownPointToCurrentResidence.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbNearestKnownPointToCurrentResidence, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbNearestKnownPointToCurrentResidence, null);
            }
        }

        private void tbChosenName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbChosenName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbChosenName, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbChosenName, null);
            }
        }

        private void tbPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbPhoneNumber, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbPhoneNumber, null);
            }
        }

        private void tbCardNumberForResidence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCardNumberForResidence.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbCardNumberForResidence, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbCardNumberForResidence, null);
            }
        }

        private void tbIssuingAuthorityForResidence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbIssuingAuthorityForResidence.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbIssuingAuthorityForResidence, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbIssuingAuthorityForResidence, null);
            }
        }

        private void tbCardNumberForUnified_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCardNumberForUnified.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbCardNumberForUnified, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbCardNumberForUnified, null);
            }
        }

        private void tbIssuingAuthorityForUnified_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbIssuingAuthorityForUnified.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbIssuingAuthorityForUnified, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbIssuingAuthorityForUnified, null);
            }
        }

        private void pbImage_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(pbImage.ImageLocation.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(pbImage, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(pbImage, null);
            }
        }

        private void tbFullName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFullName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(tbFullName, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider.SetError(tbFullName, null);
            }
        }
    }
}
