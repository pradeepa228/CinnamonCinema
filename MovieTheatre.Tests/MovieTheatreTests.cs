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
}