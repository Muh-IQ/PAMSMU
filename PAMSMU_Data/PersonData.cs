using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class PersonData
    {
        public static bool GetInfoPersonByPersonID(int PersonID, ref string FullName, ref string StatisticalNumber, ref int AdministrativeID, ref int SocialID, ref int scientificID, ref int legalID, ref int ServiceDetailsID)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM People 
                            	WHERE PersonID = @PersonID AND IsDeleted = 0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    if (reader["FullName"] == DBNull.Value)
                    {
                        FullName = " ";
                    }
                    else
                    {
                        FullName = (string)reader["FullName"];
                    }
                    if (reader["StatisticalNumber"] == DBNull.Value)
                    {
                        StatisticalNumber = " ";
                    }
                    else
                    {
                        StatisticalNumber = (string)reader["StatisticalNumber"];
                    }
                    if (reader["AdministrativeID"] == DBNull.Value)
                    {
                        AdministrativeID = -1;
                    }
                    else
                    {
                        AdministrativeID = (int)reader["AdministrativeID"];
                    }
                    if (reader["SocialID"] == DBNull.Value)
                    {
                        SocialID = -1;
                    }
                    else
                    {
                        SocialID = (int)reader["SocialID"];
                    }
                    if (reader["scientificID"] == DBNull.Value)
                    {
                        scientificID = -1;
                    }
                    else
                    {
                        scientificID = (int)reader["scientificID"];
                    }
                    if (reader["legalID"] == DBNull.Value)
                    {
                        legalID = -1;
                    }
                    else
                    {
                        legalID = (int)reader["legalID"];
                    }
                    if (reader["ServiceDetailsID"] == DBNull.Value)
                    {
                        ServiceDetailsID = -1;
                    }
                    else
                    {
                        ServiceDetailsID = (int)reader["ServiceDetailsID"];
                    }
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

        public static bool GetInfoPersonByFullName(ref int PersonID, string FullName, ref string StatisticalNumber, ref int AdministrativeID, ref int SocialID, ref int scientificID, ref int legalID, ref int ServiceDetailsID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM People 
                            	WHERE FullName = @FullName AND IsDeleted = 0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];

                    if (reader["FullName"] == DBNull.Value)
                    {
                        FullName = " ";
                    }
                    else
                    {
                        FullName = (string)reader["FullName"];
                    }
                    if (reader["StatisticalNumber"] == DBNull.Value)
                    {
                        StatisticalNumber = " ";
                    }
                    else
                    {
                        StatisticalNumber = (string)reader["StatisticalNumber"];
                    }
                    if (reader["AdministrativeID"] == DBNull.Value)
                    {
                        AdministrativeID = -1;
                    }
                    else
                    {
                        AdministrativeID = (int)reader["AdministrativeID"];
                    }
                    if (reader["SocialID"] == DBNull.Value)
                    {
                        SocialID = -1;
                    }
                    else
                    {
                        SocialID = (int)reader["SocialID"];
                    }
                    if (reader["scientificID"] == DBNull.Value)
                    {
                        scientificID = -1;
                    }
                    else
                    {
                        scientificID = (int)reader["scientificID"];
                    }
                    if (reader["legalID"] == DBNull.Value)
                    {
                        legalID = -1;
                    }
                    else
                    {
                        legalID = (int)reader["legalID"];
                    }
                    if (reader["ServiceDetailsID"] == DBNull.Value)
                    {
                        ServiceDetailsID = -1;
                    }
                    else
                    {
                        ServiceDetailsID = (int)reader["ServiceDetailsID"];
                    }
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

        public static bool GetInfoPersonByStatisticalNumber(ref int PersonID, ref string FullName, string StatisticalNumber, ref int AdministrativeID, ref int SocialID, ref int scientificID, ref int legalID, ref int ServiceDetailsID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM People 
                            	WHERE StatisticalNumber = @StatisticalNumber AND IsDeleted = 0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StatisticalNumber", StatisticalNumber);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];

                    if (reader["FullName"] == DBNull.Value)
                    {
                        FullName = " ";
                    }
                    else
                    {
                        FullName = (string)reader["FullName"];
                    }
                    if (reader["StatisticalNumber"] == DBNull.Value)
                    {
                        StatisticalNumber = " ";
                    }
                    else
                    {
                        StatisticalNumber = (string)reader["StatisticalNumber"];
                    }
                    if (reader["AdministrativeID"] == DBNull.Value)
                    {
                        AdministrativeID = -1;
                    }
                    else
                    {
                        AdministrativeID = (int)reader["AdministrativeID"];
                    }
                    if (reader["SocialID"] == DBNull.Value)
                    {
                        SocialID = -1;
                    }
                    else
                    {
                        SocialID = (int)reader["SocialID"];
                    }
                    if (reader["scientificID"] == DBNull.Value)
                    {
                        scientificID = -1;
                    }
                    else
                    {
                        scientificID = (int)reader["scientificID"];
                    }
                    if (reader["legalID"] == DBNull.Value)
                    {
                        legalID = -1;
                    }
                    else
                    {
                        legalID = (int)reader["legalID"];
                    }
                    if (reader["ServiceDetailsID"] == DBNull.Value)
                    {
                        ServiceDetailsID = -1;
                    }
                    else
                    {
                        ServiceDetailsID = (int)reader["ServiceDetailsID"];
                    }
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

        public static int AddNewPerson(string FullName, string StatisticalNumber, int AdministrativeID, int socialID, int scientificID, int legalID, int ServiceDetailsID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO People 
                            VALUES(
                                   @FullName,
                                   @StatisticalNumber,
                                   @AdministrativeID,
                                   @socialID,
                                   @scientificID,
                                   @legalID,
                                   @ServiceDetailsID,
                                   @IsDeleted);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@StatisticalNumber", StatisticalNumber);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            command.Parameters.AddWithValue("@socialID", socialID);
            command.Parameters.AddWithValue("@scientificID", scientificID);
            command.Parameters.AddWithValue("@legalID", legalID);
            command.Parameters.AddWithValue("@ServiceDetailsID", ServiceDetailsID);
            command.Parameters.AddWithValue("@IsDeleted", 0);
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
                Debug.WriteLine("AddNew Person: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string FullName, string StatisticalNumber)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE People SET
                            FullName =@FullName,
                            StatisticalNumber =@StatisticalNumber
                            WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@StatisticalNumber", StatisticalNumber);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Person: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE [dbo].[People]
                               SET 
                                  [IsDeleted] = 1
                             WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Delete Person: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static int NumberOfPeople()
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT COUNT(People.PersonID) FROM People
                             WHERE People.IsDeleted=0";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    Count = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew Person: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return Count;
        }

        public static bool IsExistStatisticalNumber(string StatisticalNumber)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT X = 1 From People
                                WHERE StatisticalNumber = @StatisticalNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StatisticalNumber", StatisticalNumber);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("IsExist StatisticalNumber: " + ex.Message);
            }
            finally
            {

                connection.Close();
            }
            return IsFound;
        }

    }
}
