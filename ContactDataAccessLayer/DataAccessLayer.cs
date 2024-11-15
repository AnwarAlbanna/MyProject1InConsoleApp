using System;
using System.Data;
using System.Data.SqlClient;


namespace ContactDataAccessLayer
{

    public class DataAccessLayer
    {
        struct stInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Adress { get; set; }
            public DateTime BirthDate { get; set; }
            public string countryID { get; set; }
        }
        static bool GetAllData( int ID ,stInfo contacts)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Select FristName from Contacts where ContactID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
         

            try
            {

                connection.Close();
                SqlDataReader reader = command.ExecuteReader();
                 if (reader.Read())
                {
                    isFound = true;
                    contacts.FirstName = (string)reader["FirstName"];
                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound; 
        }
    }
}
