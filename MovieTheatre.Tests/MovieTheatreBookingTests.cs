using System;
using FluentAssertions;

namespace MovieTheatre.Tests;

public class MovieTheatreBookingTests
{
    private MovieTheatreBooking MovieTheatreBooking;
    [SetUp]
    public void Setup()
    {
        MovieTheatreBooking = new MovieTheatreBooking();
    }

    [Test]
    public void Check_FirstSeat_Is_Alocated()
    {
        string output = MovieTheatreBooking.TicketBooking(1, "ABC");
        output.Should().Be("A1");
    }

    [Test]
    public void Check_2seats_Are_Alocated()
    {
        string output = MovieTheatreBooking.TicketBooking(2, "QWE");
        output.Should().Be("A1 A2");

        string output1 = MovieTheatreBooking.TicketBooking(1, "SD");
        output1.Should().Be("A3");
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void Program_Throws_exception_if_Customer_Requests_zero_seat(int noOfSeats)
    {
        var ex = Assert.Throws<ArgumentException>(() => MovieTheatreBooking.TicketBooking(noOfSeats, "ABC"));
        Assert.That(ex.Message, Is.EqualTo("Number of Seats should be greater than 0."));

    }

    [TestCase(4)]
    [TestCase(9)]
    public void Program_Throws_exception_if_Customer_Requests_More_Than_3_Seats(int noOfSeats)
    {
        var ex = Assert.Throws<ArgumentException>(() => MovieTheatreBooking.TicketBooking(noOfSeats, "ABC"));
        Assert.That(ex.Message, Is.EqualTo("Number of Seats should be between 1 and 3."));
    }

    [Test]
    public void Check_seats_Are_Split_between_Rows()
    {
        string output = MovieTheatreBooking.TicketBooking(3, "RAMBO");
        output.Should().Be("A1 A2 A3");
        string output1 = MovieTheatreBooking.TicketBooking(1, "IKKY");
        output1.Should().Be("A4");
        string output2 = MovieTheatreBooking.TicketBooking(3, "BERRY");
        output2.Should().Be("A5 B1 B2");
    }


    [Test]
    public void Check_seats_Are_Allocated_Using_Random_Number_Generation()
    {
        Random rnd = new Random();
        int noOfSeats = 0;
        string output;
        int totalSeats = 0;
        int iteration = 0;
        string[] customers = new string[15] { "SAM", "ALPHA", "BETA", "GAMMA", "TINKU", "RINKU", "TWEETY", "SWEETY", "TWINKLE", "VIKRAM", "VEDHA", "ABC", "DEF", "GHI", "JKL" };
        do
        {
            noOfSeats = rnd.Next(1, 4);
            totalSeats = totalSeats + noOfSeats;
            output = MovieTheatreBooking.TicketBooking(noOfSeats, customers[iteration]);
            iteration++;
        } while (totalSeats <= 15);

    }
}