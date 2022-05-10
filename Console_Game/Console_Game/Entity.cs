using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Entity
    {
        protected char letter;
        protected ConsoleColor color;
        protected Coordinates position = new Coordinates();

        private int upLimit = 3;
        private int downLimit = Console.WindowHeight - 2;
        private int leftLimit = 1;
        private int rigthLimit = Console.WindowWidth - 2;

        public Coordinates Position
        {
            private set { position = value; }
            get { return position; }
        }

        public Entity(char letter, ConsoleColor color)
        {
            RespawnRandomPosition();
            this.letter = letter;
            this.color = color;
        }

        public void RespawnRandomPosition()
        {
            Random random = new Random();
            position.x = random.Next(leftLimit, rigthLimit);
            position.y = random.Next(upLimit, downLimit);
        }

        protected void setLimits()
        {
            if (position.x > rigthLimit)
            {
                position.x = leftLimit;
            }

            if (position.x < leftLimit)
            {
                position.x = rigthLimit;
            }

            if (position.y > downLimit)
            {
                position.y = upLimit;
            }

            if (position.y < upLimit)
            {
                position.y = downLimit;
            }
        }
        protected void ClearCurrentPosition()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(' ');
        }
        public void DrawEntity()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(letter);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
