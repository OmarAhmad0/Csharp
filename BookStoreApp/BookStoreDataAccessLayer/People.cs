using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace AccessLayer
{
    public class People
    {

        static public DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
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

        static public int AddNewPerson(string FullName, string Phone, string Email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_InsertIntoPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FullName", FullName);
                        command.Parameters.AddWithValue("@Phone", Phone);

                        if (string.IsNullOrEmpty(Email))
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);
                        }

                        SqlParameter NewPersonID = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(NewPersonID);
                        command.ExecuteNonQuery();
                        int NewID = (int)NewPersonID.Value;
                        return NewID;

                    }
                }



            }
            catch
            {
                //Errors
            }
            return -1;
        }

        static public bool UpdatePerson(int PersonID, string FullName, string Phone, string Email)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdatePeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@FullName", FullName);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        if (string.IsNullOrEmpty(Email))
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);
                        }


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

        static public bool DeletePerson(int PersonID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeletePeopleByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        RowsAffected = command.ExecuteNonQuery();

                        return RowsAffected > 0;
                    }
                }
            }
            catch
            {

            }
            return RowsAffected > 0;
        }

        static public bool FindPersonByID(int PersonID, ref string FullName, ref string Phone, ref string Email)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FindPeopleByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);




                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a record is found
                            {
                                FullName = (string)reader["FullName"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
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
