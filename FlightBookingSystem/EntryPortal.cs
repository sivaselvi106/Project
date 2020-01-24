using System;
namespace FlightBookingSystem
{
    static class EntryPortal
    {
        internal static void PortalEntry()
        { 
            FlightRepository.ViewFlightDetails();
            Console.WriteLine("Do you want to book ticket[yes/no]: ");
            string input = Console.ReadLine().ToLower();
            if (input.Equals("yes"))
            {
                SelectChoice();
            }
            else
            {
                Console.WriteLine("Thank you for visiting our website!!!");
            }
        }
        internal static void SelectChoice()
        {
            string userRole = "";
            Console.WriteLine("Enter your choice: \n1.Login \n2.SignUp \n3.Exit");
            int choice = int.Parse(Console.ReadLine());
            LoginManager loginManager = new LoginManager();
            switch (choice)
            {
                case 1:
                    userRole = loginManager.Login();
                    break;
                case 2:
                    loginManager.SignUp();
                    userRole = loginManager.Login();
                    break;
            }
            try
            {
                if (userRole == "admin")
                    AdminOption();
                else if (userRole == "user")
                    UserOption();
                else
                {
                    Console.WriteLine("Do you want to retry[yes/no]");
                    string input = Console.ReadLine().ToLower();
                    if (input.Equals("yes"))
                    {
                        SelectChoice();
                    }
                    else
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AdminOption()
        {
            string status;
            do
            {
                Console.WriteLine("Enter your choice: \n1.Add flight details\n2.View flight details\n3.Clear all flight details\n4.Update flight details\n5.Remove flight details");
                int adminChoice = Int32.Parse(Console.ReadLine());
                switch (adminChoice)
                {
                    case 1:
                        FlightManager.AddFlightDetails();
                        break;
                    case 2:
                        FlightRepository.ViewFlightDetails();
                        break;
                    case 3:
                        FlightRepository.ClearAllFlightDetails();
                        break;
                    case 4:
                        FlightManager.UpdateFlightDetails();
                        break;
                    case 5:
                        FlightManager.RemoveFlightDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid option chosen please try again!!!");
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
        }
        static void UserOption()
        {
            UserManager userManager = new UserManager();
            string status;
            do
            {
                Console.WriteLine("Enter your choice: \n1.View flight details\n2.Book flight ticket\n3.Display user details\n4.remove user\n5.Search user\n6.Update user");
                int userChoice = Int32.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        FlightRepository.ViewFlightDetails();
                        break;
                    case 2:
                        FlightManager.BookFlightTicket();
                        break;
                    case 3:
                        UserRepository.DisplayUserDetails();
                        break;
                    case 4:
                        userManager.RemoveUser();
                        break;
                    case 5:
                        userManager.SearchUser();
                        break;
                    case 6:
                        userManager.UpdateUser();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice!!!");
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
        }
    }
}
