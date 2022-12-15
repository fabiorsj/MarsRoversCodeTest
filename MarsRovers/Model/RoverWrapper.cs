using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Model
{
    public class RoverWrapper
    {
        public Position MaxArea { get; set; } = new Position();
        public List<RoverModel> Rovers { get; set; } = new List<RoverModel>();
    }
}
