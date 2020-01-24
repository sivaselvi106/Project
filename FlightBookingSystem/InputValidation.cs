using System;
using System.Text.RegularExpressions;

namespace FlightBookingSystem
{
    static class InputValidation
    {
        public static bool IsValidEmail(string inputEmail)
        {

            // This Pattern is used to verify the email 
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(inputEmail))
                return (true);
            else
                Console.WriteLine("enter correct Email");
            return (false);
        }
    }
}
