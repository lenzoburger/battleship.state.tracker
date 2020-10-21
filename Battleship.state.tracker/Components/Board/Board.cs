using Battleship.state.tracker.Components.Vessel;
using Battleship.state.tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!CheckShipExistsAtLocations(ship.Coordinates))
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

        public bool CheckShipExistsAtLocations(List<Coordinate> coordinates)
        {
            foreach (var coord in coordinates)
            {
                if (CheckShipExistsAtLocation(coord))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckShipExistsAtLocation(Coordinate coordinate)
        {
            try
            {
                if (Grid[coordinate.Y - 1, coordinate.X - 1] != null)
                {
                    return true;
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

        public IShip GetShipExistsAtLocation(Coordinate coordinate)
        {
            try
            {
                if (Grid[coordinate.Y - 1, coordinate.X - 1] == null)
                {
                    return null;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }

            return Grid[coordinate.Y - 1, coordinate.X - 1];
        }

        public AttackResult TakeAttack(Coordinate coordinate)
        {
            var shipAtLocation = GetShipExistsAtLocation(coordinate);

            if (shipAtLocation == null)
            {
                return AttackResult.Miss;
            }

            shipAtLocation.Coordinates.Find(c => c.X == coordinate.X && c.Y == coordinate.Y).Hit = true;

            if (shipAtLocation.Sunk)
            {
                if (Ships.Any(s => !s.Sunk))
                {
                    return AttackResult.Sunk;
                }

                return AttackResult.GameOver;
            }

            return AttackResult.Hit;
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
                    Console.ForegroundColor = ConsoleColor.White;

                    var ship = Grid[row, col];
                    if (ship == null)
                    {
                        Console.Write("-\t");
                    }
                    else
                    {
                        if (ship.Sunk)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (ship.Coordinates.Find(s => s.Y - 1 == row && s.X - 1 == col).Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.Write($"{ship.Character}\t");
                    }
                }
                Console.Write("\n\n");
            }
        }
    }
}