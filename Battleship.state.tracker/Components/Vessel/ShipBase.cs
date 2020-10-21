using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.state.tracker.Components.Board;
using Battleship.state.tracker.Models;
using Battleship.state.tracker.Utilities;

namespace Battleship.state.tracker.Components.Vessel
{
    public abstract class ShipBase : IShip
    {
        public Coordinate StartingCoordinate { get; }
        public List<Coordinate> Coordinates { get; }
        public ShipDirection ShipDirection { get; }
        public int ShipLength { get; }
        public char Character { get; }
        public bool Sunk => !Coordinates?.Any(c => !c.Hit) ?? false;

        public ShipBase(Coordinate startingCoord, ShipDirection shipDirection, int shipLength)
        {
            StartingCoordinate = startingCoord;
            ShipDirection = shipDirection;
            ShipLength = shipLength;
            Character = Util.GetNextLetter();
            Coordinates = new List<Coordinate>();
        }

        public void SetCoordinates(IBoard board)
        {
            if (!ValidateShipFit(board))
            {
                throw new ArgumentException("Ship does not fit on board");
            };

            var reverseDirection = false;

            if (ShipDirection == ShipDirection.Horizontal && StartingCoordinate.X + ShipLength > board.Width)
            {
                reverseDirection = true;
            }

            if (ShipDirection == ShipDirection.Vertical && StartingCoordinate.Y + ShipLength > board.Lenght)
            {
                reverseDirection = true;
            }

            Coordinates.Add(StartingCoordinate);

            for (int i = 1; i < ShipLength; i++)
            {
                var increment = reverseDirection ? -i : i;

                var x = ShipDirection == ShipDirection.Horizontal ? StartingCoordinate.X + increment : StartingCoordinate.X;
                var y = ShipDirection == ShipDirection.Vertical ? StartingCoordinate.Y + increment : StartingCoordinate.Y;

                Coordinates.Add(new Coordinate(x, y));
            }
        }

        public bool ValidateShipFit(IBoard board)
        {
            if (ShipDirection == ShipDirection.Horizontal && StartingCoordinate.X + ShipLength > board.Width
            && ShipDirection == ShipDirection.Horizontal && StartingCoordinate.X - ShipLength < 1)
            {
                return false;
            };

            if (ShipDirection == ShipDirection.Vertical && StartingCoordinate.Y + ShipLength > board.Lenght
            && ShipDirection == ShipDirection.Vertical && StartingCoordinate.Y - ShipLength < 1)
            {
                return false;
            };

            return true;
        }
    }
}