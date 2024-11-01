using PAMSMU_Data;
using System.Data;

namespace PAMSMU_Business
{
    public class clsEntitlements
    {
        public static DataTable GetPieceOfGround(int PersonID)
        {
            return EntitlementsData.GetPieceOfGround(PersonID);
        }

        public static DataTable GetAnnualBonus(int PersonID)
        {
            return EntitlementsData.GetAnnualBonus(PersonID);
        }

        public static DataTable GetPromotion(int PersonID)
        {
            return EntitlementsData.GetPromotion(PersonID);
        }
    }
}
