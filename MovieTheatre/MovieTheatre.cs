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
            int rowNumber = 1;
            int currentAlocationCount = 0;
            int updatedAlocationCount = 0;

            if (noOfSeats <= 0)
            {
                throw new ArgumentException("Number of Seats should be greater than 0.");
            }

            if (noOfSeats > 3)
            {
                throw new ArgumentException("Number of Seats should be between 1 and 3.");
            }
            while (rowNumber <= 3)
            {
                updatedAlocationCount = AllocateSeats(rowNumber, noOfSeats, customerName, currentAlocationCount);
                currentAlocationCount = updatedAlocationCount;
                rowNumber++;
            }

            seatNumber = printSeatLocation(customerName);
            if (AllocatedSeatsList.Count == 15)
            {
                Console.WriteLine("No more tickets available.");
            }
            return seatNumber.Trim();
        }
        public string printSeatLocation(string customerName)
        {
            string row1 = "A";
            string row2 = "B";
            string row3 = "C";
            string seatLocation = "";
            string output = "";

            foreach (Booking bookingDetails in AllocatedSeatsList)
            {
                if (customerName == bookingDetails.CustomerName)
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
                    Console.WriteLine($"Booking: {bookingDetails.CustomerName}:{bookingDetails.SeatLocation}");
                }
            }
            return output;
        }

        public int AllocateSeats(int rowNumber, int noOfSeats, string customerName, int currentAllocationCount)
        {
            string temporarySeat = "";

            for (int rowSeat = 1; rowSeat <= 5; rowSeat++)
            {
                if (currentAllocationCount < noOfSeats)
                {
                    temporarySeat = rowNumber.ToString() + rowSeat.ToString();
                    var alreadyAllocated = AllocatedSeatsList.Where(Booking => Booking.SeatLocation == temporarySeat);

                    if ((!alreadyAllocated.Any()) || AllocatedSeatsList.Count < noOfSeats)
                    {
                        AllocatedSeatsList.Add(new Booking(customerName, temporarySeat));
                        currentAllocationCount++;
                    }
                }
            }
            return currentAllocationCount;
        }
    }
}
