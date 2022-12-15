using MarsRovers.Contracts;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Services
{
    public class MoveRover : IMoveRover
    {
        /// <summary>
        /// Determine where the rover should move to based on the facing direction
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="facingDirection"></param>
        /// <returns></returns>
        public Position MoveTo(Position currentPosition, string facingDirection)
        {
            var result = currentPosition;
            switch (facingDirection)
            {
                case "N":
                    result.Y += 1;
                    break;
                case "E":
                    result.X += 1;
                    break;
                case "S":
                    result.Y -= 1;
                    break;
                case "W":
                    result.X -= 1;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Determine which cardinal point the rover will turn to
        /// </summary>
        /// <param name="turnToDirection">Left or right</param>
        /// <param name="currentDirection">Current cardinal point the rover is heading to</param>
        /// <returns Example="N">Returns string containing cardinal point</returns>
        public string TurnTo(string turnToDirection, string currentDirection)
        {
            //get current index on the cardinal array
            var currentCardinalIndex = Array.IndexOf(Constants.CardinalPoints, currentDirection);

            //if left get previous, if right get next
            var turnToIndex = turnToDirection.Equals(Constants.Left)
                ? currentCardinalIndex - 1
                : currentCardinalIndex + 1;

            //if out of bounds, get first
            if (turnToIndex > Constants.CardinalPoints.Length - 1)
            {
                return Constants.CardinalPoints.First();
            }

            //if less than zero, get last
            if (turnToIndex < 0)
            {
                return Constants.CardinalPoints.Last();
            }
            return Constants.CardinalPoints[turnToIndex];
        }
    }
}
