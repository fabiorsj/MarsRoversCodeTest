﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Contracts
{
    public interface ICompass
    {
        string TurnTo(string direction, string current);
    }
}
