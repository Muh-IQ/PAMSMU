using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class ServiceDetailsData
    {
        public static bool GetInfoServiceDetails(int ServiceDetailsID, ref string ImagePath, ref string PromotionOrders, ref string CriminalRestrictions, ref string Guarantees, ref string AnnualBonusOrders, ref string Variables, ref string ServiceEvaluationByUnits, ref string Notes)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM ServicesDetails 
                            	WHERE ServiceDetailsID = @ServiceDetailsID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceDetailsID", ServiceDetailsID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ServiceDetailsID = (int)reader["ServiceDetailsID"];
                    ImagePath = (string)reader["ImagePath"];
                    if (reader["PromotionOrders"] == DBNull.Value)
                    {
                        PromotionOrders = " ";
                    }
                    else
                    {
                        PromotionOrders = (string)reader["PromotionOrders"];
                    }
                    if (reader["CriminalRestrictions"] == DBNull.Value)
                    {
                        CriminalRestrictions = " ";
                    }
                    else
                    {
                        CriminalRestrictions = (string)reader["CriminalRestrictions"];
                    }
                    if (reader["Guarantees"] == DBNull.Value)
                    {
                        Guarantees = " ";
                    }
                    else
                    {
                        Guarantees = (string)reader["Guarantees"];
                    }
                    if (reader["AnnualBonusOrders"] == DBNull.Value)
                    {
                        AnnualBonusOrders = " ";
                    }
                    else
                    {
                        AnnualBonusOrders = (string)reader["AnnualBonusOrders"];
                    }
                    if (reader["Variables"] == DBNull.Value)
                    {
                        Variables = " ";
                    }
                    else
                    {
                        Variables = (string)reader["Variables"];
                    }
                    if (reader["ServiceEvaluationByUnits"] == DBNull.Value)
                    {
                        ServiceEvaluationByUnits = " ";
                    }
                    else
                    {
                        ServiceEvaluationByUnits = (string)reader["ServiceEvaluationByUnits"];
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
        public static int AddNewServiceDetails(string ImagePath, string PromotionOrders, string CriminalRestrictions, string Guarantees, string AnnualBonusOrders, string Variables, string ServiceEvaluationByUnits, string Notes)
        {
            int Service = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO ServicesDetails 
                            VALUES(@ImagePath,
                                   @PromotionOrders,
                                   @CriminalRestrictions,
                                   @Guarantees,
                                   @AnnualBonusOrders,
                                   @Variables,
                                   @ServiceEvaluationByUnits,
                                   @Notes);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            if (string.IsNullOrEmpty(PromotionOrders))
                command.Parameters.AddWithValue(@"PromotionOrders", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PromotionOrders", PromotionOrders);
            if (string.IsNullOrEmpty(CriminalRestrictions))
                command.Parameters.AddWithValue(@"CriminalRestrictions", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"CriminalRestrictions", CriminalRestrictions);
            if (string.IsNullOrEmpty(Guarantees))
                command.Parameters.AddWithValue(@"Guarantees", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Guarantees", Guarantees);
            if (string.IsNullOrEmpty(AnnualBonusOrders))
                command.Parameters.AddWithValue(@"AnnualBonusOrders", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"AnnualBonusOrders", AnnualBonusOrders);
            if (string.IsNullOrEmpty(Variables))
                command.Parameters.AddWithValue(@"Variables", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Variables", Variables);
            if (string.IsNullOrEmpty(ServiceEvaluationByUnits))
                command.Parameters.AddWithValue(@"ServiceEvaluationByUnits", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ServiceEvaluationByUnits", ServiceEvaluationByUnits);
            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Notes", Notes); SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    Service = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew ServiceDetails: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return Service;
        }

        public static bool UpdateServiceDetails(int ServiceDetailsID, string ImagePath, string PromotionOrders, string CriminalRestrictions, string Guarantees, string AnnualBonusOrders, string Variables, string ServiceEvaluationByUnits, string Notes)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE ServicesDetails SET
                                 ImagePath =@ImagePath,
                                 PromotionOrders =@PromotionOrders,
                                 CriminalRestrictions =@CriminalRestrictions,
                                 Guarantees =@Guarantees,
                                 AnnualBonusOrders =@AnnualBonusOrders,
                                 Variables =@Variables,
                                 ServiceEvaluationByUnits =@ServiceEvaluationByUnits,
                                 Notes =@Notes
                            WHERE ServiceDetailsID = @ServiceDetailsID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceDetailsID", ServiceDetailsID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            if (string.IsNullOrEmpty(PromotionOrders))
                command.Parameters.AddWithValue(@"PromotionOrders", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PromotionOrders", PromotionOrders);
            if (string.IsNullOrEmpty(CriminalRestrictions))
                command.Parameters.AddWithValue(@"CriminalRestrictions", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"CriminalRestrictions", CriminalRestrictions);
            if (string.IsNullOrEmpty(Guarantees))
                command.Parameters.AddWithValue(@"Guarantees", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Guarantees", Guarantees);
            if (string.IsNullOrEmpty(AnnualBonusOrders))
                command.Parameters.AddWithValue(@"AnnualBonusOrders", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"AnnualBonusOrders", AnnualBonusOrders);
            if (string.IsNullOrEmpty(Variables))
                command.Parameters.AddWithValue(@"Variables", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Variables", Variables);
            if (string.IsNullOrEmpty(ServiceEvaluationByUnits))
                command.Parameters.AddWithValue(@"ServiceEvaluationByUnits", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ServiceEvaluationByUnits", ServiceEvaluationByUnits);
            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"Notes", Notes); try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update ServiceDetails: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
