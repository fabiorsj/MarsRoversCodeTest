using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Model
{
    public class ProcessResult
    {
        public RoverModel Rover { get; set; } = new RoverModel();
        public string Message { get; set; } = string.Empty;
    }
}
