using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Model;

namespace MarsRovers.Contracts
{
    public interface IExecuteInstructions
    {
        RoverModel Execute(Position MaxArea, RoverModel roverModel);
    }
}
