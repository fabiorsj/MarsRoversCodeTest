using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Contracts
{
    public interface IMoveRover
    {
        Position MoveTo(Position currentPosition, string facingDirection);
    }
}
