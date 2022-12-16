using MarsRovers.Contracts;
using MarsRovers.Model;
using MarsRovers.Services;
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
            var result = moveTo.MoveTo(new Model.Position() { X = 2, Y = 3 }, Constants.West);

            Assert.Equal(1, result.X);
        }

        [Fact]
        public void ShouldReturnY2()
        {
            var moveTo = new MoveRover();
            var result = moveTo.MoveTo(new Model.Position() { X = 2, Y = 3 }, Constants.South);

            Assert.Equal(2, result.Y);
        }
    }
}
