using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy : Entity
    {
        public enum EnemyType { random = 0, lineal, diagonal }
        EnemyType enemyType;
        Random rand = new Random();

        static int counter1 = 0;
        static int counter2 = 0;
        static int counter3 = 0;
        int maxCountPerFrame = 500;

        public Enemy(char letter, ConsoleColor color, EnemyType enemyType) : base(letter, color)
        {
            RespawnRandomPosition();
            this.enemyType = enemyType;

            if (enemyType == EnemyType.lineal)
            {
                position.y = rand.Next(0, Console.WindowHeight - 1);
            }
        }

        public void Move(int value = 1)
        {

            switch (enemyType)
            {
                case EnemyType.random:

                    RandomMove(value);

                    break;
                case EnemyType.lineal:

                    LinealMove(value);

                    break;

                case EnemyType.diagonal:

                    DiagonalMove(value);

                    break;
            }


        }

        void RandomMove(int value = 1)
        {
            counter1++;

            if (counter1 > maxCountPerFrame)
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
                counter1 = 0;
            }
        }

        void LinealMove(int value = 1)
        {
            counter2++;

            if (counter2 > maxCountPerFrame)
            {
                ClearCurrentPosition();

                position.x += value;

                setLimits();
                counter2 = 0;
            }
        }

        void DiagonalMove(int value = 1)
        {
            counter3++;

            if (counter3 > maxCountPerFrame)
            {
                ClearCurrentPosition();

                switch (rand.Next(0, 4))
                {
                    case 0:
                        position.x += value;
                        position.y += value;
                        break;
                    case 1:
                        position.x += value;
                        position.y -= value;
                        break;
                    case 2:
                        position.x -= value;
                        position.y += value;
                        break;
                    case 3:
                        position.x -= value;
                        position.y -= value;
                        break;
                }

                setLimits();
                counter3 = 0;
            }
        }

    }
}
