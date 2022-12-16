using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRovers.Contracts;
using MarsRovers.Model;

namespace MarsRovers.Services
{
    public class ExecuteInstructions : IExecuteInstructions
    {
        private readonly ICompass _compass;
        private readonly IMoveRover _moveRover;

        public ExecuteInstructions(ICompass compass, IMoveRover moveRover)
        {
            _compass = compass;
            _moveRover = moveRover;
        }

        public RoverModel Execute(Position MaxArea, RoverModel roverModel)
        {
            var result = roverModel;
            result.CurrentPosition = result.InitialPosition;
            foreach (var inst in result.Instructions.ToArray())
            {
                switch (inst)
                {
                    case var value when value.ToString() == Constants.Move:
                        result.CurrentPosition = _moveRover.MoveTo(
                            result.CurrentPosition,
                            result.CurrentPosition.Heading
                        );
                        break;

                    case var value when (value.ToString() == Constants.Left || value.ToString() == Constants.Right):
                        result.CurrentPosition.Heading = _compass.TurnTo(
                            inst.ToString(),
                            result.CurrentPosition.Heading
                        );
                        break;
                }
                //check if rover reached limit and stop executing instructions
                if (result.CurrentPosition.X >= MaxArea.Y || result.CurrentPosition.Y >= MaxArea.Y)
                {
                    result.IsOutOfLimits = true;
                    continue;
                }
            }

            return result;
        }
    }
}
