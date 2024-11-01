using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class CardInfoData
    {
        public static int AddNewCardsInfo(string CardNumber, DateTime IssueDate, string IssuingAuthority, int CardType, int socialID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO CardsInfo 
                            VALUES(@CardNumber,
                                   @IssueDate,
                                   @IssuingAuthority,
                                   @CardType,
                                   @socialID);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@IssuingAuthority", IssuingAuthority);
            command.Parameters.AddWithValue("@CardType", CardType);
            command.Parameters.AddWithValue("@socialID", socialID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew CardsInfo: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }

        public static DataTable GetAllCardsInfo(int socialID)
        {
            DataTable dt = new DataTable(); SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from CardsInfo
                                Where socialID =@socialID ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@socialID", socialID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool DeleteAllCardsInfo(int socialID)
        {
            int rowsAffected = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"DELETE CardsInfo 
                            	WHERE socialID = @socialID;
";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@socialID", socialID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Delete CardsInfo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}
