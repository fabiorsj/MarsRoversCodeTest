﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRovers.Model;

namespace MarsRovers.Contracts
{
    public interface IProcessRovers
    {
        RoverWrapper Process(RoverWrapper model);
    }
}
