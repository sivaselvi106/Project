using System;
using System.Data.SqlClient;

namespace UserDetails
{
    class UserManager
    {
        public void AddUserDetails(SqlConnection connection)
        {

            Console.Write("Enter username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter user mail id: ");
            string mailId = Console.ReadLine();
            Console.Write("Enter user mob no: ");
            string mobNo = Console.ReadLine();
            Console.Write("Enter role: ");
            string role = Console.ReadLine();
            string insertValue = "INSERT INTO USERDETAIL (USERNAME,MAILID,MOBNO,USERROLE) VALUES(@userName,@mailId,@mobNo,@role)";
            SqlCommand sqlCommand = new SqlCommand(insertValue, connection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@mailId", mailId);
            sqlCommand.Parameters.AddWithValue("@mobNo", mobNo);
            sqlCommand.Parameters.AddWithValue("@role", role);
            sqlCommand.ExecuteNonQuery();
        }
        public void DisplayUserDetail(SqlConnection connection)
        {
            string display = "SELECT USERNAME,MAILID,MOBNO,USERROLE FROM USERDETAIL";
            SqlCommand sqlCommand = new SqlCommand(display, connection);
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
            reader.Close();
        }
        public void UpdateUserDetail(SqlConnection connection)
        {
            string status;
            do
            {
                Console.WriteLine("Enter the field to be updated: \n1.Username\n2.MobNo\n3.Role");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UpdateUserName(connection);
                        break;
                    case 2:
                        UpdateUserMobNo(connection);
                        break;
                    case 3:
                        UpdateUserRole(connection);
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]: ");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
        }
        public void UpdateUserName(SqlConnection connection)
        {
            Console.WriteLine("Enter the mail id");
            string mailId = Console.ReadLine();
            Console.WriteLine("Enter the updated name: ");
            String userName = Console.ReadLine();
            string updateUser = "UPDATE USERDETAIL SET USERNAME = @userName WHERE MAILID = @mailId;";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@MAILID", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar);
            command.Parameters["@MAILID"].Value = mailId;
            command.Parameters["@USERNAME"].Value = userName;
            command.ExecuteNonQuery();

        }
        public void UpdateUserMobNo(SqlConnection connection)
        {
            Console.WriteLine("Enter the mail id");
            string mailId = Console.ReadLine();
            Console.WriteLine("Enter the updated mob no: ");
            String mobNo = Console.ReadLine();
            string updateUser = "UPDATE USERDETAIL SET MOBNO = @mobNo WHERE MAILID = @mailId;";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@MAILID", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@MOBNO", System.Data.SqlDbType.VarChar);
            command.Parameters["@MAILID"].Value = mailId;
            command.Parameters["@MOBNO"].Value = mobNo;
            command.ExecuteNonQuery();
        }
        public void UpdateUserRole(SqlConnection connection)
        {
            Console.WriteLine("Enter the mail id");
            string mailId = Console.ReadLine();
            Console.WriteLine("Enter the updated mail id: ");
            String role = Console.ReadLine();
            string updateUser = "UPDATE USERDETAIL SET USERROLE = @role WHERE MAILID = @mailId";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@MAILID", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@USERROLE", System.Data.SqlDbType.VarChar);
            command.Parameters["@MAILID"].Value = mailId;
            command.Parameters["@USERROLE"].Value = role;
            command.ExecuteNonQuery();
        }
        public void DeleteUserDetail(SqlConnection connection)
        {
            Console.WriteLine("Enter the mail id to delete the user: ");
            string mailId = Console.ReadLine();
            string deleteUser = "DELETE FROM USERDETAIL where username = @mailId";
            SqlCommand command = new SqlCommand(deleteUser, connection);
            command.Parameters.Add("@MAILID", System.Data.SqlDbType.VarChar);
            command.Parameters["@MAILID"].Value = mailId;
            command.ExecuteNonQuery();
        }
    }
}
