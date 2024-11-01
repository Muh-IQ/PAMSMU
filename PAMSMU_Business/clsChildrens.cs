using PAMSMU_Data;
using System;
using System.Data;

namespace PAMSMU_Business
{
    public class clsChildrens
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;
        public int childrenID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Profession { get; set; }
        public int socialID { get; set; }

        public clsChildrens()
        {
            _Mode = _enMode.AddNew;
        }

        private bool _AddNew()
        {
            return (this.childrenID = ChildrensData.AddNewChildrens(FullName, DateOfBirth, Profession, socialID)) > -1;
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

        public static DataTable GetAllChildrens(int socialID)
        {
            return ChildrensData.GetAllChildrens(socialID);
        }

        public static bool DeleteAllChildrens(int socialID)
        {
            return ChildrensData.DeleteAllChildrens(socialID);
        }
    }
}
