using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Character : Entity
    {
        public string name;
        
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
            private set { points = value; }
            get { return points; }
        }
        public bool AttackAvalible
        {
            set { attackAvalible = value; }
            get { return attackAvalible; }
        }

        public Character(char letter, ConsoleColor color, string name) : base(letter, color)
        {
            this.name = name;
        }
         

        public void MoveUp(int value = 1)
        {
            position.y -= value;
        }
        public void MoveDown(int value = 1)
        {
            position.y += value;
        }
        public void MoveRigth(int value = 1)
        {
            position.x += value;
        }
        public void MoveLeft(int value = 1)
        {
            position.x -= value;
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
