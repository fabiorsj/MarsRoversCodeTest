using MarsRovers;
using MarsRovers.Model;
using System.Net.WebSockets;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Inform the size of the area(Example 5 5)");
        var size = Console.ReadLine();
        var rovers = new List<RoverModel>();
        while (true)
        {
            Console.WriteLine("Inform the rover's current position(Example: 3 4 N) ");
            var initialPosition = Console.ReadLine();

            Console.WriteLine("Inform the rover's instructions(Example: RRMLLMLLLM) ");
            var instructions = Console.ReadLine();

            string[] positions = initialPosition.Split(' ');
            var x = Convert.ToInt32(positions[0]);
            var y = Convert.ToInt32(positions[1]);
            rovers.Add(new RoverModel() { InitialPosition = new Position() { X = x, Y = y, Heading = positions[2] }, Instructions = instructions }); ;

            Console.WriteLine("Add more rovers? y/n");
            var answer = Console.ReadLine();
            if (answer == "n")
            {
                break;
            }
        }
        Compass comp = new Compass();
        MoveRover move = new MoveRover();
        foreach (var rover in rovers)
        {
            var heading = rover.InitialPosition.Heading;
            var position = rover.InitialPosition;
            foreach (var inst in rover.Instructions)
            {

                if (inst.Equals('M'))
                {
                    position = move.MoveTo(position, heading);
                }
                if (inst.Equals('L') || inst.Equals('R'))
                {
                    heading = comp.TurnTo(inst.ToString(), heading);
                }
            }
            Console.WriteLine($"{position.X} {position.Y} {heading}");
        }
    }
}