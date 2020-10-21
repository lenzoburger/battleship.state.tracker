using Battleship.state.tracker.Components.Ship;
using System;
using System.Collections.Generic;

namespace Battleship.state.tracker.Components.Board
{
    public class Board : IBoard
    {
        public IShip[,] Grid { get; }
        public List<IShip> Ships { get; }

        public int Width => 10;

        public int Lenght => 10;

        public Board()
        {
            Grid = new Ship[Width, Lenght];
            Ships = new List<IShip>();
        }

        public void AddShip(IShip ship)
        {
            ship.SetCoordinates(this);
            if (!CheckShipExistsAtLocation(ship))
            {
                foreach (var coord in ship.Coordinates)
                {
                    Grid[coord.Y - 1, coord.X - 1] = ship;
                }

                Ships.Add(ship);
            }
            else
            {
                throw new ArgumentException("Cannot add ship at the location");
            }
        }

        public bool CheckShipExistsAtLocation(IShip ship)
        {
            try
            {
                foreach (var coord in ship.Coordinates)
                {
                    if (Grid[coord.Y - 1, coord.X - 1] != null)
                    {
                        return true;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        public void ReDrawGrid()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n\tA\tB\tC\tD\tE\tF\tG\tH\tI\tJ\n\n");

            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{row + 1}\t");
                Console.ForegroundColor = ConsoleColor.White;

                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    var ship = Grid[row, col];

                    if (ship == null)
                    {
                        Console.Write("-\t");
                    }
                    else
                    {
                        Console.Write($"{ship.Character}\t");
                    }
                }
                Console.Write("\n\n");
            }
        }
    }
}