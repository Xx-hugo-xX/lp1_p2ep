using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Projeto2aEpoca
{
    public class Renderer
    {
        /// <summary>
        /// Contains all the functions of to draw the map, menus, and the 
        /// text during the game.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="level"></param>
        
        public void ShowGameValues(Board board, Level level)
        {
            // Shows Current Level
            string levelDisplay =
                level.currentLevel.ToString().PadLeft(3, '0');

            // Shows Current Difficulty
            string difficultyDisplay =
                board.Difficulty.ToString().PadLeft(2, '0');

            // Shows Grid
            string rowsDisplay = board.Rows.ToString().PadLeft(2, '0');
            string columnsDisplay = board.Columns.ToString().PadLeft(2, '0');

            Console.WriteLine(
                $"++++++++++++++++ LP1 Rogue : Level {levelDisplay}" +
                $" : Difficulty {difficultyDisplay} : Size {rowsDisplay} x" +
                $" {columnsDisplay} ++++++++++++++++\n\n");
        }

        public void ShowPlayerStats(Player player)
        {
            Console.WriteLine("Player Stats");
            Console.WriteLine("------------");
            Console.WriteLine($"\nHP: {player.hp.ToString("0.0")}\t" +
                              $"Score: {player.score.ToString("0.0")}\n");
        }

        public void ShowLegend()
        {
            Console.WriteLine(
                "Options                                 Legend");
            Console.WriteLine(
                "-------                                 ------");
            Console.WriteLine(
                "↖ ↑ ↗        7 8 9                      \u0398 - Player");
            Console.WriteLine(
                "←   →   ->   4   6   Move               \u03A8 - Enemy");
            Console.WriteLine(
                "↙ ↓ ↘        1 2 3                      \u03EF - Weapon");
            Console.WriteLine(
                "                                        \u03A9 - Food");
            Console.WriteLine(
                "(F) Attack Enemy   (E) Pick Up Item     \u0416 - Trap");
            Console.WriteLine(
                "(U) Use Item       (D) Drop Item        \u0524 - Map");
            Console.WriteLine(
                "(L) Look Around    (H) Help             . - Empty");
            Console.WriteLine(
                "(S) Save Game      (Q) Quit Game        ~ - Unexplored");
        }

        // Shows Messages (Trap Activation)
        public void ShowMessage(string m1, string m2, string m3)
        {
            Console.WriteLine("Messages:");
            Console.WriteLine("---------");
            Console.WriteLine(m1 + "\n");
            Console.WriteLine(m2 + "\n");
            Console.WriteLine(m3 + "\n\n");
        }
        
        public void DrawMap(Board board, Level level)
        {
            int rows = board.Rows;
            int columns = board.Columns;
            int lines = 5;
            int cell;

            List<int> endSpaces = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                int spaceAdded = columns * (i + 1);
                endSpaces.Add(spaceAdded);
            }

            // For Every Row
            for (int i = 0; i < rows; i++)
            {
                // For Every 'Line'
                for (int j = 0; j < lines; j++)
                {
                    // For Every Column
                    for (int k = 0; k < columns; k++)
                    {
                        // Calculates Number Of Cell
                        cell = i * columns + k + 1;

                        switch (j)
                        {
                            case 0:
                                Console.Write("+-------------");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (cell == endSpace)
                                    {
                                        Console.Write("+");
                                    }
                                }
                                break;

                            case 1:
                                Console.Write($"|             ");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (cell == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;
                            
                            // Cell Details (1)
                            case 2:
                                // "Unexplored"
                                if (!board.cellList[cell - 1].hasBeenExplored)
                                {
                                    Console.Write("|    ~~~~~    ");
                                }

                                // "Exit"
                                else if (
                                    level.exit.Row == board.cellList[cell - 1]
                                    .cellRow && level.exit.Column ==
                                    board.cellList[cell - 1].cellColumn)
                                {
                                    Console.Write("|    EXIT!    ");
                                }

                                // "Explored"
                                else
                                {
                                    Console.Write("|    ");

                                    for (int l = 0; l < 5; l++)
                                    {
                                        Console.Write((char)board.
                                            cellList[cell - 1].
                                            occupantList.ElementAt(l));
                                    }
                                    Console.Write("    ");
                                }

                                foreach (int endSpace in endSpaces)
                                {
                                    if (cell == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            // Cell Details (2)
                            case 3:
                                // "Unexplored"
                                if (!board.cellList[cell - 1].hasBeenExplored)
                                {
                                    Console.Write("|    ~~~~~    ");
                                }

                                // "Exit"
                                else if (
                                    level.exit.Row == board.cellList[cell - 1]
                                    .cellRow && level.exit.Column ==
                                    board.cellList[cell - 1].cellColumn)
                                {
                                    Console.Write("|    EXIT!    ");
                                }

                                // "Explored"
                                else
                                {
                                    Console.Write("|    ");

                                    for (int l = 5; l < 10; l++)
                                    {
                                        Console.Write((char)board.
                                            cellList[cell - 1].
                                            occupantList.ElementAt(l));
                                    }
                                    Console.Write("    ");
                                }

                                foreach (int endSpace in endSpaces)
                                {
                                    if (cell == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            case 4:
                                Console.Write("|             ");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (cell == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;
                        }
                    }
                    Console.Write("\n");
                }
            }
            Console.Write("+");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("-------------+");
            }
            Console.Write("\n\n");
        }
        
        public void MainMenu()
        {
            Console.WriteLine("1. New Game    \n" + 
                              "2. High Scores \n" +
                              "3. Credits     \n" + 
                              "4. Quit        \n");
        }

        public void HighScores(Board board)
        {
            string fileName = $"HighScores_{board.Rows}x{board.Columns}.txt";
            char separator = '\t';

            StreamReader sr = new StreamReader(fileName);
            string s;

            Console.WriteLine($"+++++++++ {board.Rows}x{board.Columns} " +
                              $"HighScores +++++++++\n");

            while ((s = sr.ReadLine()) != null)
            {
                string[] nameAndScore = s.Split(separator);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                Console.WriteLine($"Player: {name}\tScore: {score,4}");
            }

            Console.WriteLine("\n\nPress any key to return");

            sr.Close();
        }

        public void Credits()
        {
            Console.WriteLine("This program was made by:\n\n" +
                              "\tHugo Feliciano  (a21805809)\n" +
                              "\tPedro Fernandes (a21803791)\n" +
                              "\tRita Saraiva    (a21807278)\n\n");

            Console.WriteLine("Press any key to return");
        }

        public void QuitGame()
        {
            string option = "";
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit? " +
                              "Your progress will be lost...");

            Console.WriteLine("'Y' / 'N'");

            while (option != "Y" && option != "N")
            {
                option = Console.ReadLine();
                if (option != "Y" && option != "N")
                {
                    Console.WriteLine("Answer not valid");
                }
            }

            if (option == "Y")
            {
                Environment.Exit(0);
            }
        }

        public void HowToUse()
        {
            Console.WriteLine("Here's an example of how to use the arguments:" +
                "\n\tdotnet run -- -r 7 -c 8 -d 5\n" +
                "\t-r represents the number of rows in the board" +
                "\t-c represents the number of columns in the board" +
                "\t-d represents the difficulty of the game you're playing");
        }
    }
}
