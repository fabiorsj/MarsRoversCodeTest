using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Model
{
    public class RoverModel
    {
        public Position InitialPosition { get; set; } = new Position();
        public string Instructions { get; set; } = string.Empty;
    }
}
