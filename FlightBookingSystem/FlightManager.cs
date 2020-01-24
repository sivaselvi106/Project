using System;
namespace FlightBookingSystem
{
    class FlightManager
    { 
        internal static void AddFlightDetails() 
        {
            Console.WriteLine("Enter Flight name: ");
            string flightName = Console.ReadLine();
            Console.WriteLine("Enter source point: ");
            string sourcePoint = Console.ReadLine();
            Console.WriteLine("Enter destination point: ");
            string destinationPoint = Console.ReadLine();
            Console.WriteLine("Enter no of seats available: ");
            int noOfSeats = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter ticket cost: ");
            double ticketCost = double.Parse(Console.ReadLine());
            Flight flight = new Flight(flightName,sourcePoint,destinationPoint,noOfSeats,ticketCost);
            FlightRepository.AddFlightDetails(flight);
        }
        internal static void BookFlightTicket()
        {
            Console.Write("Enter flight name: ");
            string addFlightTicket = Console.ReadLine();
            FlightRepository.BookFlightTicket(addFlightTicket);
        }
        internal static void UpdateFlightDetails()
        {
            Console.WriteLine("Flights available");
            FlightRepository.ViewFlightDetails();
            Console.WriteLine("Enter the item no you want to update: ");
            int updateFlight = Int32.Parse(Console.ReadLine());
            FlightRepository.UpdateFlightDetails(updateFlight);
        }
        internal static void RemoveFlightDetails()
        {
            Console.WriteLine("Flights available");
            FlightRepository.ViewFlightDetails();
            Console.WriteLine("Enter the item no you want to remove: ");
            int removeFlight = Int32.Parse(Console.ReadLine());
            FlightRepository.RemoveFlightDetails(removeFlight);
        }
    }
}
