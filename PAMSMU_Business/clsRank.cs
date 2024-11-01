using PAMSMU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMSMU_Business
{
    public class clsRank
    {
        public int RankID { get; set; }
         public string Name { get; set; }
        public byte DurationOfPromotion { get; set; }


        public static DataTable GetAllRank()
        {
            return RankData.GetAllRank();
        }
    }
}
