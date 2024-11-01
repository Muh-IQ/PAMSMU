using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PAMSMU_Data
{
    public class ScientificData
    {
        public static bool GetInfoScientific(int ScientificID, ref string PrimarySchoolCertificateInformation, ref string InformationAboutTheIntermediateCertificate, ref string InformationAboutPreparatoryCertificate, ref string InformationAboutInstituteCertificate, ref string CollegeCertificateInformation, ref string InformationAboutBasicCourse, ref string InformationAboutOtherCourses, ref string InformationAboutHigherDegrees)
        {
            bool IsFound = false; SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT * FROM Scientific 
                            	WHERE ScientificID = @ScientificID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ScientificID", ScientificID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ScientificID = (int)reader["ScientificID"];
                    if (reader["PrimarySchoolCertificateInformation"] == DBNull.Value)
                    {
                        PrimarySchoolCertificateInformation = " ";
                    }
                    else
                    {
                        PrimarySchoolCertificateInformation = (string)reader["PrimarySchoolCertificateInformation"];
                    }
                    if (reader["InformationAboutTheIntermediateCertificate"] == DBNull.Value)
                    {
                        InformationAboutTheIntermediateCertificate = " ";
                    }
                    else
                    {
                        InformationAboutTheIntermediateCertificate = (string)reader["InformationAboutTheIntermediateCertificate"];
                    }
                    if (reader["InformationAboutPreparatoryCertificate"] == DBNull.Value)
                    {
                        InformationAboutPreparatoryCertificate = " ";
                    }
                    else
                    {
                        InformationAboutPreparatoryCertificate = (string)reader["InformationAboutPreparatoryCertificate"];
                    }
                    if (reader["InformationAboutInstituteCertificate"] == DBNull.Value)
                    {
                        InformationAboutInstituteCertificate = " ";
                    }
                    else
                    {
                        InformationAboutInstituteCertificate = (string)reader["InformationAboutInstituteCertificate"];
                    }
                    if (reader["CollegeCertificateInformation"] == DBNull.Value)
                    {
                        CollegeCertificateInformation = " ";
                    }
                    else
                    {
                        CollegeCertificateInformation = (string)reader["CollegeCertificateInformation"];
                    }
                    if (reader["InformationAboutBasicCourse"] == DBNull.Value)
                    {
                        InformationAboutBasicCourse = " ";
                    }
                    else
                    {
                        InformationAboutBasicCourse = (string)reader["InformationAboutBasicCourse"];
                    }
                    if (reader["InformationAboutOtherCourses"] == DBNull.Value)
                    {
                        InformationAboutOtherCourses = " ";
                    }
                    else
                    {
                        InformationAboutOtherCourses = (string)reader["InformationAboutOtherCourses"];
                    }
                    if (reader["InformationAboutHigherDegrees"] == DBNull.Value)
                    {
                        InformationAboutHigherDegrees = " ";
                    }
                    else
                    {
                        InformationAboutHigherDegrees = (string)reader["InformationAboutHigherDegrees"];
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
        public static bool UpdateScientific(int ScientificID, string PrimarySchoolCertificateInformation, string InformationAboutTheIntermediateCertificate, string InformationAboutPreparatoryCertificate, string InformationAboutInstituteCertificate, string CollegeCertificateInformation, string InformationAboutBasicCourse, string InformationAboutOtherCourses, string InformationAboutHigherDegrees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE Scientific SET
                            PrimarySchoolCertificateInformation =@PrimarySchoolCertificateInformation,
                            InformationAboutTheIntermediateCertificate =@InformationAboutTheIntermediateCertificate,
                            InformationAboutPreparatoryCertificate =@InformationAboutPreparatoryCertificate,
                            InformationAboutInstituteCertificate =@InformationAboutInstituteCertificate,
                            CollegeCertificateInformation =@CollegeCertificateInformation,
                            InformationAboutBasicCourse =@InformationAboutBasicCourse,
                            InformationAboutOtherCourses =@InformationAboutOtherCourses,
                            InformationAboutHigherDegrees =@InformationAboutHigherDegrees	
                                            WHERE ScientificID = @ScientificID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ScientificID", ScientificID);
            if (string.IsNullOrEmpty(PrimarySchoolCertificateInformation))
                command.Parameters.AddWithValue(@"PrimarySchoolCertificateInformation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PrimarySchoolCertificateInformation", PrimarySchoolCertificateInformation); if (string.IsNullOrEmpty(InformationAboutTheIntermediateCertificate))
                command.Parameters.AddWithValue(@"InformationAboutTheIntermediateCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutTheIntermediateCertificate", InformationAboutTheIntermediateCertificate); if (string.IsNullOrEmpty(InformationAboutPreparatoryCertificate))
                command.Parameters.AddWithValue(@"InformationAboutPreparatoryCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutPreparatoryCertificate", InformationAboutPreparatoryCertificate); if (string.IsNullOrEmpty(InformationAboutInstituteCertificate))
                command.Parameters.AddWithValue(@"InformationAboutInstituteCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutInstituteCertificate", InformationAboutInstituteCertificate); if (string.IsNullOrEmpty(CollegeCertificateInformation))
                command.Parameters.AddWithValue(@"CollegeCertificateInformation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"CollegeCertificateInformation", CollegeCertificateInformation); if (string.IsNullOrEmpty(InformationAboutBasicCourse))
                command.Parameters.AddWithValue(@"InformationAboutBasicCourse", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutBasicCourse", InformationAboutBasicCourse); if (string.IsNullOrEmpty(InformationAboutOtherCourses))
                command.Parameters.AddWithValue(@"InformationAboutOtherCourses", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutOtherCourses", InformationAboutOtherCourses); if (string.IsNullOrEmpty(InformationAboutHigherDegrees))
                command.Parameters.AddWithValue(@"InformationAboutHigherDegrees", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutHigherDegrees", InformationAboutHigherDegrees); try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Update Scientific: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static int AddNewScientific(string PrimarySchoolCertificateInformation, string InformationAboutTheIntermediateCertificate, string InformationAboutPreparatoryCertificate, string InformationAboutInstituteCertificate, string CollegeCertificateInformation, string InformationAboutBasicCourse, string InformationAboutOtherCourses, string InformationAboutHigherDegrees)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Scientific 
                            VALUES(@PrimarySchoolCertificateInformation,
                                   @InformationAboutTheIntermediateCertificate,
                                   @InformationAboutPreparatoryCertificate,
                                   @InformationAboutInstituteCertificate,
                                   @CollegeCertificateInformation,
                                   @InformationAboutBasicCourse,
                                   @InformationAboutOtherCourses,
                                   @InformationAboutHigherDegrees);
                            SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            if (string.IsNullOrEmpty(PrimarySchoolCertificateInformation))
                command.Parameters.AddWithValue(@"PrimarySchoolCertificateInformation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"PrimarySchoolCertificateInformation", PrimarySchoolCertificateInformation); if (string.IsNullOrEmpty(InformationAboutTheIntermediateCertificate))
                command.Parameters.AddWithValue(@"InformationAboutTheIntermediateCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutTheIntermediateCertificate", InformationAboutTheIntermediateCertificate); if (string.IsNullOrEmpty(InformationAboutPreparatoryCertificate))
                command.Parameters.AddWithValue(@"InformationAboutPreparatoryCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutPreparatoryCertificate", InformationAboutPreparatoryCertificate); if (string.IsNullOrEmpty(InformationAboutInstituteCertificate))
                command.Parameters.AddWithValue(@"InformationAboutInstituteCertificate", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutInstituteCertificate", InformationAboutInstituteCertificate); if (string.IsNullOrEmpty(CollegeCertificateInformation))
                command.Parameters.AddWithValue(@"CollegeCertificateInformation", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"CollegeCertificateInformation", CollegeCertificateInformation); if (string.IsNullOrEmpty(InformationAboutBasicCourse))
                command.Parameters.AddWithValue(@"InformationAboutBasicCourse", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutBasicCourse", InformationAboutBasicCourse); if (string.IsNullOrEmpty(InformationAboutOtherCourses))
                command.Parameters.AddWithValue(@"InformationAboutOtherCourses", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutOtherCourses", InformationAboutOtherCourses); if (string.IsNullOrEmpty(InformationAboutHigherDegrees))
                command.Parameters.AddWithValue(@"InformationAboutHigherDegrees", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"InformationAboutHigherDegrees", InformationAboutHigherDegrees); SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNew Scientific: " + ex.Message);
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
