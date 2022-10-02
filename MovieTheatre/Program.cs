using MovieTheatre;


MovieTheatreBooking bookingSeats = new();
string bookAgainInput = "";
Console.WriteLine("Welcome to CINNAMON CINEMAS!!!!!");
do
{   
    try
    {        
        Console.WriteLine("Enter Customer Name");
        string customerName = Console.ReadLine();

        Console.WriteLine("Enter Number Of seats");
        string noOfSeats = Console.ReadLine();
                     
        string output = bookingSeats.TicketBooking(Convert.ToInt32(noOfSeats), customerName);
        Console.WriteLine("Your Seat Number:"+ output);
        Console.WriteLine("Do you want to book Tickets? Type Y for Yes else N for No");
        bookAgainInput = Console.ReadLine();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("Booking Cancelled!");
        return;
    }
} while (bookAgainInput == "Y" || bookAgainInput == "y");


Console.WriteLine("Program Ends");
