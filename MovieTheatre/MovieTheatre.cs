using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre
{
    public class MovieTheatre
    {
        List<String> AllocatedSeatsList = new List<String>();
        public bool TicketBooking(int noOfSeats)
        {
            if (noOfSeats == 1)
            {
                AllocatedSeatsList.Add(noOfSeats.ToString() + noOfSeats.ToString());
                Console.WriteLine(noOfSeats.ToString() + noOfSeats.ToString());



                foreach (var seat in AllocatedSeatsList)
                {
                    Console.WriteLine("Seat" +seat);
                }
                //printSeatLocation - will convert Seat nukmber as A1, A2,....
            }
            return true;
        }
    }
}
