using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class socialData
    {
        public static bool GetInfoSocial(int socialID, ref string MaritalStatus, ref int NumberOfChildren, ref string martyrs, ref string politicians, ref string PreviousResidence, ref string CurrentResidence, ref string NearestKnownPointToCurrentResidence, ref string ChosenName, ref string PhoneNumber, ref string Religion, ref string Nationalism, ref string WifesName, ref string WifesOccupation, ref DateTime WifesBirth)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM socials 
                            	WHERE socialID = @socialID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@socialID", socialID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    socialID = (int)reader["socialID"];
                    MaritalStatus = (string)reader["MaritalStatus"];
                    if (reader["NumberOfChildren"] == DBNull.Value)
                    {
                        NumberOfChildren = 0;
                    }
                    else
                    {
                        NumberOfChildren = (byte)reader["NumberOfChildren"];
                    }
                    if (reader["martyrs"] == DBNull.Value)
                    {
                        martyrs = " ";
                    }
                    else
                    {
                        martyrs = (string)reader["martyrs"];
                    }
                    if (reader["politicians"] == DBNull.Value)
                    {
                        politicians = " ";
                    }
                    else
                    {
                        politicians = (string)reader["politicians"];
                    }
                    if (reader["PreviousResidence"] == DBNull.Value)
                    {
                        PreviousResidence = " ";
                    }
                    else
                    {
                        PreviousResidence = (string)reader["PreviousResidence"];
                    }
                    CurrentResidence = (string)reader["CurrentResidence"];
                    NearestKnownPointToCurrentResidence = (string)reader["NearestKnownPointToCurrentResidence"];
                    ChosenName = (string)reader["ChosenName"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    if (reader["Religion"] == DBNull.Value)
                    {
                        Religion = " ";
                    }
                    else
                    {
                        Religion = (string)reader["Religion"];
                    }
                    if (reader["Nationalism"] == DBNull.Value)
                    {
                        Nationalism = " ";
                    }
                    else
                    {
                        Nationalism = (string)reader["Nationalism"];
                    }
                    if (reader["WifesName"] == DBNull.Value)
                    {
                        WifesName = " ";
                    }
                    else
                    {
                        WifesName = (string)reader["WifesName"];
                    }
                    if (reader["WifesOccupation"] == DBNull.Value)
                    {
                        WifesOccupation = " ";
                    }
                    else
                    {
                        WifesOccupation = (string)reader["WifesOccupation"];
                    }
                    if (reader["WifesBirth"] == DBNull.Value)
                    {
                        WifesBirth = DateTime.MinValue.AddYears(1900);
                    }
                    else
                    {
                        WifesBirth = (DateTime)reader["WifesBirth"];
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
        public static bool UpdateSocial(int socialID, string MaritalStatus, int NumberOfChildren, string martyrs, string politicians, string PreviousResidence, string CurrentResidence, string NearestKnownPointToCurrentResidence, string ChosenName, string PhoneNumber, string Religion, string Nationalism, string WifesName, string WifesOccupation, DateTime WifesBirth)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE socials SET
                            MaritalStatus =@MaritalStatus,
                            NumberOfChildren =@NumberOfChildren,
                            martyrs =@martyrs,
                            politicians =@politicians,
                            PreviousResidence =@PreviousResidence,
                            CurrentResidence =@CurrentResidence,
                            NearestKnownPointToCurrentResidence =@NearestKnownPointToCurrentResidence,
                            ChosenName =@ChosenName,
                            PhoneNumber =@PhoneNumber,
                            Religion =@Religion,
                            Nationalism =@Nationalism,
                            WifesName =@WifesName,
                            WifesOccupation =@WifesOccupation,
                            WifesBirth =@WifesBirth
                            WHERE socialID = @socialID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@socialID", socialID);
            command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
            if (NumberOfChildren < 1)
                command.Parameters.AddWithValue(@"NumberOfChildren", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"NumberOfChildren", NumberOfChildren); 
            if (string.IsNullOrEmpty(martyrs))
                command.Parameters.AddWithValue(@"martyrs", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"martyrs", martyrs);
            if (string.IsNullOrEmpty(politicians))
                command.Parameters.AddWithValue(@"politicians", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"politicians", politicians);
            if (string.IsNullOrEmpty(PreviousResidence))
                command.Parameters.AddWithValue(@"PreviousResidence", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PreviousResidence", PreviousResidence); command.Parameters.AddWithValue("@CurrentResidence", CurrentResidence);
            command.Parameters.AddWithValue("@NearestKnownPointToCurrentResidence", NearestKnownPointToCurrentResidence);
            command.Parameters.AddWithValue("@ChosenName", ChosenName);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            if (string.IsNullOrEmpty(Religion))
                command.Parameters.AddWithValue(@"Religion", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Religion", Religion); 
            if (string.IsNullOrEmpty(Nationalism))
                command.Parameters.AddWithValue(@"Nationalism", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Nationalism", Nationalism);
            if (string.IsNullOrEmpty(WifesName))
                command.Parameters.AddWithValue(@"WifesName", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesName", WifesName); 
            if (string.IsNullOrEmpty(WifesOccupation))
                command.Parameters.AddWithValue(@"WifesOccupation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesOccupation", WifesOccupation);
            if (WifesBirth < DateTime.MinValue.AddYears(1900))
                command.Parameters.AddWithValue(@"WifesBirth", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesBirth", WifesBirth); try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Social: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static int AddNewSocial(string MaritalStatus, int NumberOfChildren, string martyrs, string politicians, string PreviousResidence, string CurrentResidence, string NearestKnownPointToCurrentResidence, string ChosenName, string PhoneNumber, string Religion, string Nationalism, string WifesName, string WifesOccupation, DateTime WifesBirth)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO socials 
                            VALUES(@MaritalStatus,
                                   @NumberOfChildren,
                                   @martyrs,
                                   @politicians,
                                   @PreviousResidence,
                                   @CurrentResidence,
                                   @NearestKnownPointToCurrentResidence,
                                   @ChosenName,
                                   @PhoneNumber,
                                   @Religion,
                                   @Nationalism,
                                   @WifesName,
                                   @WifesOccupation,
                                   @WifesBirth);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
            if (NumberOfChildren < 1)
                command.Parameters.AddWithValue(@"NumberOfChildren", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"NumberOfChildren", NumberOfChildren);
            if (string.IsNullOrEmpty(martyrs))
                command.Parameters.AddWithValue(@"martyrs", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"martyrs", martyrs);
            if (string.IsNullOrEmpty(politicians))
                command.Parameters.AddWithValue(@"politicians", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"politicians", politicians);
            if (string.IsNullOrEmpty(PreviousResidence))
                command.Parameters.AddWithValue(@"PreviousResidence", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PreviousResidence", PreviousResidence);
            command.Parameters.AddWithValue("@CurrentResidence", CurrentResidence);
            command.Parameters.AddWithValue("@NearestKnownPointToCurrentResidence", NearestKnownPointToCurrentResidence);
            command.Parameters.AddWithValue("@ChosenName", ChosenName);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Religion", Religion);
            if (string.IsNullOrEmpty(Nationalism))
                command.Parameters.AddWithValue(@"Nationalism", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Nationalism", Nationalism);
            if (string.IsNullOrEmpty(WifesName))
                command.Parameters.AddWithValue(@"WifesName", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesName", WifesName);
            if (string.IsNullOrEmpty(WifesOccupation))
                command.Parameters.AddWithValue(@"WifesOccupation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesOccupation", WifesOccupation);
            if (WifesBirth < DateTime.MinValue.AddYears(1900))
                command.Parameters.AddWithValue(@"WifesBirth", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"WifesBirth", WifesBirth);

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
                Debug.WriteLine("AddNew social: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }


    }
}
