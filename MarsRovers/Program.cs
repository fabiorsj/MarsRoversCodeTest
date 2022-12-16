using System.Net.WebSockets;
using MarsRovers;
using MarsRovers.Contracts;
using MarsRovers.Model;
using MarsRovers.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        Startup startup = new Startup();
        startup.ConfigureServices(services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var processInstructions = serviceProvider.GetRequiredService<IProcessRovers>();
        var size = new Position();

        //get area size
        while (true)
        {
            Console.WriteLine("Inform the size of the area(Example 5 5)");
            var sizeString = Console.ReadLine();
            size = GetSize(sizeString!);
            //validate size input
            if (ValidateInputs.ValidateSizeInput(size))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Try Again.");
            }
        }

        var rovers = new List<RoverModel>();

        // get rovers
        while (true)
        {
            string initialPositionString = string.Empty;
            var instructionsString = string.Empty;

            // get initial position
            while (true)
            {
                Console.WriteLine("Inform the rover's current position(Example: 3 4 N) ");
                initialPositionString = Console.ReadLine()!;
                var initialPosition = GetInitialPosition(initialPositionString);
                // validate initial position
                if (ValidateInputs.ValidateInitialPositionInput(size, initialPosition))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try Again.");
                }
            }

            // get instructions
            while (true)
            {
                Console.WriteLine("Inform the rover's instructions(Example: RRMLLMLLLM) ");
                instructionsString = Console.ReadLine();
                // validate instructions
                if (ValidateInputs.ValidateInstructions(instructionsString!))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try Again.");
                }
            }

            rovers.Add(
                new RoverModel()
                {
                    InitialPosition = GetInitialPosition(initialPositionString),
                    Instructions = instructionsString!
                }
            );

            Console.WriteLine("Add more rovers? y/n");
            var answer = Console.ReadLine();
            if (answer != "y")
            {
                break;
            }
        }
        RoverWrapper model = new RoverWrapper();
        model.MaxArea = size;
        model.Rovers = rovers;
        //process the inputs
        var result = processInstructions.Process(model);
        foreach (var item in result.Rovers)
        {
            var position = item.CurrentPosition;
            var stringResult = $"{position.X} {position.Y} {position.Heading}";
            string IsOutOfLimits = string.Empty;
            if (item.IsOutOfLimits)
                IsOutOfLimits =
                    "Execution did not complete because the rover reached the area limit";
            Console.WriteLine($"{stringResult}{IsOutOfLimits}");
        }
        Console.Read();
    }

    private static Position GetSize(string input)
    {
        var inputArray = Array.ConvertAll(input.Split(" "), int.Parse);
        return new Position() { X = inputArray[0], Y = inputArray[1] };
    }

    private static Position GetInitialPosition(string input)
    {
        var inputArray = input.Split(" ");
        return new Position()
        {
            X = Convert.ToInt32(inputArray[0]),
            Y = Convert.ToInt32(inputArray[1]),
            Heading = inputArray[2]
        };
    }
}
