using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Contracts;
using MarsRovers.Model;

namespace MarsRovers.Services;

public class ProcessInstructions : IProcessInstructions
{
    private readonly ICompass _compass;
    private readonly IMoveRover _moveRover;

    public ProcessInstructions(ICompass compass, IMoveRover moveRover)
    {
        _compass = compass;
        _moveRover = moveRover;
    }

    public RoverModel Process(RoverModel rover)
    {
        RoverModel result = rover;
        result.CurrentPosition = rover.InitialPosition;
        foreach (var inst in rover.Instructions)
        {
            if (inst.Equals(Constants.Move))
            {
                result.CurrentPosition = _moveRover.MoveTo(result.CurrentPosition, result.CurrentPosition.Heading);
            }
            if (inst.Equals(Constants.Left) || inst.Equals(Constants.Right))
            {
                result.CurrentPosition.Heading = _compass.TurnTo(inst.ToString(), result.CurrentPosition.Heading);
            }
        }
        return rover;
    }

}