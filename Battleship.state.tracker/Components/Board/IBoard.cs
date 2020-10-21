using Battleship.state.tracker.Components.Vessel;
using Battleship.state.tracker.Models;

namespace Battleship.state.tracker.Components.Board
{
    public interface IBoard
    {
        int Width { get; }
        int Lenght { get; }

        void AddShip(IShip ship);
        AttackResult TakeAttack(Coordinate coordinate);
    }
}