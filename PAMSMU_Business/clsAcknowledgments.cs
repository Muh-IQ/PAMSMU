using PAMSMU_Data;

namespace PAMSMU_Business
{
    public class clsAcknowledgments
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;

        public clsAcknowledgments()
        {
            _Mode = _enMode.AddNew;
            IsLocked = false;
        }

        public clsAcknowledgments(int acknowledgmentsID, int legalID, string acknowledgments,
            bool isLocked, byte acknowledgmentsNumber)
        {
            _Mode = _enMode.AddNew;

            AcknowledgmentsID = acknowledgmentsID;
            this.legalID = legalID;
            Acknowledgments = acknowledgments;
            IsLocked = isLocked;
            AcknowledgmentsNumber = acknowledgmentsNumber;
        }

        public int AcknowledgmentsID { get; set; }
        public int legalID { get; set; }
        public string Acknowledgments { get; set; }
        public bool IsLocked { get; set; }
        public byte AcknowledgmentsNumber { get; set; }

        public static clsAcknowledgments Find(int legalID, byte AcknowledgmentsNumber)
        {
            int AcknowledgmentsID = -1; string Acknowledgments = string.Empty; bool IsLocked = false;
            if (AcknowledgmentData.GetInfoAcknowledgments(ref AcknowledgmentsID, legalID, ref Acknowledgments, ref IsLocked, AcknowledgmentsNumber))
            {
                return new clsAcknowledgments(AcknowledgmentsID, legalID, Acknowledgments, IsLocked, AcknowledgmentsNumber);
            }
            return null;
        }
        private bool _AddNew()
        {
            return (this.AcknowledgmentsID = AcknowledgmentData.AddNewAcknowledgments(legalID, Acknowledgments, IsLocked, AcknowledgmentsNumber)) > -1;
        }
        private bool _Update()
        {
            return AcknowledgmentData.UpdateAcknowledgments(AcknowledgmentsID, legalID, Acknowledgments, IsLocked, AcknowledgmentsNumber);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNew())
                    {
                        //_Mode = _enMode.Update;
                        return true;
                    }
                    return false;
                case _enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool DeleteAllAcknowledgments(int legalID)
        {
            return AcknowledgmentData.DeleteAllAcknowledgments(legalID);
        }
    }
}
