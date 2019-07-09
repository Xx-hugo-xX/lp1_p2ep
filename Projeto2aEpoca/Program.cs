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


            Renderer renderer = new Renderer();


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
                        if (int.TryParse(args[i + 1], out rows)) break;
                        else
                        {
                            Console.WriteLine("Invalid value for ROWS.\n\n");
                            renderer.HowToUse();
                            return;
                        }

                    case "-c":
                        if (int.TryParse(args[i + 1], out columns)) break;
                        else
                        {
                            Console.WriteLine("Invalid value for COLUMNS.\n\n");
                            renderer.HowToUse();
                            return;
                        }

                    case "-d":
                        if (int.TryParse(args[i + 1], out difficulty))
                        {
                            if (difficulty > 10) difficulty = 10;
                            if (difficulty < 1) difficulty = 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for DIFFICULTY.\n\n");
                            renderer.HowToUse();
                            return;
                        }

                    default:
                        break;
                }
            }


            Board board = new Board(rows, columns, difficulty);
            Player player = new Player(0, 0);
            Level level = new Level(board, player);
            Game game = new Game(board, renderer, level, player);

            game.MainLoop();
        }
    }
}
