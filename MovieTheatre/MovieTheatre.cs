using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre
{
    public class MovieTheatre
    {
        public List<Booking> AllocatedSeatsList = new List<Booking>();


        public string TicketBooking(int noOfSeats, string customerName)
        {
            string seatNumber = "";
            string temporarySeat = "";
            int currentAllocationCount = 0;


            for (int row = 1; row <= 5; row++)
            {
                if (currentAllocationCount < noOfSeats)
                {
                    Console.WriteLine(noOfSeats + customerName + row);
                    temporarySeat = 1.ToString() + row.ToString();
                    var alreadyAllocated = AllocatedSeatsList.Where(Booking => Booking.SeatLocation == temporarySeat);
                    Console.WriteLine("Count" + AllocatedSeatsList.Count);

                    if ((!alreadyAllocated.Any()) || AllocatedSeatsList.Count < noOfSeats)
                    {
                        Console.WriteLine("Not Allocated before,ALLOCATING");
                        AllocatedSeatsList.Add(new Booking(customerName, temporarySeat));
                        currentAllocationCount++;

                    }
                    else
                    {
                        Console.WriteLine(" Already allocated");
                    }
                }

            }
            foreach (Booking bookingDetails in AllocatedSeatsList)
            {
                Console.WriteLine($"Booking: {bookingDetails.CustomerName}:{bookingDetails.SeatLocation}");
            }
            seatNumber = printSeatLocation();
            return seatNumber.Trim();
        }
        public string printSeatLocation()
        {
            string row1 = "A";
            string row2 = "B";
            string row3 = "C";


            string seatLocation = "";
            string output = "";
            foreach (Booking bookingDetails in AllocatedSeatsList)
            {

                if (bookingDetails.SeatLocation[0] == '1')
                {
                    seatLocation = row1 + bookingDetails.SeatLocation[1];

                }
                else if (bookingDetails.SeatLocation[0] == '2')
                {
                    seatLocation = row2 + bookingDetails.SeatLocation[1];

                }
                else if (bookingDetails.SeatLocation[0] == '3')
                {
                    seatLocation = row3 + bookingDetails.SeatLocation[1];

                }
                output = output + seatLocation + " ";
            }
            return output;
        }
    }
}
