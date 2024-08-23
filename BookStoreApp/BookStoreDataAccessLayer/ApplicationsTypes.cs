using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLayer
{
    public class ApplictionsTypes
    {
        static public DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllApplictionType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                            return dataTable;
                        }

                    }
                }
            }
            catch
            {
                //Errors
            }

            return dataTable;

        }

        static public bool UpdateAppliction(int ApplicationsTypeID, string Description, decimal Fees)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateApplicationsType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@ApplicationsTypeID", ApplicationsTypeID);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Fees", Fees);


                        RowsAffected = command.ExecuteNonQuery();


                        return RowsAffected > 0;
                    }
                }
            }
            catch
            {
                //Errors
            }
            return RowsAffected > 0;
        }

        static public bool FindApplictionTypeByID(int ApplicationTypeID, ref string Description, ref decimal Fees)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FindApplictionTypeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);




                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a record is found
                            {
                                Description = (string)reader["Description"];
                                Fees = (decimal)reader["Fees"];

                                return IsFound = true;

                            }
                        }
                    }
                }
            }
            catch
            {
                //Errors
            }
            return IsFound;
        }
    }
}
