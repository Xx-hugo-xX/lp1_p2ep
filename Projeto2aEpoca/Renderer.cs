using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class Renderer
    {
        public void ShowGameValues(Board board)
        {
            string levelDisplay = board.level.ToString().PadLeft(3, '0');
            string difficultyDisplay = board.Difficulty.ToString().
                                                               PadLeft(2, '0');
            string rowsDisplay = board.Rows.ToString().PadLeft(2, '0');
            string columnsDisplay = board.Columns.ToString().PadLeft(2, '0');

            Console.WriteLine($"++++++++++++++++ LP1 Rogue : Level {levelDisplay}" +
                $" : Difficulty {difficultyDisplay} : Size {rowsDisplay} x" +
                $" {columnsDisplay} ++++++++++++++++\n\n");
        }

        public void DrawMap(Board board)
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
                                Console.Write("|    ~~~~~    ");

                                foreach (int endSpace in endSpaces)
                                {
                                    if (space == endSpace)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                break;

                            case 3:
                                Console.Write("|    ~~~~~    ");

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
            // Shows whats on each *visible* cell (fase 2)
        }

        public void MainMenu()
        {
            Console.WriteLine("1. New Game    \n" +
                              "2. High Scores \n" +
                              "3. Credits     \n" +
                              "4. Quit        \n");
        }

        public void HighScores()
        {
            // Displays the highest scores (fase 5)
        }

        public void Credits()
        {
            Console.WriteLine("This program was made by:\n " +
                              "Hugo Feliciano (a21805809)\n" +
                              "Pedro Fernandes (a21803791)\n" +
                              "Rita Saraiva (a21807278).");
        }
    }
}