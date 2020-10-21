using Battleship.state.tracker.Components.Ship;

namespace Battleship.state.tracker.Components.Board
{
    public interface IBoard
    {
        int Width { get; }
        int Lenght { get; }

        void AddShip(IShip ship);
    }
}