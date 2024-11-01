using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class UserData
    {
        public static bool GetInfoUser(string UserName, string Password, ref string SaveKey)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Users 
                            	WHERE UserName = @UserName AND Password = @Password;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SaveKey = (string)reader["SaveKey"];
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetPersonByNationalNo: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }
            return IsFound;
        }
    }
}
