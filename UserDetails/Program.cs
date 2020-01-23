using System;
using System.Data.SqlClient;

namespace UserDetails
{
    class Program
    {
        static void Main()
        {
            UserManager userManager = new UserManager();
            string connectionString = "Data source = ADMIN-PC\\SQLEXPRESS; Initial Catalog = sample; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                string status;
                do
                {
                    Console.WriteLine("Enter your choice: \n1.Add user\n2.update user\n3.delete user\n4.display user");
                    byte choice = Byte.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            userManager.AddUserDetails(sqlConnection);
                            break;
                        case 2:
                            userManager.UpdateUserDetail(sqlConnection);
                            break;
                        case 3:
                            userManager.DeleteUserDetail(sqlConnection);
                            break;
                        case 4:
                            userManager.DisplayUserDetail(sqlConnection);
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue[yes/no]: ");
                    status = Console.ReadLine().ToLower();
                } while (status == "yes");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
