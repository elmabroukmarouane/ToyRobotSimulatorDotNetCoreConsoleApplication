using Infrastructure.Classes.Table;
using System;

namespace Toy_Robot_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string simulatorDescription =
@"
Hello and Welcome to our Toy Robot Simulator !
Here is all the possible commands :
    PLACE X,Y,F (Where X and Y are integers and Direction NORTH, SOUTH, EAST or WEST)
    MOVE   – Moves the robot 1 unit in the facing direction.
    LEFT   – turns the robot 90 degrees left.
    RIGHT  – turns the robot 90 degrees right.
    REPORT – Shows the current status of the robot. 
    EXIT / Exit / exit / 0   – Closes the simulator.
To use this Simulator, you need to place the Robot first using PLACE command,
then you can move it, turn (LEFT, RIGHT), report the current place and direction or finally exit the simulator.
";
            // Instancier les modèles et les services 
            var simulator = FactorySimulation.Class.FactorySimulation.GetSimulator();

            // condition d'arrêt du simulateur
            var stopApplication = false;

            // Afficher sur l'écran la description du simulateur
            Console.WriteLine(simulatorDescription);

            do
            {
                Console.WriteLine("Enter your next command please !");
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT") || command.Equals("Exit") || command.Equals("exit") || command.Equals("0"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
