using MarsRovers.Contracts;
using MarsRovers.Model;
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
            var result = compass.TurnTo(Constants.Right, Constants.North);

            Assert.Equal("E", result);
        }

        [Fact]
        public void ShouldReturnSouth()
        {
            var compass = new Compass();
            var result = compass.TurnTo(Constants.Right, Constants.East);

            Assert.Equal("S", result);
        }

        [Fact]
        public void ShouldReturnWest()
        {
            var compass = new Compass();
            var result = compass.TurnTo(Constants.Right, Constants.South);

            Assert.Equal(Constants.West, result);
        }

        [Fact]
        public void ShouldReturnNorth()
        {
            var compass = new Compass();
            var result = compass.TurnTo(Constants.Right, Constants.West);

            Assert.Equal(Constants.North, result);
        }
    }
}
