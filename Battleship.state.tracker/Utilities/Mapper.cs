using System;
using System.Text.RegularExpressions;
using Battleship.state.tracker.Models;

namespace Battleship.state.tracker.Utilities
{
    public static class Mapper
    {
        public static ShipDirection MapShipDirection(string direction)
        {
            var shipDirection = (direction.ToUpper()) switch
            {
                "H" => ShipDirection.Horizontal,
                "V" => ShipDirection.Vertical,
                _ => throw new ArgumentException("Invalid direction argument"),
            };
            return shipDirection;
        }

        public static Coordinate MapCoordinates(string coord)
        {
            coord = coord.ToUpper();

            var coordinatesRegex = @"^[A-J]([1-9]|10)$";

            if (!Regex.Match(coord, coordinatesRegex).Success)
            {
                throw new ArgumentException("Invalid coordinates argument");
            }

            var coords = coord.ToCharArray();
            var x = char.ToUpper(coords[0]) - 64;
            var y = Int32.Parse(coord[1].ToString());

            return new Coordinate(x, y);
        }
    }
}