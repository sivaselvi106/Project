using System;
using System.Collections.Generic;

namespace FlightBookingSystem
{
    class UserRepository
    {
        private static Dictionary<string, User> userDictionary = new Dictionary<string, User>();
        static UserRepository()
        {
            userDictionary.Add("praga@gmail.com",new User("praga","praga@gmail.com","pragapraga",9878854667,"user",false));
            userDictionary.Add("Rasool@gmail.com", new User("Rasool", "Rasool@gmail.com", "RasoolBeevi", 9874538798, "user",false));
        }
        internal static void SignUp(User user)
        {
            userDictionary.Add(user.MailId, user);
        }
        public static void DisplayUserDetails()
        {
            foreach (KeyValuePair<string, User> UserKeyValuePair in userDictionary)
            {
                //Console.WriteLine("Key: {0}", UserKeyValuePair.Key);
                Console.WriteLine("-------User Details-------");
                Console.WriteLine("User name: {0}\nMail Id: {1}\nMob No: {2}", UserKeyValuePair.Value.UserName, UserKeyValuePair.Key, UserKeyValuePair.Value.MobNo);
                Console.WriteLine("**************************");
            }
        }
        public static bool SearchUser(string mailId)
        {
            foreach (KeyValuePair<string, User> UserKeyValuePair in userDictionary)
            {
                if (UserKeyValuePair.Key.Equals(mailId))
                {
                    Console.WriteLine("-------User Details-------");
                    Console.WriteLine("User name: {0}\nMail Id: {1}\nMob No: {2}", UserKeyValuePair.Value.UserName, UserKeyValuePair.Key, UserKeyValuePair.Value.MobNo);
                    Console.WriteLine("**************************");
                    return true;
                }
               
            }
            return false;
        }
        public static void RemoveUser(string removeElement)
        {
            if (userDictionary.ContainsKey(removeElement))
            {
                userDictionary.Remove(removeElement);
            }
            else
            {
                Console.WriteLine("Given user mail id {0} is not found.", removeElement);
            }
        } 
        public static void UpdateUserDetails(byte userChoice,string mailId)
        {
            switch (userChoice)
            {
                case 1:
                    UpdateUserName(mailId);
                    break;
                case 2:
                    UpdateUserPassword(mailId);
                    break;
                case 3:
                    UpdateMobNo(mailId);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice!!!");
                    break;
            }
        }
        public static void UpdateUserName(string mailId)
        {
            foreach (KeyValuePair<string, User> UserKeyValuePair in userDictionary)
            {
                if (UserKeyValuePair.Key.Equals(mailId)){
                    Console.WriteLine("Enter the updated user name:");
                    UserKeyValuePair.Value.UserName = Console.ReadLine();
                }
            }
        }
        public static void UpdateMobNo(string mailId)
        {
            foreach (KeyValuePair<string, User> UserKeyValuePair in userDictionary)
            {
                if (UserKeyValuePair.Key.Equals(mailId))
                {
                    Console.WriteLine("Enter the updated user mob no:");
                    UserKeyValuePair.Value.MobNo = long.Parse(Console.ReadLine());
                }
            }
        }
        public static void UpdateUserPassword(string mailId)
        {
            foreach (KeyValuePair<string, User> UserKeyValuePair in userDictionary)
            {
                if (UserKeyValuePair.Key.Equals(mailId))
                {
                    Console.WriteLine("Enter the updated user password:");
                    UserKeyValuePair.Value.Password = Console.ReadLine();
                }
            }
        }
        internal static string Login(String mailId,string Password)
        {
            if (Program.adminLogin.Equals(mailId))
            {
                if (Program.adminPassword.Equals(Password))
                {
                    Console.WriteLine("Successfully logged in as admin!!!");
                    return "admin";
                }
                else
                    Console.WriteLine("Incorrect password\nPlease try again!!!");
                    return null;
            }
            else if (userDictionary.ContainsKey(mailId))
            {
                User checkUser = userDictionary[mailId];
                if (checkUser.Password.Equals(Password))
                {
                    Console.WriteLine("Successfully logged in as user!!!");
                    return "user";
                }
                else
                {
                    Console.WriteLine("Incorrect password\nPlease try again!!!");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("User not found!!!");
                return null;
            }
        }
    }
}
