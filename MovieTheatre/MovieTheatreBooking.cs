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
    public class MovieTheatreBooking
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

            if (customerName.Length is 0)
            {
                throw new ArgumentException("Customer Name shouldnt be empty");
            }
            while (rowNumber <= 3)
            {
                updatedAlocationCount = AllocateSeats(rowNumber, noOfSeats, customerName, currentAlocationCount);
                currentAlocationCount = updatedAlocationCount;
                rowNumber++;
            }
            seatNumber = printSeatLocation(noOfSeats, customerName);
            return seatNumber.Trim();
        }
        public string printSeatLocation(int noOfSeats,string customerName)
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

                }
            }
            return output;
        }

        public int AllocateSeats(int rowNumber, int numberOfSeats, string customerName, int currentAllocationCount)
        {
            string temporarySeat = "";

            for (int rowSeat = 1; rowSeat <= 5; rowSeat++)
            {
                if (currentAllocationCount < numberOfSeats)
                {
                    temporarySeat = rowNumber.ToString() + rowSeat.ToString();
                    var alreadyAllocated = AllocatedSeatsList.Where(Booking => Booking.SeatLocation == temporarySeat);

                    if (!alreadyAllocated.Any())
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
