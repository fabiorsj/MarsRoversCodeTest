using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Contracts
{
    public interface IProcessInstructions
    {
        RoverModel Process(RoverModel model);
    }
}
