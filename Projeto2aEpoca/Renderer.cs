using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Renderer
    {
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
            Console.WriteLine($"\nHP: {player.hp}\n");
        }

        public void ShowOptions()
        {
            Console.WriteLine("Options");
            Console.WriteLine("-------");
            Console.WriteLine(
                "↖ ↑ ↗        7 8 9          (F)Attack Enemy(E) Pick up item"
                + "(U) Use item(D) Drop item");
            Console.WriteLine(
                "←   →   ->   4   6  Move    (L) Look around(H) Help");
            Console.WriteLine(
                "↙ ↓ ↘        1 2 3          (S)Save game(Q) Quit game");

        }

        public void ShowLegend()
        {
            Console.WriteLine(
                "Options                                 Legend");
            Console.WriteLine(
                "------                                  ------");
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

        public void DrawMap(Board board, Level level)
        {
            int rows = board.Rows;
            int columns = board.Columns;
            int lines = 5;
            int space;

            List<int> endSpaces = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                int spaceAdded = columns * (i + 1);
                endSpaces.Add(spaceAdded);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        space = i * columns + k + 1;
                        string spaceD = space.ToString().PadLeft(3, '0');

                        switch (j)
                        {
                            case 0:
                                Console.Write("+-------------");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (space == endSpace)
                                    {
                                        Console.Write("+");
                                    }
                                }

                                break;

                            case 1:
                                Console.Write($"|             ");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (space == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            case 2:
                                // "Unexplored"
                                if (!board.cellList[space-1].hasBeenExplored)
                                {
                                    Console.Write("|    ~~~~~    ");
                                }
                                // "Exit"
                                else if (
                                    level.exit.Row == board.cellList[space - 1]
                                    .cellRow && level.exit.Column ==
                                    board.cellList[space - 1].cellColumn)
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
                                            cellList[space - 1].
                                            occupantList[l]);
                                    }
                                    Console.Write("    ");
                                }

                                foreach (int endSpace in endSpaces)
                                    {
                                        if (space == endSpace)
                                        {
                                            Console.Write("|");
                                        }
                                    }

                                break;

                            case 3:
                                // "Unexplored"
                                if (!board.cellList[space - 1].hasBeenExplored)
                                {
                                    Console.Write("|    ~~~~~    ");
                                }
                                // "Exit"
                                else if (
                                    level.exit.Row == board.cellList[space - 1]
                                    .cellRow && level.exit.Column ==
                                    board.cellList[space - 1].cellColumn)
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
                                            cellList[space - 1].
                                            occupantList[l]);
                                    }
                                    Console.Write("    ");
                                }
                                foreach (int endSpace in endSpaces)
                                {
                                    if (space == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            case 4:
                                Console.Write("|             ");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (space == endSpace)
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


        void PrintCell()
        {
            // Not Necessary For "Fase 03"
        }

        public void MainMenu()
        {
            Console.WriteLine("1. New Game    \n" + "2. High Scores \n" +
                              "3. Credits     \n" + "4. Quit        \n");
        }

        public void HighScores()
        {
            // Not Necessary For "Fase 03"
            Console.WriteLine("Press any key to return");

        }

        public void Credits()
        {
            Console.WriteLine("This program was made by:\n " +
                              "Hugo Feliciano (a21805809)\n" +
                              "Pedro Fernandes (a21803791)\n" +
                              "Rita Saraiva (a21807278)");

            Console.WriteLine("Press any key to return");
        }
    }
}