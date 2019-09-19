using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaNaval
{
    public class Pares : IEquatable<Pares>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pares(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public bool Equals(Pares other)
        {
            return this.X == other.X &&
                   this.Y == other.Y;
        }
    }
}
