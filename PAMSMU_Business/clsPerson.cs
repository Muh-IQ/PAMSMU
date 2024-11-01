using PAMSMU_Data;

namespace PAMSMU_Business
{
    public class clsPerson
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;

        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string StatisticalNumber { get; set; }
        public int AdministrativeID { get; set; }
        public int SocialID { get; set; }
        public int scientificID { get; set; }
        public int legalID { get; set; }
        public int ServiceDetailsID { get; set; }

        private clsPerson(int PersonID, string fullName, string statisticalNumber, int administrativeID, int socialID,
            int scientificID, int legalID, int serviceDetailsID)
        {
            this.PersonID = PersonID;
            FullName = fullName;
            StatisticalNumber = statisticalNumber;
            AdministrativeID = administrativeID;
            SocialID = socialID;
            this.scientificID = scientificID;
            this.legalID = legalID;
            ServiceDetailsID = serviceDetailsID;

            _Mode = _enMode.Update;
        }

        public clsPerson()
        {
            _Mode = _enMode.AddNew;

        }

        public static clsPerson FindByName(string name)
        {
            string StatisticalNumber = string.Empty;
            int AdministrativeID = 0, SocialID = 0, scientificID = 0, legalID = 0, serviceDetailsID = 0, PersonID = 0;

            if (PersonData.GetInfoPersonByFullName(ref PersonID, name, ref StatisticalNumber, ref AdministrativeID, ref SocialID, ref scientificID, ref legalID, ref serviceDetailsID))
            {
                return new clsPerson(PersonID, name, StatisticalNumber, AdministrativeID, SocialID, scientificID, legalID, serviceDetailsID);
            }

            return null;
        }
        public static clsPerson FindByPersonID(int PersonID)
        {
            string fullName = string.Empty, StatisticalNumber = string.Empty;
            int AdministrativeID = 0, SocialID = 0, scientificID = 0, legalID = 0, serviceDetailsID = 0;

            if (PersonData.GetInfoPersonByPersonID(PersonID, ref fullName, ref StatisticalNumber, ref AdministrativeID, ref SocialID, ref scientificID, ref legalID, ref serviceDetailsID))
            {
                return new clsPerson(PersonID, fullName, StatisticalNumber, AdministrativeID, SocialID, scientificID, legalID, serviceDetailsID);
            }

            return null;
        }

        public static clsPerson FindByStatisticalNumber(string StatisticalNumber)
        {
            string fullName = string.Empty;
            int AdministrativeID = 0, SocialID = 0, scientificID = 0, legalID = 0, serviceDetailsID = 0, PersonID = -1;

            if (PersonData.GetInfoPersonByStatisticalNumber(ref PersonID, ref fullName, StatisticalNumber, ref AdministrativeID, ref SocialID, ref scientificID, ref legalID, ref serviceDetailsID))
            {
                return new clsPerson(PersonID, fullName, StatisticalNumber, AdministrativeID, SocialID, scientificID, legalID, serviceDetailsID);
            }

            return null;
        }

        private bool _AddNew()
        {
            return (this.PersonID = PersonData.AddNewPerson(FullName, StatisticalNumber, AdministrativeID, SocialID, scientificID, legalID, ServiceDetailsID)) > -1;
        }
        private bool _Update()
        {
            return PersonData.UpdatePerson(PersonID, FullName, StatisticalNumber);
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
        public bool DeletePerson()
        {
            return PersonData.DeletePerson(PersonID);
        }

        public static int NumberOfPeople()
        {
            return PersonData.NumberOfPeople();
        }

        public static bool IsExistStatisticalNumber(string StatisticalNumber)
        {
            return PersonData.IsExistStatisticalNumber(StatisticalNumber);
        }

    }
}
