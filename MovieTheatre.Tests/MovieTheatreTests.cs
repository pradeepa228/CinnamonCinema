using System;
using FluentAssertions;

namespace MovieTheatre.Tests;

public class MovieTheatreTests
{
    private MovieTheatre MovieTheatre;
    [SetUp]
    public void Setup()
    {
        MovieTheatre = new MovieTheatre();
    }

    [Test]
    public void Check_FirstSeat_Is_Alocated()
    {
        string output = MovieTheatre.TicketBooking(1, "ABC");
        output.Should().Be("A1");
    }

    [Test]
    public void Check_2seats_Are_Alocated()
    {
        string output = MovieTheatre.TicketBooking(2, "QWE");
        output.Should().Be("A1 A2");

        string output1 = MovieTheatre.TicketBooking(1, "SD");
        output1.Should().Be("A1 A2 A3");
    }
    [TestCase(0)]
    [TestCase(-1)]
    public void Program_Throws_exception_if_Customer_Requests_zero_seat(int noOfSeats)
    {
        var ex = Assert.Throws<ArgumentException>(() => MovieTheatre.TicketBooking(noOfSeats, "ABC"));
        Assert.That(ex.Message, Is.EqualTo("Number of Seats should be greater than 0."));

    }
    [TestCase(4)]
    [TestCase(9)]
    public void Program_Throws_exception_if_Customer_Requests_More_Than_3_Seats(int noOfSeats)
    {
        var ex = Assert.Throws<ArgumentException>(() => MovieTheatre.TicketBooking(noOfSeats, "ABC"));
        Assert.That(ex.Message, Is.EqualTo("Number of Seats should be between 1 and 3."));
    }

}