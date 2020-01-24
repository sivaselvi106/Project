using System;
namespace FlightBookingSystem
{
    class LoginManager
    {
        //UserRepository userRepository = new UserRepository();
        string mailId;
        internal string Login()
        {
            Console.WriteLine("Welcome to Login page!!!");
            Console.Write("Enter your mailId: ");
            do {
                mailId = Console.ReadLine();
            } while (!InputValidation.IsValidEmail(mailId));
            Console.Write("Password: ");
            string password="";
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey(true);
                if (input.Key != ConsoleKey.Backspace && input.Key != ConsoleKey.Enter)
                {
                    password += input.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (input.Key != ConsoleKey.Enter);
            Console.WriteLine();
            string result = UserRepository.Login(mailId,password);
            return result;
        }
        internal void SignUp()
        {
            Console.WriteLine("Welcome to sign up page!!!");
            UserManager.AddUserDetails();
        }
    }
}
