using PAMSMU_Data;
using System;
using System.Data;

namespace PAMSMU_Business
{
    public class clsCardInfo
    {
        public enum _enCardType { Residence = 1, Unified = 2, VoterID = 3 };
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;
        public int CardInfoID { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingAuthority { get; set; }
        public _enCardType CardType { get; set; }
        public int socialID { get; set; }

        public clsCardInfo()
        {
            _Mode = _enMode.AddNew;
        }
        public static void Find()
        {

        }
        private bool _AddNew()
        {
            return (this.CardInfoID = CardInfoData.AddNewCardsInfo(CardNumber, IssueDate, IssuingAuthority, (byte)CardType, socialID)) > -1;
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
                    //case _enMode.Update:
                    //return _Update();
            }
            return false;
        }
        public static DataTable GetAllCardsInfo(int socialID)
        {
            return CardInfoData.GetAllCardsInfo(socialID);
        }

        public static bool DeleteAllCardsInfo(int socialID)
        {
            return CardInfoData.DeleteAllCardsInfo(socialID);
        }
    }
}
