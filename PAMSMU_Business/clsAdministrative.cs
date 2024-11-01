using PAMSMU_Data;
using System;
using System.Data;

namespace PAMSMU_Business
{
    public class clsAdministrative
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;

        public int AdministrativeID { get; set; }

        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MotherFullName { get; set; }
        public DateTime DateOfTheAdministrativeOrderForAppointment { get; set; }
        public DateTime HistoryOfTheDiwaniOrder { get; set; }
        public DateTime StartDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public int RankID { get; set; }
        public DateTime BonusStartDate { get; set; }
        public string EmployeeID { get; set; }
        public string UnifiedNumber { get; set; }
        public string bloodType { get; set; }
        public DateTime dateOfLastPromotion { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfIssueOfTheID { get; set; }
        public string Seniority { get; set; }
        /// /
        public int UnitsID { get; set; }
        public string UnitName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime DepartureDate { get; set; }

        public clsRank RankInfo  = new clsRank();
        public DataTable AllUnits { get; private set; }
        public clsAdministrative()
        {
            _Mode = _enMode.AddNew;

            UnitName = string.Empty;
            DateOfJoin = DateTime.Now;
            DepartureDate = DateTime.Now;
            BonusStartDate= DateTime.Now;
            AdministrativeID = -1;
            Surname = string.Empty;
            DateOfBirth = DateTime.MinValue;
            MotherFullName = "";
            DateOfTheAdministrativeOrderForAppointment = DateTime.MinValue;
            HistoryOfTheDiwaniOrder = DateTime.MinValue;
            StartDate = DateTime.MinValue;
            PlaceOfBirth = string.Empty;
            RankID = -1;
            EmployeeID = string.Empty;
            UnifiedNumber = string.Empty;
            bloodType = string.Empty;
            dateOfLastPromotion = DateTime.MinValue;
            IDNumber = string.Empty;
            DateOfIssueOfTheID = DateTime.MinValue;
            Seniority = string.Empty;
        }

        private clsAdministrative(int administrativeID, string surname, DateTime dateOfBirth,
            string motherFullName, DateTime dateOfTheAdministrativeOrderForAppointment,
            DateTime historyOfTheDiwaniOrder, DateTime startDate, string placeOfBirth,
            int rankID, string employeeID, string unifiedNumber,
            string bloodType, DateTime dateOfLastPromotion, string iDNumber, DateTime dateOfIssueOfTheID,
            string seniority, int unitsID, string unitName, DateTime dateOfJoin, DateTime departureDate, DataTable AllUnits)
        {
            _Mode = _enMode.Update;
            AdministrativeID = administrativeID;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            MotherFullName = motherFullName;
            DateOfTheAdministrativeOrderForAppointment = dateOfTheAdministrativeOrderForAppointment;
            HistoryOfTheDiwaniOrder = historyOfTheDiwaniOrder;
            StartDate = startDate;
            PlaceOfBirth = placeOfBirth;
            RankID = rankID;
            EmployeeID = employeeID;
            UnifiedNumber = unifiedNumber;
            this.bloodType = bloodType;
            this.dateOfLastPromotion = dateOfLastPromotion;
            IDNumber = iDNumber;
            DateOfIssueOfTheID = dateOfIssueOfTheID;
            Seniority = seniority;
            UnitsID = unitsID;
            UnitName = unitName;
            DateOfJoin = dateOfJoin;
            DepartureDate = departureDate;
            this.AllUnits = new DataTable();
            this.AllUnits = AllUnits;
        }

        public static clsAdministrative Find(int AdministrativeID)
        {
            bool IsFound = false;
            int UnitsID = 0, RankID = -1;
            string Surname = string.Empty, MotherFullName = string.Empty, PlaceOfBirth = string.Empty,
                EmployeeID = string.Empty, UnifiedNumber = string.Empty,
                bloodType = string.Empty, IDNumber = string.Empty, Seniority = string.Empty, UnitName = string.Empty;
            DateTime DateOfBirth = DateTime.Now, DateOfTheAdministrativeOrderForAppointment = DateTime.Now,
                HistoryOfTheDiwaniOrder = DateTime.Now, StartDate = DateTime.Now, dateOfLastPromotion = DateTime.Now,
                DateOfIssueOfTheID = DateTime.Now, DateOfJoin = DateTime.Now, DepartureDate = DateTime.Now;
            DataTable AllUnits = new DataTable();
            IsFound = AdministrativeData.GetInfoAdministrative(AdministrativeID, ref Surname, ref DateOfBirth, ref MotherFullName, ref DateOfTheAdministrativeOrderForAppointment, ref HistoryOfTheDiwaniOrder, ref StartDate, ref PlaceOfBirth, ref RankID, ref EmployeeID, ref UnifiedNumber, ref bloodType, ref dateOfLastPromotion, ref IDNumber, ref DateOfIssueOfTheID, ref Seniority);

            if (IsFound)
            {
                if ((AllUnits = AdministrativeData.GetAllUnit(AdministrativeID)) == null)
                {
                    return null;
                }
                if (AdministrativeData.GetInfoUnits(ref UnitsID, AdministrativeID, ref UnitName, ref DateOfJoin, ref DepartureDate))
                {
                    return new clsAdministrative(AdministrativeID, Surname, DateOfBirth, MotherFullName, DateOfTheAdministrativeOrderForAppointment, HistoryOfTheDiwaniOrder, StartDate, PlaceOfBirth, RankID, EmployeeID, UnifiedNumber, bloodType, dateOfLastPromotion, IDNumber, DateOfIssueOfTheID, Seniority, UnitsID, UnitName, DateOfJoin, DepartureDate, AllUnits);
                }
            }
            return null;
        }
        private bool _AddNew()
        {
            bool Result = false;
            Result = (this.AdministrativeID = AdministrativeData.AddNewAdministrative(Surname, DateOfBirth,
                MotherFullName, DateOfTheAdministrativeOrderForAppointment, HistoryOfTheDiwaniOrder,
                StartDate, PlaceOfBirth, RankID, EmployeeID, UnifiedNumber, bloodType, dateOfLastPromotion,
                IDNumber, DateOfIssueOfTheID, Seniority, BonusStartDate)) > -1;
            if (Result)
            {
                Result = (this.UnitsID = AdministrativeData.AddNewUnits(AdministrativeID, UnitName, DateOfJoin, DepartureDate)) > -1;
            }
            return Result;
        }

        private bool _Update()
        {
            bool Result = false;
            Result = AdministrativeData.UpdateAdministrative(AdministrativeID, Surname, DateOfBirth,
                MotherFullName, DateOfTheAdministrativeOrderForAppointment, HistoryOfTheDiwaniOrder,
                StartDate, PlaceOfBirth, RankID, EmployeeID, UnifiedNumber, bloodType, dateOfLastPromotion,
                IDNumber, DateOfIssueOfTheID, Seniority, BonusStartDate);
            //if (Result)
            //{
            //    Result = (this.UnitsID = AdministrativeData.AddNewUnits(AdministrativeID, UnitName, DateOfJoin, DepartureDate)) > -1;
            //}
            return Result;
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
        public bool UnitProcessingOperations(string PreviousUnit)
        {
            bool Result = false;
            Result = AdministrativeData.UpdateUnit(UnitsID, AdministrativeID, PreviousUnit, DateOfJoin, DateTime.Now, false);
            if (Result)
            {
                Result = (this.UnitsID = AdministrativeData.AddNewUnits(AdministrativeID, UnitName, DateTime.Now, DateTime.Now)) > -1;
            }
            return Result;
        }
        public string GetLastPreviousUnit()
        {
            return AdministrativeData.GetLastPreviousUnit(AdministrativeID);
        }

    }
}
