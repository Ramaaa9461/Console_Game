using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy
    {
        char letter = 'O';
        Coordinates position = new Coordinates();
        public Coordinates Position
        {
            private set;
            get;
        }

        public Enemy()
        {
            RespawnEnemy();
        }
           
       

        public void Move()
        {
            Random rand = new Random();

            switch(rand.Next(0,4))
            {
                case 0:
                    position.y++;
                    break;
                case 1:
                    position.y--;
                    break;
                case 2:
                    position.x++;
                    break;
                case 3:
                    position.x--;
                    break;
            }
        }
        public void DrawEnemy()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(letter);
        }
        public void RespawnEnemy()
        {
            Random random = new Random();
            position.x = random.Next(0, Console.WindowHeight);
            position.y = random.Next(0, Console.WindowHeight);

        }

    }
}
