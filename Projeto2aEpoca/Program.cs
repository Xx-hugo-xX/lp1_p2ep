using System;

namespace Projeto2aEpoca
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance Variables
            int rows = 0;
            int columns = 0;
            int difficulty = 0;


            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-r":
                        rows = Convert.ToInt32(args[i+1]);
                        break;

                    case "-c":
                        columns = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-d":
                        difficulty = Convert.ToInt32(args[i + 1]);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Rows: " + rows + "\nColumns: " + columns + "\nDifficulty: " + difficulty);

            Board board = new Board(rows, columns);
        }
    }
}
