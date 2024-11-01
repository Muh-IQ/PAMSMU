using PAMSMU_Data;

namespace PAMSMU_Business
{
    public class clsUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SaveKey { get; set; }

        private clsUser(string userName, string password, string saveKey)
        {
            UserName = userName;
            Password = password;
            SaveKey = saveKey;
        }

        public static clsUser FindByUserNameAndPassword(string userName, string password)
        {
            string SaveKey = string.Empty;
            if (UserData.GetInfoUser(userName, password, ref SaveKey))
            {
                return new clsUser(userName, password, SaveKey);
            }
            return null;
        }
    }
}
