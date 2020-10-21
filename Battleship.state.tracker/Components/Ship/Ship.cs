using System.Text;
using Battleship.state.tracker.Models;

namespace Battleship.state.tracker.Components.Ship
{
    public class Ship : ShipBase
    {
        public Ship(Coordinate startingCoord, ShipDirection shipDirection, int shipLength) : base(startingCoord, shipDirection, shipLength)
        {
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine($"{nameof(StartingCoordinate)}={StartingCoordinate}");
            str.AppendLine($"{nameof(ShipDirection)}={ShipDirection}");
            str.AppendLine($"{nameof(ShipLength)}={ShipLength}");
            str.AppendLine($"{nameof(Character)}={Character}");

            return str.ToString();
        }
    }
}