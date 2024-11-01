using PAMSMU_Data;

namespace PAMSMU_Business
{
    public class clsServiceDetails
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;

        public clsServiceDetails()
        {
            _Mode = _enMode.AddNew;
        }

        private clsServiceDetails(int serviceDetailsID, string imagePath, string promotionOrders,
            string criminalRestrictions, string guarantees, string annualBonusOrders, string variables,
            string serviceEvaluationByUnits, string notes)
        {
            _Mode = _enMode.Update;

            ServiceDetailsID = serviceDetailsID;
            ImagePath = imagePath;
            PromotionOrders = promotionOrders;
            CriminalRestrictions = criminalRestrictions;
            Guarantees = guarantees;
            AnnualBonusOrders = annualBonusOrders;
            Variables = variables;
            ServiceEvaluationByUnits = serviceEvaluationByUnits;
            Notes = notes;
        }

        public int ServiceDetailsID { get; set; }
        public string ImagePath { get; set; }
        public string PromotionOrders { get; set; }
        public string CriminalRestrictions { get; set; }
        public string Guarantees { get; set; }
        public string AnnualBonusOrders { get; set; }
        public string Variables { get; set; }
        public string ServiceEvaluationByUnits { get; set; }
        public string Notes { get; set; }

        public static clsServiceDetails Find(int serviceDetailsID)
        {
            string ImagePath = string.Empty, PromotionOrders = string.Empty, CriminalRestrictions = string.Empty,
                Guarantees = string.Empty, AnnualBonusOrders = string.Empty, Variables = string.Empty,
                ServiceEvaluationByUnits = string.Empty, Notes = string.Empty;
            if (ServiceDetailsData.GetInfoServiceDetails(serviceDetailsID, ref ImagePath, ref PromotionOrders, ref CriminalRestrictions, ref Guarantees, ref AnnualBonusOrders, ref Variables, ref ServiceEvaluationByUnits, ref Notes))
            {
                return new clsServiceDetails(serviceDetailsID, ImagePath, PromotionOrders, CriminalRestrictions, Guarantees, AnnualBonusOrders, Variables, ServiceEvaluationByUnits, Notes);
            }
            return null;
        }
        private bool _AddNew()
        {
            return (this.ServiceDetailsID = ServiceDetailsData.AddNewServiceDetails(ImagePath, PromotionOrders, CriminalRestrictions, Guarantees, AnnualBonusOrders, Variables, ServiceEvaluationByUnits, Notes)) > -1;
        }

        private bool _Update()
        {
            return ServiceDetailsData.UpdateServiceDetails(ServiceDetailsID, ImagePath, PromotionOrders, CriminalRestrictions, Guarantees, AnnualBonusOrders, Variables, ServiceEvaluationByUnits, Notes);
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
    }
}
