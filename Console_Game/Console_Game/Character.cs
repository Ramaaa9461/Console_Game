using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Character : Entity
    {
        private int life = 5;
        int points = 0;
        bool attackAvalible = false;

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
        public bool AttackAvalible
        {
            set { attackAvalible = value; }
            get { return attackAvalible; }
        }

        public Character(char letter, ConsoleColor color) : base(letter, color)
        {
            position.x = Console.WindowWidth / 2;
            position.y = Console.WindowHeight / 2;
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
        public bool isAlive()
        {
            return life == 0;
        }
   
    }


}
