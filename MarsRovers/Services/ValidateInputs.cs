using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Model;

namespace MarsRovers.Services
{
    public static class ValidateInputs
    {
        /// <summary>
        /// Validate size input if greater than zero
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool ValidateSizeInput(Position size)
        {
            return (size.X > 0 && size.Y > 0);
        }

        /// <summary>
        /// Validate if position greater than zero and if does not cross the size limits
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public static bool ValidateInitialPositionInput(Position size, Position initialPosition)
        {
            return (initialPosition.X > 0 && initialPosition.Y > 0)
                && (initialPosition.X <= size.X && initialPosition.Y <= size.Y)
                && (Constants.CardinalPoints.Contains(initialPosition.Heading));
        }

        /// <summary>
        /// Validate if instructions contains only L, R or M
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>

        public static bool ValidateInstructions(string instructions)
        {
           List<string> allowed = new List<string>() { Constants.Left, Constants.Right, Constants.Move };
            return !string.IsNullOrEmpty(instructions)
                && !instructions.Any(x => !allowed.Contains(x.ToString()));
        }
    }
}
