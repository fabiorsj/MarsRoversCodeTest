using MarsRovers.Contracts;
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
    }
}