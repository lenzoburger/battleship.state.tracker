using System;
using Battleship.state.tracker.Components.Board;
using Battleship.state.tracker.Components.Ship;
using Battleship.state.tracker.Models;
using Battleship.state.tracker.Utilities;

namespace Battleship.state.tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Battleship - State Tracker.";
            Console.WriteLine("Welcome to Battleship State Tracker!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nCommands:\n");
            Console.Write("--addShip c=coordinates,l=length,d=direction(H,V)\n");
            Console.Write("\texample: --addShip c=B5,l=4,d=V\n");
            Console.Write("--takeAttack\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress enter to begin setup...");
            Console.ReadKey();
            Console.Clear();

            var board = new Board();
            bool? winner = null;

            do
            {
                board.ReDrawGrid();
                SelectAction(board);
            } while (winner == null);
        }

        public static void SelectAction(IBoard board)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter a command to perform an action:");

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input.\n ");
                SelectAction(board);
            }

            var args = input.Trim().Split(' ');

            try
            {
                switch (args[0].ToLower())
                {
                    case "--addship":
                        var newShip = CreateShip(input);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(newShip.ToString());
                        board.AddShip(newShip);
                        Console.WriteLine("\nPress any key to redraw board...");
                        Console.ReadKey();
                        break;
                    case "--takeattack":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input.\n ");
                        SelectAction(board);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}\n ");
                SelectAction(board);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e}\n ");
                SelectAction(board);
            }
        }

        public static Ship CreateShip(string args)
        {
            Coordinate coordinates = null;
            int? length = null;
            ShipDirection? direction = null;

            args = args.Replace("--addShip", "").Trim();

            var options = args.Split(',');

            foreach (var option in options)
            {
                switch (option?.Substring(0, 2))
                {
                    case "c=":
                        coordinates = Mapper.MapCoordinates(option[2..]);
                        break;
                    case "l=":
                        length = Int32.Parse(option[2..]);
                        break;
                    case "d=":
                        direction = Mapper.MapShipDirection(option[2..]);
                        break;
                    default:
                        throw new ArgumentException("Invalid argument");
                }
            }

            if (coordinates == null || length == null || direction == null)
            {
                throw new ArgumentException("Not all ship properties have been specified");
            }

            return new Ship(coordinates, direction.Value, length.Value);
        }
    }
}
