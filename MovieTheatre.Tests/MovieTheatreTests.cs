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
        bool output = MovieTheatre.TicketBooking(1);
        output.Should().BeTrue();
    }
}