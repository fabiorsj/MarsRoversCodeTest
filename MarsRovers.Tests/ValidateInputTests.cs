using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Model;
using MarsRovers.Services;

namespace MarsRovers.Tests
{
    public class ValidateInputTests
    {
        [Fact]
        public void ValidateSizeInputShoudBeValid()
        {
            // Given
            var size = new Position() { X = 4, Y = 2 };
            // When
            var result = ValidateInputs.ValidateSizeInput(size);
            // Then
            Assert.True(result);
        }

        [Fact]
        public void ValidateSizeInputShoudBeInvalid()
        {
            // Given
            var size = new Position() { X = -1, Y = 2 };
            // When
            var result = ValidateInputs.ValidateSizeInput(size);
            // Then
            Assert.False(result);
        }

        [Fact]
        public void ValidateInitialPositionInputShouldBeValid()
        {
            // Given
            var size = new Position() { X = 4, Y = 2 };
            var initialPosition = new Position()
            {
                X = 2,
                Y = 1,
                Heading = Constants.East
            };
            // When
            var result = ValidateInputs.ValidateInitialPositionInput(size, initialPosition);
            // Then
            Assert.True(result);
        }

        [Fact]
        public void ValidateInitialPositionInputShouldBeInvalid()
        {
            // Given
            var size = new Position() { X = 4, Y = 2 };
            var initialPosition = new Position()
            {
                X = 5,
                Y = 1,
                Heading = Constants.East
            };
            // When
            var result = ValidateInputs.ValidateInitialPositionInput(size, initialPosition);
            // Then
            Assert.False(result);
        }

        [Fact]
        public void ValidateInstructionsShouldBeValid()
        {
            // Given
            var instructions = "LMLLLRRLMM";
            // When
            var result = ValidateInputs.ValidateInstructions(instructions);
            // Then
            Assert.True(result);
        }

        [Fact]
        public void ValidateInstructionsShouldBeInvalid()
        {
            // Given
            var instructions = "XXXXLM";
            // When
            var result = ValidateInputs.ValidateInstructions(instructions);
            // Then
            Assert.False(result);
        }
    }
}
