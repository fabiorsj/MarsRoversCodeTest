using MarsRovers.Contracts;
using MarsRovers.Model;
using MarsRovers.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            ProcessInstructions process = new ProcessInstructions(mockCompass, mockRoverMove);
            var result = process.Process(rover);

            Assert.Equal(
                "1 3 N",
                $"{result.CurrentPosition.X} {result.CurrentPosition.Y} {result.CurrentPosition.Heading}"
            );
        }
    }
}
