using MarsRovers.Contracts;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class MoveRover : IMoveRover
    {
        public Position MoveTo(Position currentPosition, string facingDirection)
        {

            switch (facingDirection)
            {
                case "N":
                    currentPosition.Y += 1;
                    break;
                case "E":
                    currentPosition.X += 1;
                    break;
                case "S":
                    currentPosition.Y -= 1;
                    break;
                case "W":
                    currentPosition.X -= 1;
                    break;
            }
            return currentPosition;
        }
    }
}
