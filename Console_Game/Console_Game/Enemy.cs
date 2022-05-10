using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy : Entity
    {
        public Enemy(char letter, ConsoleColor color) : base(letter, color)
        {
            RespawnRandomPosition();
        }
        static int counter = 0;
        public void Move(int value = 1)
        {
            Random rand = new Random();
            counter++;


            if (counter > 1000)
            {
                ClearCurrentPosition();

                switch (rand.Next(0, 4))
                {
                    case 0:
                        position.y += value;
                        break;
                    case 1:
                        position.y -= value;
                        break;
                    case 2:
                        position.x += value;
                        break;
                    case 3:
                        position.x -= value;
                        break;
                }

                setLimits();
                counter = 0;
            }
        }
    }
}
