using System;
using System.Collections.Generic;

namespace FlightBookingSystem
{
    class FlightRepository
    {
        internal static List<Flight> flightList = new List<Flight>();
        public static void AddFlightDetails(Flight flight)
        {
            flightList.Add(flight);
        }
        static FlightRepository()
        {
            flightList.Add(new Flight("TN Airways", "Chennai", "Coimbatore", 120, 1500));
            flightList.Add(new Flight("Indian Airways", "Chennai", "Delhi", 110, 3500));
        }
        internal static void ViewFlightDetails()
        {
            foreach (Flight flightListDisplay in flightList)
            {
                Console.WriteLine(flightListDisplay);
            }
        }
        internal static void BookFlightTicket(string addFlightTicket)
        {
            bool status = false;
            foreach (Flight flightListDetails in flightList)
            {
                if (flightListDetails.FlightName.Equals(addFlightTicket))
                {
                    status = true;
                    Console.WriteLine("Do you want to conform booking?[yes/no]");
                    string userChoice = Console.ReadLine().ToLower();
                    if (userChoice.Equals("yes"))
                    {
                        flightListDetails.NoOfSeats = flightListDetails.NoOfSeats - 1;
                        Console.WriteLine("Successfully booked!!!");
                    }
                }
            }
            if (!status)
                Console.WriteLine("Searched flight not found!!!");
        }
        internal static void RemoveFlightDetails(int removeFlight)
        {

            flightList.RemoveAt(--removeFlight);
            Console.WriteLine("Flights available after removal");
            ViewFlightDetails();
        }

        internal static void UpdateFlightDetails(int updateFlight)
        {
            flightList[updateFlight - 1] = new Flight();
            Console.WriteLine("Flights available after updating");
            ViewFlightDetails();
        }
        internal static void ClearAllFlightDetails()
        {
            flightList.Clear();
            Console.WriteLine("Flight list became empty!!!");
        }
    }
}
