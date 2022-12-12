using MarsRovers.Contracts;
using Moq;
using System.Drawing;

namespace MarsRovers.Tests
{
    public class MoveToTests
    {
        [Fact]
        public void ShouldReturnX1()
        {
            var moveTo = new MoveRover();
            var result = moveTo.MoveTo(new Model.Position() { X = 2, Y = 3}, "W");

            Assert.Equal(1, result.X);
        }

        [Fact]
        public void ShouldReturnY2()
        {
            var moveTo = new MoveRover();
            var result = moveTo.MoveTo(new Model.Position() { X = 2, Y = 3 }, "S");

            Assert.Equal(2, result.Y);
        }
    }
}