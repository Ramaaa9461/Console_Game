using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Character : Entity 
    {
        private int life = 5;
        int points = 0;
     

        public int Life
        {
            private set { life = value; }
            get { return life; }
        }
        public int Points
        {
            private set;
            get;
        }
        public Character(char letter) : base(letter)
        {
            RespawnCharacter();
        }
         

        public void Input(int value = 1)
        {
            if (Console.KeyAvailable)
            {
                ClearCurrentPosition();

                ConsoleKeyInfo cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:

                        position.y -= value;

                        break;
                    case ConsoleKey.DownArrow:

                        position.y += value;

                        break;
                    case ConsoleKey.RightArrow:

                        position.x += value;

                        break;
                    case ConsoleKey.LeftArrow:

                        position.x -= value;
                       
                        break;

                }

                setLimits();

            }
        }
        public void RecibeDamage(int value = 1)
        {
            life -= value;
        }
        public void AddPoints(int value = 1)
        {
            points += value;
        }
        public void DrawCharacter()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(letter);
        }
   
        public bool isAlive()
        {
            return life == 0;
        }

   
    }


}
