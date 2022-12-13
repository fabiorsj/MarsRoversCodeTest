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
    }
}
