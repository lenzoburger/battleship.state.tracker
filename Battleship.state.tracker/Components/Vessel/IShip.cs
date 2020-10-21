using Battleship.state.tracker.Components.Board;
using Battleship.state.tracker.Models;
using System.Collections.Generic;

namespace Battleship.state.tracker.Components.Vessel
{
    public interface IShip
    {
        Coordinate StartingCoordinate { get; }
        List<Coordinate> Coordinates { get; }
        ShipDirection ShipDirection { get; }
        int ShipLength { get; }
        char Character { get; }
        bool Sunk { get; }

        void SetCoordinates(IBoard board);
        bool ValidateShipFit(IBoard board);
    }
}