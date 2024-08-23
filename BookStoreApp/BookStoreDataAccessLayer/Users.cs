using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccessLayer
{
    public class Users
    {

        static public DataTable GetAllUser()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
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

        static public int AddNewUser(string UserName, string Password, bool IsActive, int Permissions, int PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_InsertIntoUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@PersonID", PersonID);



                        SqlParameter NewPersonID = new SqlParameter("@UserID", SqlDbType.Int)
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

        static public bool UpdateUser(int UserID, string UserName, string Password, bool IsActive, int Permissions, int PersonID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@PersonID", PersonID);



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

        static public bool DeleteUser(int UserID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteUsersByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);

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

        static public bool FindUserByID(int UserID, ref string UserName, ref string Password, ref bool IsActive, ref int Permissions, ref int PersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FindUsersByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);




                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a record is found
                            {
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                                Permissions = (int)reader["Permissions"];
                                PersonID = (int)reader["PersonID"];


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

        static public bool FindUserByUserNameAndPassword(string UserName, string Password, ref bool IsActive)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FindUserByUserNameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);




                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a record is found
                            {

                                IsActive = (bool)reader["IsActive"];


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
