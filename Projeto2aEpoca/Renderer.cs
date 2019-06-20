using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class Renderer
    {
        void DrawMap(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {

            }
        }


        void PrintCell()
        {
            //DoSomething
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
            //DoSomething
        }

        public void Credits()
        {
            Console.WriteLine("This program was made by " +
                              "Hugo Feliciano (a21805809)," +
                              "Pedro Fernandes (a21803791) and" +
                              "Rita Saraiva (a21807278).");
        }
    }
}
