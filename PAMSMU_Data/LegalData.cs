using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class LegalData
    {
        public static bool GetInfoLegal(int LegalID, ref string InvestigativeCouncils, ref string Sanctions, ref string Entitlements, ref string AcademicVacations, ref string Injuries, ref string SickLeave, ref string TouristVacations, ref string ReligiousHolidays, ref string Notes)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Legals 
                            	WHERE LegalID = @LegalID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LegalID", LegalID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    LegalID = (int)reader["LegalID"];
                    if (reader["InvestigativeCouncils"] == DBNull.Value)
                    {
                        InvestigativeCouncils = " ";
                    }
                    else
                    {
                        InvestigativeCouncils = (string)reader["InvestigativeCouncils"];
                    }
                    if (reader["Sanctions"] == DBNull.Value)
                    {
                        Sanctions = " ";
                    }
                    else
                    {
                        Sanctions = (string)reader["Sanctions"];
                    }
                    if (reader["Entitlements"] == DBNull.Value)
                    {
                        Entitlements = " ";
                    }
                    else
                    {
                        Entitlements = (string)reader["Entitlements"];
                    }
                    if (reader["AcademicVacations"] == DBNull.Value)
                    {
                        AcademicVacations = " ";
                    }
                    else
                    {
                        AcademicVacations = (string)reader["AcademicVacations"];
                    }
                    if (reader["Injuries"] == DBNull.Value)
                    {
                        Injuries = " ";
                    }
                    else
                    {
                        Injuries = (string)reader["Injuries"];
                    }
                    if (reader["SickLeave"] == DBNull.Value)
                    {
                        SickLeave = " ";
                    }
                    else
                    {
                        SickLeave = (string)reader["SickLeave"];
                    }
                    if (reader["TouristVacations"] == DBNull.Value)
                    {
                        TouristVacations = " ";
                    }
                    else
                    {
                        TouristVacations = (string)reader["TouristVacations"];
                    }
                    if (reader["ReligiousHolidays"] == DBNull.Value)
                    {
                        ReligiousHolidays = " ";
                    }
                    else
                    {
                        ReligiousHolidays = (string)reader["ReligiousHolidays"];
                    }
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = " ";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
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

        public static int AddNewLegal(string InvestigativeCouncils, string Sanctions, string Entitlements, string AcademicVacations, string Injuries, string SickLeave, string TouristVacations, string ReligiousHolidays, string Notes)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Legals 
                            VALUES(@InvestigativeCouncils,
                                   @Sanctions,
                                   @Entitlements,
                                   @AcademicVacations,
                                   @Injuries,
                                   @SickLeave,
                                   @TouristVacations,
                                   @ReligiousHolidays,
                                   @Notes);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            if (string.IsNullOrEmpty(InvestigativeCouncils))
                command.Parameters.AddWithValue(@"InvestigativeCouncils", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InvestigativeCouncils", InvestigativeCouncils); if (string.IsNullOrEmpty(Sanctions))
                command.Parameters.AddWithValue(@"Sanctions", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Sanctions", Sanctions); if (string.IsNullOrEmpty(Entitlements))
                command.Parameters.AddWithValue(@"Entitlements", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Entitlements", Entitlements); if (string.IsNullOrEmpty(AcademicVacations))
                command.Parameters.AddWithValue(@"AcademicVacations", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"AcademicVacations", AcademicVacations); if (string.IsNullOrEmpty(Injuries))
                command.Parameters.AddWithValue(@"Injuries", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Injuries", Injuries); if (string.IsNullOrEmpty(SickLeave))
                command.Parameters.AddWithValue(@"SickLeave", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"SickLeave", SickLeave); if (string.IsNullOrEmpty(TouristVacations))
                command.Parameters.AddWithValue(@"TouristVacations", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"TouristVacations", TouristVacations); if (string.IsNullOrEmpty(ReligiousHolidays))
                command.Parameters.AddWithValue(@"ReligiousHolidays", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ReligiousHolidays", ReligiousHolidays); if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Notes", Notes); SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew Legals: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }

        public static bool UpdateLegal(int LegalID, string InvestigativeCouncils, string Sanctions, string Entitlements, string AcademicVacations, string Injuries, string SickLeave, string TouristVacations, string ReligiousHolidays, string Notes)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE Legals SET
                            InvestigativeCouncils =@InvestigativeCouncils,
                            Sanctions =@Sanctions,
                            Entitlements =@Entitlements,
                            AcademicVacations =@AcademicVacations,
                            Injuries =@Injuries,
                            SickLeave =@SickLeave,
                            TouristVacations =@TouristVacations,
                            ReligiousHolidays =@ReligiousHolidays,
                            Notes =@Notes	
                                            WHERE LegalID = @LegalID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LegalID", LegalID);
            if (string.IsNullOrEmpty(InvestigativeCouncils))
                command.Parameters.AddWithValue(@"InvestigativeCouncils", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InvestigativeCouncils", InvestigativeCouncils); if (string.IsNullOrEmpty(Sanctions))
                command.Parameters.AddWithValue(@"Sanctions", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Sanctions", Sanctions); if (string.IsNullOrEmpty(Entitlements))
                command.Parameters.AddWithValue(@"Entitlements", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Entitlements", Entitlements); if (string.IsNullOrEmpty(AcademicVacations))
                command.Parameters.AddWithValue(@"AcademicVacations", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"AcademicVacations", AcademicVacations); if (string.IsNullOrEmpty(Injuries))
                command.Parameters.AddWithValue(@"Injuries", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Injuries", Injuries); if (string.IsNullOrEmpty(SickLeave))
                command.Parameters.AddWithValue(@"SickLeave", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"SickLeave", SickLeave); if (string.IsNullOrEmpty(TouristVacations))
                command.Parameters.AddWithValue(@"TouristVacations", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"TouristVacations", TouristVacations); if (string.IsNullOrEmpty(ReligiousHolidays))
                command.Parameters.AddWithValue(@"ReligiousHolidays", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ReligiousHolidays", ReligiousHolidays); if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Notes", Notes); try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Legals: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
