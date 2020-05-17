using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SudokuClassLibrary
{
    public class Board
    {
        public int[,] BoardArray { get; set; }
        private Random Rand { get; set; }

        public Board()
        {
            BoardArray = new int[9, 9];
            Rand = new Random();
        }

        //Fill board random numbers.
        public void FillBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                var randomIndices = GetRandomIndices();
                for (int j = 0; j < 9; j++)
                {
                    BoardArray[i, j] = randomIndices[j];
                }
            }
        }

        public void SolveBoard()
        {
            int[] currentBox = new int[9];
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (y == 0)
                    {
                        currentBox = GetCurrentBoxNumbers(x, y);
                    }
                    if (x == 3 || x == 6)
                    {
                        currentBox = GetCurrentBoxNumbers(x, y);
                    }

                    if (y == 3 || y == 6)
                    {
                        currentBox = GetCurrentBoxNumbers(x, y);
                    }

                    var n = currentBox.GroupBy(e => e).Where(e => e.Count() > 1).Select(e => e.First());
                    if (n.Count() > 0)
                    {
                        if (n.Contains(BoardArray[x, y]))
                        {
                            BoardArray[x, y] = 0;
                            currentBox[y] = 0;
                        }
                    }
                }
            }
        }

        public int[] GetCurrentBoxNumbers(int x, int y)
        {
            int[] currentBox = new int[9];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //First row
                    if (x < 3 && y < 3)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[i, j];
                    }
                    else if (x < 3 && y > 2 && y < 6)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[i, 3 + j];
                    }
                    else if (x < 3 && y > 5 && y < 9)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[i, 6 + j];
                    }

                    //Second row
                    else if (x > 2 && x < 6 && y < 3)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[3 + i, j];
                    }
                    else if (x > 2 && x < 6 && y > 2 && y < 6)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[3 + i, 3 + j];
                    }
                    else if (x > 2 && x < 6 && y > 5 && y < 9)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[3 + i, 6 + j];
                    }

                    //Third row
                    else if (x > 5 && x < 9 && y < 3)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[6 + i, j];
                    }
                    else if (x > 5 && x < 9 && y > 2 && y < 6)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[6 + i, 3 + j];
                    }
                    else if (x > 5 && x < 9 && y > 5 && y < 9)
                    {
                        currentBox[(i * 3) + (j)] = BoardArray[6 + i, 6 + j];
                    }
                }
            }
            return currentBox;
        }

        public List<int> GetRandomIndices()
        {
            List<int> randomIndices = new List<int>();
            List<int> indices = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                indices.Add(i + 1);
            }
            for (int i = 0; i < 9; i++)
            {
                randomIndices.Add(indices[Rand.Next(indices.Count)]);
                indices.Remove(randomIndices[i]);
            }
            return randomIndices;
        }
    }
}
