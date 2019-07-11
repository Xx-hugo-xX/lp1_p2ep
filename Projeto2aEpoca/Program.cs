using System;
using System.Text;

namespace Projeto2aEpoca
{
    class Program
    {
        /// <summary>
        /// Main Method That Runs Program And
        /// Takes Arguments Given In The Console
        /// </summary>
        /// <param name="args">Arguments Given In The Console</param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Creates An Instance Of 'Renderer' And 'Player'
            Renderer renderer = new Renderer();
            Player player = new Player();
            PossibleItems possibleItems = new PossibleItems();


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
                        // Checks If It's An Int, Leaves Program If It Isn't
                        if (int.TryParse(args[i + 1], out rows)) break;
                        else
                        {
                            renderer.HowToUse("ROWS");
                            return;
                        }

                    case "-c":
                        // Checks If It's An Int, Leaves Program If It Isn't
                        if (int.TryParse(args[i + 1], out columns)) break;
                        else
                        {
                            renderer.HowToUse("COLUMN");
                            return;
                        }

                    case "-d":
                        // Checks If It's An Int, Leaves Program If It Isn't
                        if (int.TryParse(args[i + 1], out difficulty))
                        {
                            if (difficulty > 10) difficulty = 10;
                            if (difficulty < 1) difficulty = 1;
                            break;
                        }
                        else
                        {
                            renderer.HowToUse("DIFFICULTY");
                            return;
                        }

                    default:
                        break;
                }
            }

            // Creates An Instance Of 'Board', 'Level', HighScoreManager
            // And 'Game'
            Board board = new Board(rows, columns, difficulty);
            Level level = new Level(board, player, possibleItems);
            HighScoreManager highScoreManager =
                                           new HighScoreManager(board, player);

            Game game = new Game(board, renderer, level,
                                 player, highScoreManager);

            // Runs The Game Loop
            game.MainLoop();
        }
    }
}
