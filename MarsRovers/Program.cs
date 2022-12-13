using MarsRovers;
using MarsRovers.Contracts;
using MarsRovers.Model;
using MarsRovers.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;

internal class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        Startup startup = new Startup();
        startup.ConfigureServices(services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var processInstructions = serviceProvider.GetRequiredService<IProcessInstructions>();
        Console.WriteLine("Inform the size of the area(Example 5 5)");
        var size = Console.ReadLine();
        var rovers = new List<RoverModel>();
        while (true)
        {
            Console.WriteLine("Inform the rover's current position(Example: 3 4 N) ");
            var initialPosition = Console.ReadLine();

            Console.WriteLine("Inform the rover's instructions(Example: RRMLLMLLLM) ");
            var instructions = Console.ReadLine();

            string[] positions = initialPosition!.Split(' ');
            var x = Convert.ToInt32(positions[0]);
            var y = Convert.ToInt32(positions[1]);
            var heading = positions[2];
            rovers.Add(new RoverModel() { InitialPosition = new Position() { X = x, Y = y, Heading = heading }, Instructions = instructions! }); ;

            Console.WriteLine("Add more rovers? y/n");
            var answer = Console.ReadLine();
            if (answer != "y")
            {
                break;
            }
        }
        foreach (var rover in rovers)
        {
            var result = processInstructions.Process(rover);
            var position = result.CurrentPosition;
            Console.WriteLine($"{position.X} {position.Y} {position.Heading}");
            Console.Read();
        }
    }
}