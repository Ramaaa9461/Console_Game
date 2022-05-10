using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    public class GameManager
    {
        bool inGame = true;
        Character character;
        Enemy enemy;
        public void Run()
        {
            //Init
            Init();

            do
            {
                Update();
                Draw();

            } while (inGame);

        }

        private void Init()
        {
            Console.CursorVisible = false;
            character = new Character('X');
            enemy = new Enemy();
        }
        private void Update()
        {
            character.Input();
            //enemy.Move();

            if (character.Position == enemy.Position)
            {
                character.RecibeDamage();
                character.RespawnCharacter();
            }

            if (character.isAlive())
            {
                inGame = false;
            }
        }
        private void Draw()
        {
            Console.Clear();
            character.DrawCharacter();
            enemy.DrawEnemy();

          //  Thread.Sleep(30);
        }

    }
}
