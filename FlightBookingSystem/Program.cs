using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FlightBookingSystem
{
    class Program
    {
        internal static string adminLogin = ConfigurationManager.AppSettings["MailId"].ToString();
        internal static string adminPassword = ConfigurationManager.AppSettings["password"].ToString();
        static void Main()
        {
            // EntryPortal.PortalEntry();
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter user mail id: ");
            string mailId = Console.ReadLine();
            Console.Write("Enter user mob no: ");
            string mobNo = Console.ReadLine();
            Console.Write("Enter role: ");
            string role = Console.ReadLine();
            string input = "INSERT INTO USERDETAIL (USERNAME,MAILID,MOBNO,USERROLE) VALUES(@userName,@mailId,@mobNo,@role)";
            string connectionString = "Data source = ADMIN-PC\\SQLEXPRESS; Initial Catalog = sample; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(input, connection);
            SqlCommand updatecmd = new SqlCommand("UPDATE TABLE USERDETAIL" + "", connection);
            SqlCommand sqlCommand = new SqlCommand("SELECT USERNAME,MAILID,MOBNO,USERROLE FROM USERDETAIL", connection);
            try
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@mailId", mailId);
                cmd.Parameters.AddWithValue("@mobNo", mobNo);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("USERNAME: {0}\nMAILID: {1}\nMOBNO: {2}\nROLE: {3}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                Console.WriteLine(reader.FieldCount);
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
