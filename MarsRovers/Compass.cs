using MarsRovers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class Compass : ICompass
    {
        /// <summary>
        /// Determine which cardinal point the rover will turn to
        /// </summary>
        /// <param name="direction">Left or right</param>
        /// <param name="current">Current cardinal point the rover is heading to</param>
        /// <returns></returns>
        public string TurnTo(string direction, string current)
        {
            //get current index on the cardinal array
            var currentCardinalIndex = Array.IndexOf(Constants.CardinalDirections, current);

            //if left get previous, if right get next
            var turnToIndex = direction.Equals("L") ? currentCardinalIndex - 1 : currentCardinalIndex + 1;

            //if out of bounds, get first
            if (turnToIndex > Constants.CardinalDirections.Length - 1)
            {
                return Constants.CardinalDirections.First();
            }

            //if less than zero, get last
            if (turnToIndex < 0)
            {
                return Constants.CardinalDirections.Last();
            }
            return Constants.CardinalDirections[turnToIndex];
        }
    }
}
