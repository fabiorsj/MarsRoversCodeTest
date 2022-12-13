using MarsRovers.Contracts;
using MarsRovers.Services;
using Moq;

namespace MarsRovers.Tests
{
    public class CompassTests
    {
        [Fact]
        public void ShouldReturnEast()
        {
            var compass = new Compass();
            var result = compass.TurnTo("R", "N");

            Assert.Equal("E", result);
        }
        [Fact]
        public void ShouldReturnSouth()
        {
            var compass = new Compass();
            var result = compass.TurnTo("R", "E");

            Assert.Equal("S", result);
        }
        [Fact]
        public void ShouldReturnWest()
        {
            var compass = new Compass();
            var result = compass.TurnTo("R", "S");

            Assert.Equal("W", result);
        }
        [Fact]
        public void ShouldReturnNorth()
        {
            var compass = new Compass();
            var result = compass.TurnTo("R", "W");

            Assert.Equal("N", result);
        }
    }
}