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
        PowerUp powerUp;
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
            character = new Character('X', ConsoleColor.Yellow);
            enemy = new Enemy('O', ConsoleColor.DarkRed);
            powerUp = new PowerUp('♣', ConsoleColor.Green);

            Console.ForegroundColor = ConsoleColor.Blue;
            DrawFrame(0, 0, Console.WindowWidth-1, 2);
            DrawFrame(0, 2, Console.WindowWidth-1, Console.WindowHeight - 1);

            Console.SetCursorPosition(0, 2); Console.Write('╠');
            Console.SetCursorPosition(Console.WindowWidth-1, 2); Console.Write('╣');
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void Update()
        {
            character.Input();
            enemy.Move();

            if (character.Position == enemy.Position)
            {
                if (character.AttackAvalible)
                {
                    character.AddPoints();
                    enemy.RespawnRandomPosition();
                    character.AttackAvalible = false;
                    powerUp.RespawnRandomPosition();
                }
                else
                {
                    character.RecibeDamage();
                    character.RespawnRandomPosition();
                }
            }

            if (character.Position == powerUp.Position)
            {
                character.AttackAvalible = true;
            }

            if (character.isAlive())
            {
                inGame = false;
            }
        }
        private void Draw()
        {
            DrawHUD();

            character.DrawEntity();
            enemy.DrawEntity();
            if (!character.AttackAvalible)
            {
                powerUp.DrawEntity();
            }
        }

        private void DrawHUD()
        {
            Console.SetCursorPosition(5, 1);
            Console.Write("Life: " + character.Life);

            Console.SetCursorPosition(50, 1);
            Console.Write("Points: " + character.Points);

            Console.SetCursorPosition(100, 1);
            Console.Write("Atack: " + character.AttackAvalible);
        }

        private void DrawFrame(int x1, int y1, int x2, int y2)
        {
            Console.SetCursorPosition(x1, y1);
            Console.Write('╔');
            Console.SetCursorPosition(x2, y1);
            Console.Write('╗');
            Console.SetCursorPosition(x2, y2);
            Console.Write('╝');
            Console.SetCursorPosition(x1, y2);
            Console.Write('╚');

            for (int i = x1 + 1; i < x2; i++)
            {
                Console.SetCursorPosition(i, y1);
                Console.Write('═');
                Console.SetCursorPosition(i, y2);
                Console.Write('═');
            }

            for (int i = y1 + 1; i < y2; i++)
            {
                Console.SetCursorPosition(x2, i);
                Console.Write('║');
                Console.SetCursorPosition(x1, i);
                Console.Write('║');
            }
        }
    }
}
