using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2048._02
{
    class Game_2048
    {
        public event EventHandler GameOver;
        public event EventHandler UpdateScore;
        static readonly Random Random = new Random();
        readonly int SIZE;
        public int[,] Matrix;
        public static int HighestScore4X4 = 0;
        public static int HighestScore6X6= 0;
        public int HighestScore
        {
            get
            {
                return SIZE == 4 ? HighestScore4X4 : HighestScore6X6;
            }
            set
            {
                if (SIZE == 4)
                    HighestScore4X4 = value;
                else
                    HighestScore6X6 = value;
            }
        }

        private int score = 0;
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                if (score > HighestScore)
                    HighestScore = score;
                UpdateScore(this, new EventArgs());
            }
        }

        public Game_2048(int size)
        {
            SIZE = size;
            Matrix = new int[SIZE, SIZE];
            AddRandom();
            AddRandom();
        }


        public void LeftKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            LeftMove();
        }
        public void RightKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Rotation_90_deg();
            Rotation_90_deg();
            LeftMove();
            Rotation_90_deg();
            Rotation_90_deg();
        }
        public void UpKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Rotation_90_deg();
            Rotation_90_deg();
            Rotation_90_deg();
            LeftMove();
            Rotation_90_deg();
        }
        public void DownKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Rotation_90_deg();
            LeftMove();
            Rotation_90_deg();
            Rotation_90_deg();
            Rotation_90_deg();
        }

        void LeftMove()
        {
            bool MoveOccured = false;
            for (int row = 0; row < SIZE; row++)
            {
                for (int index = 0; index < SIZE - 1; index++)
                {
                    while (index >= 0 && Matrix[row, index] == 0 && Matrix[row, index + 1] != 0)
                    {
                        Swap(ref Matrix[row, index], ref Matrix[row, index + 1]);
                        MoveOccured = true;
                        if (index > 0)
                            index--;
                    }

                    if (Matrix[row, index] != 0 && (Matrix[row, index] == Matrix[row, index + 1]))
                    {
                        Score += Matrix[row, index] *= 2;
                        Matrix[row, index + 1] = 0;
                        MoveOccured = true;
                    }
                }
            }
            bool GameIsOver = false;
            if (!MoveOccured)
            {
                GameIsOver = true;
                for (int i = 0; i < SIZE; i++)
                    if (Matrix[i, SIZE - 1] == 0)
                        GameIsOver = false;
            }
            if (GameIsOver)
            {
                for (int row = 0; row < SIZE; row++)
                {
                    for (int column = 0; column < SIZE; column++)
                    {
                        if ((column < SIZE - 1 && Matrix[row, column] == Matrix[row, column + 1]) || (row < SIZE-1 && Matrix[row, column] == Matrix[row + 1, column]))
                        {
                            GameIsOver = false;
                            break;
                        }
                    }
                }
            }
            if (GameIsOver)
            {
                GameOver(this, new EventArgs());
                return;
            }

            if (MoveOccured)
            {
                for (int i = 0; i < SIZE; i++)
                    if (Matrix[i, SIZE - 1] == 0)
                    {
                        AddRandom();
                        return;
                    }
            }
        }

        void Rotation_90_deg()
        {
            int[,] NewMatrix = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    NewMatrix[i, j] = Matrix[SIZE - 1 - j, i];
                }
            }
            this.Matrix = NewMatrix;
        }

        void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        void AddRandom()
        {
            while (true)
            {
                int index = Random.Next(SIZE* SIZE);
                if (Matrix[index / SIZE, index % SIZE] == 0)
                {
                    Matrix[index / SIZE, index % SIZE] = Random.NextDouble() < 0.9 ? 2 : 4;
                    break;
                }
            }
        }
    }
}
