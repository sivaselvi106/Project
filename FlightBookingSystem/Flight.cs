using System;

namespace FlightBookingSystem
{
    class Flight
    {
        internal string FlightName { get; set; }
        internal string SourcePoint { get; set; }
        internal string DestinationPoint { get; set; }
        internal int NoOfSeats { get; set; }
        internal double TicketCost { get; set; }

        public Flight(string flightName,string sourcePoint,string destinationPoint,int noOfSeats,double ticketCost)
        {
            this.FlightName = flightName;
            this.SourcePoint = sourcePoint;
            this.DestinationPoint = destinationPoint;
            this.NoOfSeats = noOfSeats;
            this.TicketCost = ticketCost;
        }
        public override string ToString()
        {
            return "*****Flight details******\n"+"Flight name: " + FlightName + "\nSource point: " + SourcePoint + "\nDestination point: " + DestinationPoint
                + "\nNo of seats available: " + NoOfSeats + "\nTicket cost: " + TicketCost;
        }
        public Flight()
        {
            Console.Write("Enter flight name: ");
            FlightName = Console.ReadLine();
            Console.Write("Source point: ");
            SourcePoint = Console.ReadLine();
            Console.Write("Destination point: ");
            DestinationPoint = Console.ReadLine();
            Console.Write("No of seats: ");
            NoOfSeats = Int32.Parse(Console.ReadLine());
            Console.Write("Ticket cost: ");
            TicketCost = double.Parse(Console.ReadLine());
        }
    }
}
