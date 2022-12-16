using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Model
{
    public static class Constants
    {
        // cardinal points
        public static readonly string North = "N";
        public static readonly string East = "E";
        public static readonly string South = "S";
        public static readonly string West = "W";
        public static readonly string[] CardinalPoints = new string[] { North, East, South, West };

        // move and turn instructions
        public static readonly string Left = "L";
        public static readonly string Right = "R";
        public static readonly string Move = "M";
    }
}
