using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class ChildrensData
    {
        public static int AddNewChildrens(string FullName, DateTime DateOfBirth, string Profession, int socialID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Childrens 
                            VALUES(@FullName,
                                   @DateOfBirth,
                                   @Profession,
                                   @socialID);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Profession", Profession);
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
                Debug.WriteLine("AddNew Childrens: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }

        public static DataTable GetAllChildrens(int socialID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from Childrens
                                Where socialID = @socialID;";

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
        public static bool DeleteAllChildrens(int socialID)
        {
            int rowsAffected = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"DELETE Childrens 
                            	WHERE socialID = @socialID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@socialID", socialID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Delete Childrens: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}
