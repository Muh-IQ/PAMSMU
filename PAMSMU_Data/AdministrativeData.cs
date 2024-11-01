using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class AdministrativeData
    {
        public static bool GetInfoAdministrative(int AdministrativeID, ref string Surname, ref DateTime DateOfBirth, ref string MotherFullName, ref DateTime DateOfTheAdministrativeOrderForAppointment, ref DateTime HistoryOfTheDiwaniOrder, ref DateTime StartDate, ref string PlaceOfBirth, ref int RankID, ref string EmployeeID, ref string UnifiedNumber, ref string bloodType, ref DateTime dateOfLastPromotion, ref string IDNumber, ref DateTime DateOfIssueOfTheID, ref string Seniority)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Administrative 
                            	WHERE AdministrativeID = @AdministrativeID; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AdministrativeID = (int)reader["AdministrativeID"];
                    Surname = (string)reader["Surname"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    MotherFullName = (string)reader["MotherFullName"];
                    DateOfTheAdministrativeOrderForAppointment = (DateTime)reader["DateOfTheAdministrativeOrderForAppointment"];
                    HistoryOfTheDiwaniOrder = (DateTime)reader["HistoryOfTheDiwaniOrder"];
                    StartDate = (DateTime)reader["StartDate"];
                    PlaceOfBirth = (string)reader["PlaceOfBirth"];
                    RankID = (int)reader["RankID"];
                    EmployeeID = (string)reader["EmployeeID"];
                    UnifiedNumber = (string)reader["UnifiedNumber"];
                    bloodType = (string)reader["bloodType"];
                    {
                        dateOfLastPromotion = (DateTime)reader["dateOfLastPromotion"];
                    }
                    IDNumber = (string)reader["IDNumber"];
                    DateOfIssueOfTheID = (DateTime)reader["DateOfIssueOfTheID"];
                    Seniority = (string)reader["Seniority"];

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
        public static int AddNewAdministrative(string Surname, DateTime DateOfBirth,
            string MotherFullName, DateTime DateOfTheAdministrativeOrderForAppointment,
            DateTime HistoryOfTheDiwaniOrder, DateTime StartDate, string PlaceOfBirth, int RankID,
            string EmployeeID, string UnifiedNumber, string bloodType,
            DateTime dateOfLastPromotion, string IDNumber, DateTime DateOfIssueOfTheID, string Seniority ,DateTime BonusStartDate)
        {
            int AdministrativeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Administrative 
                            VALUES(@Surname,
                                   @DateOfBirth,
                                   @MotherFullName,
                                   @DateOfTheAdministrativeOrderForAppointment,
                                   @HistoryOfTheDiwaniOrder,
                                   @StartDate,
                                   @PlaceOfBirth,
                                   @RankID,
                                   @EmployeeID,
                                   @UnifiedNumber,
                                   @bloodType,
                                   @dateOfLastPromotion,
                                   @IDNumber,
                                   @DateOfIssueOfTheID,
                                   @Seniority ,
                                   @BonusStartDate);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@MotherFullName", MotherFullName);
            command.Parameters.AddWithValue("@DateOfTheAdministrativeOrderForAppointment", DateOfTheAdministrativeOrderForAppointment);
            command.Parameters.AddWithValue("@HistoryOfTheDiwaniOrder", HistoryOfTheDiwaniOrder);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@PlaceOfBirth", PlaceOfBirth);
            command.Parameters.AddWithValue("@RankID", RankID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@UnifiedNumber", UnifiedNumber);
            command.Parameters.AddWithValue("@bloodType", bloodType);
            command.Parameters.AddWithValue(@"dateOfLastPromotion", dateOfLastPromotion);
            command.Parameters.AddWithValue("@IDNumber", IDNumber);
            command.Parameters.AddWithValue("@DateOfIssueOfTheID", DateOfIssueOfTheID);
            command.Parameters.AddWithValue("@Seniority", Seniority);
            command.Parameters.AddWithValue("@BonusStartDate", BonusStartDate);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    AdministrativeID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew Administrative: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return AdministrativeID;
        }

        public static bool UpdateAdministrative(int AdministrativeID, string Surname, DateTime DateOfBirth, string MotherFullName, DateTime DateOfTheAdministrativeOrderForAppointment, DateTime HistoryOfTheDiwaniOrder, DateTime StartDate, string PlaceOfBirth, int RankID, string EmployeeID, string UnifiedNumber, string bloodType, DateTime dateOfLastPromotion, string IDNumber, DateTime DateOfIssueOfTheID, string Seniority,DateTime BonusStartDate)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE Administrative SET
                            Surname =@Surname,
                            DateOfBirth =@DateOfBirth,
                            MotherFullName =@MotherFullName,
                            DateOfTheAdministrativeOrderForAppointment =@DateOfTheAdministrativeOrderForAppointment,
                            HistoryOfTheDiwaniOrder =@HistoryOfTheDiwaniOrder,
                            StartDate =@StartDate,
                            PlaceOfBirth =@PlaceOfBirth,
                            RankID =@RankID,
                            EmployeeID =@EmployeeID,
                            UnifiedNumber =@UnifiedNumber,
                            bloodType =@bloodType,
                            dateOfLastPromotion =@dateOfLastPromotion,
                            IDNumber =@IDNumber,
                            DateOfIssueOfTheID =@DateOfIssueOfTheID,
                            Seniority =@Seniority,
                            BonusStartDate = @BonusStartDate
                            WHERE AdministrativeID = @AdministrativeID ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@MotherFullName", MotherFullName);
            command.Parameters.AddWithValue("@DateOfTheAdministrativeOrderForAppointment", DateOfTheAdministrativeOrderForAppointment);
            command.Parameters.AddWithValue("@HistoryOfTheDiwaniOrder", HistoryOfTheDiwaniOrder);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@PlaceOfBirth", PlaceOfBirth);
            command.Parameters.AddWithValue("@RankID", RankID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@UnifiedNumber", UnifiedNumber);
            command.Parameters.AddWithValue("@bloodType", bloodType);
            command.Parameters.AddWithValue("@dateOfLastPromotion", dateOfLastPromotion);
            command.Parameters.AddWithValue("@IDNumber", IDNumber);
            command.Parameters.AddWithValue("@DateOfIssueOfTheID", DateOfIssueOfTheID);
            command.Parameters.AddWithValue("@Seniority", Seniority);
            command.Parameters.AddWithValue("@BonusStartDate", BonusStartDate);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Administrative: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        ///////////////////

        public static bool GetInfoUnits(ref int UnitsID, int AdministrativeID, ref string UnitName, ref DateTime DateOfJoin, ref DateTime DepartureDate)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Units 
                            	WHERE AdministrativeID = @AdministrativeID AND IsCurrentUnit = 1;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UnitsID = (int)reader["UnitsID"];
                    AdministrativeID = (int)reader["AdministrativeID"];
                    UnitName = (string)reader["UnitName"];
                    DateOfJoin = (DateTime)reader["DateOfJoin"];
                    DepartureDate = (DateTime)reader["DepartureDate"];
                    IsFound = true;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetInfoUnits: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }
            return IsFound;
        }

        public static int AddNewUnits(int AdministrativeID, string UnitName, DateTime DateOfJoin, DateTime DepartureDate)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Units 
                            VALUES(@AdministrativeID,
                                   @UnitName,
                                   @DateOfJoin,
                                   @DepartureDate,
                                   @IsCurrentUnit);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            command.Parameters.AddWithValue("@UnitName", UnitName);
            command.Parameters.AddWithValue("@DateOfJoin", DateOfJoin);
            command.Parameters.AddWithValue("@DepartureDate", DepartureDate);
            command.Parameters.AddWithValue("@IsCurrentUnit", 1);//true



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew Units: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static bool UpdateUnit(int UnitsID, int AdministrativeID, string UnitName, DateTime DateOfJoin, DateTime DepartureDate, bool IsCurrentUnit)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE Units SET
                            AdministrativeID =@AdministrativeID,
                            UnitName =@UnitName,
                            DateOfJoin =@DateOfJoin,
                            DepartureDate =@DepartureDate,
                            IsCurrentUnit =@IsCurrentUnit	
                           WHERE UnitsID = @UnitsID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UnitsID", UnitsID);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            command.Parameters.AddWithValue("@UnitName", UnitName);
            command.Parameters.AddWithValue("@DateOfJoin", DateOfJoin);
            command.Parameters.AddWithValue("@DepartureDate", DepartureDate);
            command.Parameters.AddWithValue("@IsCurrentUnit", IsCurrentUnit);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Unit: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static string GetLastPreviousUnit(int AdministrativeID)
        {
            string PreviousUnit = "";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT TOP 1 UnitName FROM Units
                                 WHERE IsCurrentUnit = 0 AND AdministrativeID = @AdministrativeID
                                 ORDER BY UnitsID DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    PreviousUnit = (string)reader["UnitName"];
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Get Last Previous Unit: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PreviousUnit;
        }
        public static DataTable GetAllUnit(int AdministrativeID)
        {
            DataTable dt = new DataTable(); SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT UnitName AS 'أسم الوحدة',DateOfJoin AS 'تاريخ الانظمام' ,
                                    CASE 
                                    	WHEN DepartureDate = DateOfJoin AND IsCurrentUnit = 1 THEN 'لم يغادر'
                                    	ELSE CONVERT(nvarchar,DepartureDate)
                                    END AS 'تاريخ المغادرة'
                                    ,
                                    CASE 
                                        WHEN IsCurrentUnit = 1 THEN 'الحالية'
                                        WHEN IsCurrentUnit = 0 THEN 'السابقة'
                                        ELSE 'غير معروف'
                                    END  AS 'الوحدة'
                                    FROM Units
                                               WHERE AdministrativeID = @AdministrativeID
                                               ORDER BY UnitsID ASC;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdministrativeID", AdministrativeID);

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
                Debug.WriteLine("Error GetAllUnit : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

    }
}
