using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Projeto2aEpoca
{
    public class Renderer
    {
        /// <summary>
        /// Displays Current Level, Difficulty And Board Size
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        /// <param name="level">Level That Stores The Current Level</param>
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

        /// <summary>
        /// Displayers Players Stats (HP And Score)
        /// </summary>
        /// <param name="player">Player That Contains The HP And Score</param>
        public void ShowPlayerStats(Player player)
        {
            Console.WriteLine("Player Stats");
            Console.WriteLine("------------");
            Console.WriteLine($"\nHP: {player.hp.ToString("0.0")}\t" +
                              $"Score: {player.score.ToString("0.0")}\t" +
                              $"Inventory: {player.getInventoryWeight.ToString("0.0")}% full\n");
        }

        /// <summary>
        /// Displays The Input Options And The Legend For The Board Symbols
        /// </summary>
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

        /// <summary>
        /// Displays All Weapons And Their Corresponding Values,
        /// And Displays All Foods And Their Corresponding Values
        /// </summary>
        /// <param name="possibleItems">
        /// Class That Contains The Arrays Of
        /// All Possible Weapons And Food</param>
        public void ShowHelp(PossibleItems possibleItems)
        {
            Console.Clear();

            Console.WriteLine("Weapons");
            Console.WriteLine("-------");
            
            // Loops Through List Of All Possible Weapons
            // And Displays Their Values, One By One
            for (int i = 0; i < possibleItems.weapons.Length; i++)
            {
                Console.Write($"Name: {possibleItems.weapons[i].Name}\t\t");
                if (i == 0 || i == 1 || i == 4) Console.Write("\t");
                Console.Write($"AttackPower: {possibleItems.weapons[i].AttackPower}\t\t");
                Console.Write($"Weight: {possibleItems.weapons[i].Weight}\t\t");
                Console.Write($"Durability: {possibleItems.weapons[i].Durability}\n");
            }

            Console.WriteLine("\nFood");
            Console.WriteLine("----");

            // Loops Through List Of All Possible Foods
            // And Displays Their Values, One By One
            for (int i = 0; i < possibleItems.foods.Length; i++)
            {
                Console.Write($"Name: {possibleItems.foods[i].Name}\t\t");
                if (i == 1 || i == 3) Console.Write("\t");
                Console.Write($"HPIncrease: {possibleItems.foods[i].HPIncrease}\t\t");
                Console.Write($"Weight: {possibleItems.foods[i].Weight}\n");
            }
            Console.WriteLine("\n\nPress any key to return");
            Console.ReadLine();
        }

        /// <summary>
        /// Displays Event Messages 
        /// </summary>
        /// <param name="m1">First Message</param>
        /// <param name="m2">Second Message</param>
        /// <param name="m3">Third Message</param>
        public void ShowMessage(string m1, string m2, string m3)
        {
            Console.WriteLine("Messages:");
            Console.WriteLine("---------");
            Console.WriteLine(m1 + "\n");
            Console.WriteLine(m2 + "\n");
            Console.WriteLine(m3 + "\n\n");
        }

        /// <summary>
        /// Draws The Board
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        /// <param name="level">
        /// Level To Use It's Exit And Traps Positions</param>
        public void DrawBoard(Board board, Level level)
        {
            // Instance Variables
            int rows = board.Rows;
            int columns = board.Columns;
            int lines = 5;
            int cell;

            List<int> endCells = new List<int>();

            // Defines Which Cells Are On The Last Column
            for (int i = 0; i < rows; i++)
            {
                int cellAdded = columns * (i + 1);
                endCells.Add(cellAdded);
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
                        cell = i * columns + k +1;

                        switch (j)
                        {
                            // First Line (Top Cell Limitation)
                            case 0:
                                Console.Write("+-------------");

                                foreach (int endCell in endCells)
                                {
                                    if (cell == endCell)
                                    {
                                        Console.Write("+");
                                    }
                                }
                                break;

                            // Empty Line
                            case 1:
                                Console.Write($"|             ");

                                foreach (int endCell in endCells)
                                {
                                    if (cell == endCell)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            // Cell Details (1)
                            case 2:
                                // "Unexplored"
                                if (!board.cellList[cell-1].hasBeenExplored)
                                {
                                    Console.Write("|    ~~~~~    ");
                                }

                                // "Exit"
                                else if (
                                    level.exit.Row == board.cellList[cell-1]
                                    .cellRow && level.exit.Column ==
                                    board.cellList[cell -1].cellColumn)
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
                                            cellList[cell-1].
                                            occupantList.ElementAt(l));
                                    }
                                    Console.Write("    ");
                                }

                                foreach (int endCell in endCells)
                                {
                                    if (cell == endCell)
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
                                    level.exit.Row == board.cellList[cell -1]
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

                                foreach (int endCell in endCells)
                                {
                                    if (cell == endCell)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            // Empty Line
                            case 4:
                                Console.Write("|             ");

                                foreach (int endCell in endCells)
                                {
                                    if (cell == endCell)
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

        /// <summary>
        /// Displays The Main Menu Options
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("1. New Game    \n" +
                              "2. High Scores \n" +
                              "3. Credits     \n" +
                              "4. Quit        \n");
        }

        /// <summary>
        /// Reads Correct HighScores File And Displays It's Values
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        public void HighScores(Board board)
        {
            // Sets fileName And Separator So The File Can Be Read
            string fileName = $"HighScores_{board.Rows}x{board.Columns}.txt";
            char separator = '\t';

            // Opens File As A StreamReader
            StreamReader sr = new StreamReader(fileName);
            string s;

            Console.WriteLine($"+++++++++ {board.Rows}x{board.Columns} " +
                              $"HighScores +++++++++\n");

            // loops Through Each Line Of The File And Displays The Scores
            while ((s = sr.ReadLine()) != null)
            {
                string[] nameAndScore = s.Split(separator);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                Console.WriteLine($"Player: {name}\tScore: {score,4}");
            }

            Console.WriteLine("\n\nPress any key to return");

            // Closes the File So It can Be Used In Other Methods
            sr.Close();
        }

        /// <summary>
        /// Displays Credits
        /// </summary>
        public void Credits()
        {
            Console.WriteLine("This program was made by:\n\n" +
                              "\tHugo Feliciano  (a21805809)\n" +
                              "\tPedro Fernandes (a21803791)\n" +
                              "\tRita Saraiva    (a21807278)\n\n");

            Console.WriteLine("Press any key to return");
        }

        /// <summary>
        /// Displays 'QuitGame' Message and Leaves Game
        /// If The Player Really Wants To Quit
        /// </summary>
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

        /// <summary>
        /// Displays 'HowToUse' Message If User
        /// Inputs An Invalid Argument
        /// /// </summary>
        /// <param name="argument">Argument That Was Invalid</param>
        public void HowToUse(string argument)
        {
            Console.WriteLine($"Invalid value for {argument}.\n\n");

            Console.WriteLine("Here's an example of how to use the arguments:" +
                "\n\tdotnet run -- -r 7 -c 8 -d 5\n" +
                "\t-r represents the number of rows in the board" +
                "\t-c represents the number of columns in the board" +
                "\t-d represents the difficulty of the game you're playing");
        }
    }
}
