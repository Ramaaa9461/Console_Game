using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Entity
    {
       protected char letter;
       protected Coordinates position = new Coordinates();

        public Coordinates Position
        {
            private set;
            get;
        }

        public Entity (char letter)
        {
            RespawnCharacter();
            this.letter = letter;
        }

        public void RespawnCharacter()
        {
            Random random = new Random();
            position.x = random.Next(1, Console.WindowHeight - 1);
            position.y = random.Next(1, Console.WindowHeight - 1);
        }

        protected void setLimits()
        {
            if (position.x >= Console.WindowHeight - 1)
            {
                position.x = 0;
            }

            if (position.x <= 0)
            {
                position.x = Console.WindowHeight - 1;
            }

            if (position.y >= Console.WindowHeight - 1)
            {
                position.y = 0;
            }

            if (position.y <= 0)
            {
                position.x = Console.WindowHeight - 1;
            }
        }
        protected void ClearCurrentPosition()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(' ');
        }
    }
}
