using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    public class GameManager
    {
        bool inGame = true;
        Character character1;
        Character character2;

        const int numberEnemys = 3;
        Enemy[] enemys = new Enemy[numberEnemys];

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
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();

            Console.CursorVisible = false;

            character1 = new Character('☺', ConsoleColor.DarkBlue, "Player 1");
            character2 = new Character('☺', ConsoleColor.DarkRed, "Player 2");

            int count = 0;
            while (count < numberEnemys)
            {
                switch (count)
                {
                    case 0:
                        enemys[count] = new Enemy('☻', ConsoleColor.Black, Enemy.EnemyType.random);
                        break;
                    case 1:

                        enemys[count] = new Enemy('☻', ConsoleColor.Black, Enemy.EnemyType.lineal);

                        break;
                    case 2:

                        enemys[count] = new Enemy('☻', ConsoleColor.Black, Enemy.EnemyType.diagonal);

                        break;
                }
                count++;
            }

            powerUp = new PowerUp('♣', ConsoleColor.Green);

            DrawFrameInConsole();

        }

        private void DrawFrameInConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            DrawFrame(0, 0, Console.WindowWidth - 1, 2);
            DrawFrame(0, 2, Console.WindowWidth - 1, Console.WindowHeight - 1);
            DrawFrame(0, Console.WindowHeight - 3, Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.SetCursorPosition(0, 2);
            Console.Write('╠');
            Console.SetCursorPosition(Console.WindowWidth - 1, 2);
            Console.Write('╣');

            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write('╠');
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
            Console.Write('╣');

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Update()
        {

            for (int i = 0; i < numberEnemys; i++)
            {
                enemys[i].Move();
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                Input(character1, cki, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow);
                Input(character2, cki, ConsoleKey.W, ConsoleKey.S, ConsoleKey.D, ConsoleKey.A);
            }

            for (int i = 0; i < numberEnemys; i++)
            {
                CheckCollisionPlayerEnemy(character1, enemys[i]);
                CheckCollisionPlayerEnemy(character2, enemys[i]);
            }

            CheckAttackAvalible(character1, powerUp);
            CheckAttackAvalible(character2, powerUp);

            if (character1.isAlive() || character2.isAlive())
            {
                inGame = false;
            }
        }
        private void Draw()
        {
            DrawHUD(character1, 1);
            DrawHUD(character2, Console.WindowHeight - 2);

            character1.DrawEntity();
            character2.DrawEntity();

            for (int i = 0; i < numberEnemys; i++)
            {
                enemys[i].DrawEntity();
            }

            if (!character1.AttackAvalible && !character2.AttackAvalible)
            {
                powerUp.DrawEntity();
            }
        }

        private void DrawHUD(Character character, int posY)
        {
            int characterPos = 1;
            int lifePos = 30;
            int pointsPos = 60;
            int isAttackPos = 100;

            ConsoleColor titlesColor = character.Color;
            ConsoleColor atributesColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(characterPos, posY);

            Console.ForegroundColor = titlesColor;
            Console.Write("Player: ");
            Console.ForegroundColor = atributesColor;
            Console.Write(character.name);


            Console.SetCursorPosition(lifePos, posY);

            Console.ForegroundColor = titlesColor;
            Console.Write("Life: ");
            Console.ForegroundColor = atributesColor;
            Console.Write(character.Life);


            Console.SetCursorPosition(pointsPos, posY);

            Console.ForegroundColor = titlesColor;
            Console.Write("Points: ");
            Console.ForegroundColor = atributesColor;
            Console.Write(character.Points);


            Console.SetCursorPosition(isAttackPos, posY);

            Console.ForegroundColor = titlesColor;
            Console.Write("Atack: ");
            Console.ForegroundColor = atributesColor;
            Console.Write(character.AttackAvalible);

            Console.ForegroundColor = ConsoleColor.White;
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

        void CheckCollisionPlayerEnemy(Character character, Enemy enemy)
        {
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
        }

        void CheckAttackAvalible(Character character, PowerUp powerUp)
        {
            if (character.Position == powerUp.Position)
            {
                character.AttackAvalible = true;
            }

        }

        void Input(Character character, ConsoleKeyInfo cki, ConsoleKey up, ConsoleKey down, ConsoleKey rigth, ConsoleKey left, int value = 1)
        {
            character.ClearCurrentPosition();

            if (cki.Key == up)
            {
                character.MoveUp(value);
            }

            if (cki.Key == down)
            {
                character.MoveDown(value);
            }

            if (cki.Key == rigth)
            {
                character.MoveRigth(value);
            }

            if (cki.Key == left)
            {
                character.MoveLeft(value);
            }

            character.setLimits();

        }
    }
}
