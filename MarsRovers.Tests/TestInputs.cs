using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MarsRovers.Contracts;
using MarsRovers.Model;
using MarsRovers.Services;
using Moq;

namespace MarsRovers.Tests
{
    public class TestInputs
    {
        private const int X = 1;
        private const int Y = 2;
        private const string Heading = "N";
        private const string Instructions = "LMLMLMLMM";

        [Fact]
        public void TestInput()
        {
            RoverModel rover = new RoverModel();
            rover.Instructions = Instructions;
            rover.InitialPosition = new Position()
            {
                X = X,
                Y = Y,
                Heading = Heading
            };
            rover.CurrentPosition = rover.InitialPosition;

            var mockCompass = new Compass();
            var mockRoverMove = new MoveRover();
            Position MaxArea = new Position() { X = 4, Y = 4 };
            ExecuteInstructions process = new ExecuteInstructions(mockCompass, mockRoverMove);
            var result = process.Execute(MaxArea, rover);

            Assert.False(result.IsOutOfLimits);
            Assert.Equal(result.CurrentPosition.X, 1);
            Assert.Equal(result.CurrentPosition.Y, 3);
            Assert.Equal(result.CurrentPosition.Heading, Constants.North);

        }
    }
}
