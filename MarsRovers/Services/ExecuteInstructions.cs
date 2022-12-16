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
            foreach (var inst in result.Instructions)
            {
                switch (inst)
                {
                    case char value when value == Constants.Move:
                        result.CurrentPosition = _moveRover.MoveTo(
                            result.CurrentPosition,
                            result.CurrentPosition.Heading
                        );
                        break;

                    case char value when (value == Constants.Left || value == Constants.Right):
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
