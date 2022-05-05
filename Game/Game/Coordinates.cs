using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    struct Coordinates
    {
       public int x;
       public int y;

        public static bool operator ==(Coordinates lhs, Coordinates rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }
        public static bool operator !=(Coordinates lhs, Coordinates rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }
    }
}
