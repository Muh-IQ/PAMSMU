using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class AcknowledgmentData
    {
        public static int AddNewAcknowledgments(int legalID, string Acknowledgments, bool IsLocked, int AcknowledgmentsNumber)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Acknowledgments 
                            VALUES(@legalID,
                                   @Acknowledgments,
                                   @IsLocked,
                                   @AcknowledgmentsNumber);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@legalID", legalID);
            command.Parameters.AddWithValue("@Acknowledgments", Acknowledgments);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@AcknowledgmentsNumber", AcknowledgmentsNumber);
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
                Debug.WriteLine("AddNew Acknowledgments: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }
        public static bool GetInfoAcknowledgments(ref int AcknowledgmentsID, int legalID, ref string Acknowledgments, ref bool IsLocked, byte AcknowledgmentsNumber)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Acknowledgments 
                            	WHERE legalID = @legalID AND AcknowledgmentsNumber = @AcknowledgmentsNumber AND IsLocked = @IsLocked;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@legalID", legalID);
            command.Parameters.AddWithValue("@AcknowledgmentsNumber", AcknowledgmentsNumber);
            command.Parameters.AddWithValue("@IsLocked", 0);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AcknowledgmentsID = (int)reader["AcknowledgmentsID"];
                    legalID = (int)reader["legalID"];
                    Acknowledgments = (string)reader["Acknowledgments"];
                    IsLocked = (bool)reader["IsLocked"];
                    AcknowledgmentsNumber = (byte)reader["AcknowledgmentsNumber"];

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
        public static bool UpdateAcknowledgments(int AcknowledgmentsID, int legalID, string Acknowledgments, bool IsLocked, int AcknowledgmentsNumber)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE Acknowledgments SET
                                   legalID =@legalID,
                                   Acknowledgments =@Acknowledgments,
                                   IsLocked =@IsLocked,
                                   AcknowledgmentsNumber =@AcknowledgmentsNumber
                             WHERE AcknowledgmentsID = @AcknowledgmentsID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AcknowledgmentsID", AcknowledgmentsID);
            command.Parameters.AddWithValue("@legalID", legalID);
            command.Parameters.AddWithValue("@Acknowledgments", Acknowledgments);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@AcknowledgmentsNumber", AcknowledgmentsNumber);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Acknowledgments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteAllAcknowledgments(int legalID)
        {
            int rowsAffected = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"DELETE Acknowledgments 
                            	WHERE legalID = @legalID AND IsLocked = @IsLocked;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@legalID", legalID);
            command.Parameters.AddWithValue("@IsLocked", 0);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Delete Acknowledgments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}
