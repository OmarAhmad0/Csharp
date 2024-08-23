using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AccessLayer
{
    public class Books
    {

        static public DataTable GetAllBooks()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllBooks", connection))
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

        static public int AddNewBook(string BookTitle, string Author, DateTime ReleaseDate, decimal BookPrice, string BookType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_InsertIntoBooks", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookTitle", BookTitle);
                        command.Parameters.AddWithValue("@Author", Author);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@BookPrice", BookPrice);
                        command.Parameters.AddWithValue("@BookType", BookType);

                        SqlParameter NewPersonID = new SqlParameter("@NewBookID", SqlDbType.Int)
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

        static public bool UpdateBook(int BookID, string BookTitle, string Author, DateTime ReleaseDate, decimal BookPrice, string BookType)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateBooks", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@BookTitle", BookTitle);
                        command.Parameters.AddWithValue("@Author", Author);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@BookPrice", BookPrice);
                        command.Parameters.AddWithValue("@BookType", BookType);



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

        static public bool DeleteBook(int BookID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteBookByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookID", BookID);

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

        static public bool FindBookByID(int BookID, ref string BookTitle, ref string Author, ref DateTime ReleaseDate, ref decimal BookPrice, ref string BookType)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionToDatabase.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_FindBookByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookID", BookID);




                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a record is found
                            {
                                BookTitle = (string)reader["BookTitle"];
                                Author = (string)reader["Author"];
                                ReleaseDate = (DateTime)reader["ReleaseDate"];
                                BookPrice = (decimal)reader["BookPrice"];
                                BookType = (string)reader["BookType"];
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

