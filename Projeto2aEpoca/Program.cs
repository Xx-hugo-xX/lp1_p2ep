using System;
using System.Text;

namespace Projeto2aEpoca
{
    class Program
    {
        /// <summary>
        /// Contains main method. Runs program and takes arguments given in 
        /// console
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Instance Variables
            int rows = 0;
            int columns = 0;
            int difficulty = 0;


            for (int i = 0; i < args.Length; i++)
            {
                // Interprets Console Arguments
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
                        if (difficulty > 10) difficulty = 10;
                        break;
                    default:
                        break;
                }
            }


            Renderer renderer = new Renderer();
            Board board = new Board(rows, columns, difficulty);
            Player player = new Player(0, 0);
            Level level = new Level(board, player);
            GameLoop gameLoop = new GameLoop(board, renderer, level, player);

            gameLoop.PlayGame();
        }
    }
}
