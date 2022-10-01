using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre
{
    public class Booking
    {
        public String CustomerName { get; private set; }
        public String SeatLocation { get; private set; }

        public Booking(string customerName, string seatLocation)
        {
            CustomerName = customerName;
            SeatLocation = seatLocation;
        }

       public void SetCustomerName (string name)
        {
            CustomerName = name;
        }
        public void SetSeatLocation (string seatNumber)
        {
            SeatLocation = seatNumber;
        }

    }
}
