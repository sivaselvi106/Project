using System;

namespace FlightBookingSystem
{
    class UserManager
    {
        public static void AddUserDetails()
        {
            Console.WriteLine("-----Enter the following details-----");
            Console.Write("User name: ");
            string UserName = Console.ReadLine();
            Console.Write("User mailId: ");
            string MailId = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            Console.Write("Mob No: ");
            long MobNo = Int64.Parse(Console.ReadLine());
            string Role = "user";
            bool BookStatus = false;
            User user = new User(UserName, MailId, Password, MobNo, Role,BookStatus);
            UserRepository.SignUp(user);
        }
        public bool SearchUser()
        {
            Console.WriteLine("Enter the user mail Id to search:");
            string mailId;
            do
            {
                mailId = Console.ReadLine();
            } while (!InputValidation.IsValidEmail(mailId));
            bool status = UserRepository.SearchUser(mailId);
            if(!status)
                Console.WriteLine("Searched user not found!!!");
            return status;
        }
        public void RemoveUser()
        {
            Console.WriteLine("Enter the user mail id to be removed: ");
            string removeElement = Console.ReadLine();
            UserRepository.RemoveUser(removeElement);
        }
        public void UpdateUser()
        {
            bool status;
            byte userChoice;
            Console.WriteLine("Enter the user mail id to update the user detail: ");
            string mailId = Console.ReadLine();
            bool output = UserRepository.SearchUser(mailId);
            if (output) { 
            do
            {
                Console.WriteLine("Enter which field you want to update:\n1.Username\n2.Password\n3.MobNo");
                status = Byte.TryParse(Console.ReadLine(), out userChoice);
            } while (!status);
            UserRepository.UpdateUserDetails(userChoice, mailId);
        }
            else
                Console.WriteLine("User not found!!!");
        }
    }
}
