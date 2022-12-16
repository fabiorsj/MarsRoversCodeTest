using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Contracts;
using MarsRovers.Model;

namespace MarsRovers.Services;

public class ProcessRovers : IProcessRovers
{
    private readonly IExecuteInstructions _executeInstructions;

    public ProcessRovers(IExecuteInstructions executeInstructions)
    {
        _executeInstructions = executeInstructions;
    }

    public RoverWrapper Process(RoverWrapper modelWrapper)
    {
        var result = new RoverWrapper();
        result.MaxArea = modelWrapper.MaxArea;
        foreach (var model in modelWrapper.Rovers)
        {
            var instResult = _executeInstructions.Execute(result.MaxArea, model);

            result.Rovers.Add(instResult);
        }

        return result;
    }
}
