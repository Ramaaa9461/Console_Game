using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class PowerUp : Entity
    {

       public PowerUp(char letter, ConsoleColor color) : base (letter, color)
        {
            RespawnRandomPosition();
        }
    
    }
}
