using SudokuClassLibrary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Board b = new Board();
            b.FillBoard();
            b.SolveBoard();

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (y == 2 || y == 5)
                    {
                        Console.Write(b.BoardArray[x, y] + " | ");
                    }
                    else
                    {
                        Console.Write(b.BoardArray[x, y] + " ");
                    }
                }
                Console.WriteLine();
                if (x == 2 || x == 5)
                {
                    Console.WriteLine("--------------------");
                }
            }
        }
    }
}
