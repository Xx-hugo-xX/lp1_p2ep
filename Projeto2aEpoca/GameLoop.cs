using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class GameLoop
    {
        bool play = true;
        public void PlayGame(Board board, Renderer renderer)
        {
            while (play)
            {
                renderer.ShowGameValues(board);
                renderer.DrawMap(board);
                Console.ReadLine();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    play = false;
                }
            }
        }
    }
}