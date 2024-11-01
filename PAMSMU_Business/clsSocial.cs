using PAMSMU_Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace PAMSMU_Business
{
    public class clsSocial
    {

        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;
        private clsCardInfo _clsCardInfo;
        private clsChildrens _clsChildrens;
        public enum _enCardType { Residence = 1, Unified = 2, VoterID = 3 };

        public int socialID { get; set; }
        public string MaritalStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public string martyrs { get; set; }
        public string politicians { get; set; }
        public string PreviousResidence { get; set; }
        public string CurrentResidence { get; set; }
        public string NearestKnownPointToCurrentResidence { get; set; }
        public string ChosenName { get; set; }
        public string PhoneNumber { get; set; }
        public string Religion { get; set; }
        public string Nationalism { get; set; }
        public string WifesName { get; set; }
        public string WifesOccupation { get; set; }
        public DateTime WifesBirth { get; set; }


        private List<clsCardInfo> Cards;
        private List<clsChildrens> Childrens;
        public clsSocial()
        {
            _Mode = _enMode.AddNew;
            Childrens = new List<clsChildrens>();
            Cards = new List<clsCardInfo>();

            this.socialID = -1;
            MaritalStatus = string.Empty;
            NumberOfChildren = 0;
            this.martyrs = martyrs;
            this.politicians = politicians;
            PreviousResidence = string.Empty;
            CurrentResidence = string.Empty;
            NearestKnownPointToCurrentResidence = string.Empty;
            ChosenName = string.Empty;
            PhoneNumber = string.Empty;
            Religion = string.Empty;
            Nationalism = string.Empty;
            WifesName = string.Empty;
            WifesOccupation = string.Empty;
            WifesBirth = DateTime.MinValue;
        }

        private clsSocial(int socialID, string maritalStatus, int numberOfChildren, string martyrs,
            string politicians, string previousResidence, string currentResidence,
            string nearestKnownPointToCurrentResidence, string chosenName, string phoneNumber,
            string religion, string nationalism, string wifesName, string wifesOccupation, DateTime wifesBirth)
        {
            _Mode = _enMode.Update;

            Childrens = new List<clsChildrens>();
            Cards = new List<clsCardInfo>();

            this.socialID = socialID;
            MaritalStatus = maritalStatus;
            NumberOfChildren = numberOfChildren;
            this.martyrs = martyrs;
            this.politicians = politicians;
            PreviousResidence = previousResidence;
            CurrentResidence = currentResidence;
            NearestKnownPointToCurrentResidence = nearestKnownPointToCurrentResidence;
            ChosenName = chosenName;
            PhoneNumber = phoneNumber;
            Religion = religion;
            Nationalism = nationalism;
            WifesName = wifesName;
            WifesOccupation = wifesOccupation;
            WifesBirth = wifesBirth;
        }

        public static clsSocial Find(int socialID)
        {
            string MaritalStatus = "", martyrs = "", politicians = "", PreviousResidence = "", CurrentResidence = "", NearestKnownPointToCurrentResidence = "",
                ChosenName = "", PhoneNumber = "", Religion = "", Nationalism = "", WifesName = "", WifesOccupation = "";
            int NumberOfChildren = 0; DateTime WifesBirth = DateTime.MinValue.AddYears(1900);
            if (socialData.GetInfoSocial(socialID, ref MaritalStatus, ref NumberOfChildren,
                ref martyrs, ref politicians, ref PreviousResidence, ref CurrentResidence,
                ref NearestKnownPointToCurrentResidence, ref ChosenName, ref PhoneNumber,
                ref Religion, ref Nationalism, ref WifesName, ref WifesOccupation, ref WifesBirth))
            {
                return new clsSocial(socialID, MaritalStatus, NumberOfChildren, martyrs, politicians,
                    PreviousResidence, CurrentResidence, NearestKnownPointToCurrentResidence, ChosenName, PhoneNumber
                    , Religion, Nationalism, WifesName, WifesOccupation, WifesBirth);
            }
            return null;
        }
        private bool _AddNew()
        {
            bool Result = false;
            Result = (this.socialID = socialData.AddNewSocial(MaritalStatus, NumberOfChildren, martyrs, politicians, PreviousResidence, CurrentResidence, NearestKnownPointToCurrentResidence, ChosenName, PhoneNumber, Religion, Nationalism, WifesName, WifesOccupation, WifesBirth)) > -1;

            if (Result)
            {
                Result = _SaveCards();
            }
            if (Result)
            {
                Result = _SaveChildrens();
            }
            return Result;
        }
        private bool _Update()
        {
            bool Result = false;
            Result = socialData.UpdateSocial(socialID, MaritalStatus, NumberOfChildren, martyrs, politicians, PreviousResidence, CurrentResidence, NearestKnownPointToCurrentResidence, ChosenName, PhoneNumber, Religion, Nationalism, WifesName, WifesOccupation, WifesBirth);
            if (Result)
            {
                Result = _SaveChildrens();
            }
            if (Result)
            {
                Result = _SaveCards();
            }
            return Result;
        }
        private bool _SaveCards()
        {
            clsCardInfo.DeleteAllCardsInfo(socialID);

            foreach (clsCardInfo card in Cards)
            {
                card.socialID = this.socialID;
                if (!card.Save())
                    return false;

            }
            Cards.Clear();

            return true;
        }
        private bool _SaveChildrens()
        {
            clsChildrens.DeleteAllChildrens(socialID);
            {
                foreach (clsChildrens children in Childrens)
                {
                    children.socialID = this.socialID;
                    if (!children.Save())
                        return false;
                }
                Childrens.Clear();
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

        public void AddChildren(string FullName, DateTime DateOfBirth, string Profession)
        {
            _clsChildrens = new clsChildrens();
            _clsChildrens.FullName = FullName;
            _clsChildrens.DateOfBirth = DateOfBirth;
            _clsChildrens.Profession = Profession;

            Childrens.Add(_clsChildrens);
        }
        public void AddCard(string CardNumber, DateTime IssueDate, string IssuingAuthority, _enCardType CardType)
        {
            _clsCardInfo = new clsCardInfo();
            _clsCardInfo.CardNumber = CardNumber;
            _clsCardInfo.IssueDate = IssueDate;
            _clsCardInfo.IssuingAuthority = IssuingAuthority;
            _clsCardInfo.CardType = (clsCardInfo._enCardType)CardType;
            Cards.Add(_clsCardInfo);
        }


        public DataTable GetAllChildrens()
        {
            return clsChildrens.GetAllChildrens(this.socialID);
        }

        public DataTable GetAllCardsInfo()
        {
            return clsCardInfo.GetAllCardsInfo(this.socialID);
        }
    }
}
