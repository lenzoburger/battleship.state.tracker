using System.Text;

namespace Battleship.state.tracker.Models
{
    public class Coordinate
    {
        public int X { get; }

        public int Y { get; }
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"{nameof(X)}={X},");
            str.Append($"{nameof(Y)}={Y}");

            return str.ToString();
        }
    }
}