using PAMSMU_Data;
using System.Collections.Generic;

namespace PAMSMU_Business
{
    public class clsLegal
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;
        private clsAcknowledgments _clsAcknowledgments;
        public clsLegal()
        {
            _Mode = _enMode.AddNew;
            ListAcknowledgments = new List<clsAcknowledgments>();
        }

        private clsLegal(int legalID, string investigativeCouncils, string sanctions, string entitlements,
            string academicVacations, string injuries, string sickLeave, string touristVacations,
            string religiousHolidays, string notes, List<clsAcknowledgments> Acknowledgments)
        {
            _Mode = _enMode.Update;
            ListAcknowledgments = new List<clsAcknowledgments>();
            ListAcknowledgments = Acknowledgments;

            LegalID = legalID;
            InvestigativeCouncils = investigativeCouncils;
            Sanctions = sanctions;
            Entitlements = entitlements;
            AcademicVacations = academicVacations;
            Injuries = injuries;
            SickLeave = sickLeave;
            TouristVacations = touristVacations;
            ReligiousHolidays = religiousHolidays;
            Notes = notes;
        }

        public bool NewList
        {
            set
            {
                if (value)
                {
                    ListAcknowledgments = new List<clsAcknowledgments>();
                }
            }
        }
        public int LegalID { get; set; }
        public string InvestigativeCouncils { get; set; }
        public string Sanctions { get; set; }
        public string Entitlements { get; set; }
        public string AcademicVacations { get; set; }
        public string Injuries { get; set; }
        public string SickLeave { get; set; }
        public string TouristVacations { get; set; }
        public string ReligiousHolidays { get; set; }
        public string Notes { get; set; }
        public List<clsAcknowledgments> ListAcknowledgments;
        public static clsLegal Find(int LegalID)
        {
            List<clsAcknowledgments> acknowledgments = new List<clsAcknowledgments>();

            string InvestigativeCouncils = string.Empty, Sanctions = string.Empty, Entitlements = string.Empty,
                AcademicVacations = string.Empty, Injuries = string.Empty, SickLeave = string.Empty,
                TouristVacations = string.Empty, ReligiousHolidays = string.Empty, Notes = string.Empty;


            if (LegalData.GetInfoLegal(LegalID, ref InvestigativeCouncils, ref Sanctions, ref Entitlements, ref AcademicVacations, ref Injuries, ref SickLeave, ref TouristVacations, ref ReligiousHolidays, ref Notes))
            {
                acknowledgments = _FindAllAcknowledgments(LegalID);
                {
                    return new clsLegal(LegalID, InvestigativeCouncils, Sanctions, Entitlements, AcademicVacations, Injuries, SickLeave, TouristVacations, ReligiousHolidays, Notes, acknowledgments);

                }
            }
            return null;
        }

        private bool _AddNew()
        {
            bool Result = (this.LegalID = LegalData.AddNewLegal(InvestigativeCouncils, Sanctions, Entitlements, AcademicVacations, Injuries, SickLeave, TouristVacations, ReligiousHolidays, Notes)) > -1;

            if (Result)
            {
                Result = _SaveAcknowledgments();
            }
            return Result;
        }
        private bool _Update()
        {
            bool Result = LegalData.UpdateLegal(LegalID, InvestigativeCouncils, Sanctions, Entitlements, AcademicVacations, Injuries, SickLeave, TouristVacations, ReligiousHolidays, Notes);
            if (Result)
            {
                Result = _SaveAcknowledgments();
            }
            return Result;
        }

        private static List<clsAcknowledgments> _FindAllAcknowledgments(int LegalID)
        {
            //implementation  Count Acknowledgments
            List<clsAcknowledgments> acknowledgments = new List<clsAcknowledgments>();
            for (byte AcknowledgmentsNumber = 1; AcknowledgmentsNumber <= 5; AcknowledgmentsNumber++)
            {
                clsAcknowledgments _clsAcknowledgments = clsAcknowledgments.Find(LegalID, AcknowledgmentsNumber);
                if (_clsAcknowledgments != null)
                {
                    acknowledgments.Add(_clsAcknowledgments);
                }
            }
            return acknowledgments;
        }
        private bool _SaveAcknowledgments()
        {
            if (_Mode == _enMode.Update)
            {
                clsAcknowledgments.DeleteAllAcknowledgments(LegalID);
            }
            foreach (clsAcknowledgments item in ListAcknowledgments)
            {
                item.legalID = this.LegalID;
                if (!item.Save())
                {
                    return false;
                }
            }
            return true;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    return false;
                case _enMode.Update:
                    return _Update();
            }
            return false;
        }

        public void AddAcknowledgments(string Acknowledgments, byte AcknowledgmentsNumber)
        {
            _clsAcknowledgments = new clsAcknowledgments();
            _clsAcknowledgments.Acknowledgments = Acknowledgments;
            _clsAcknowledgments.AcknowledgmentsNumber = AcknowledgmentsNumber;
            ListAcknowledgments.Add(_clsAcknowledgments);
        }
    }
}
