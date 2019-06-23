using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class GameLoop
    {
        Board Board;
        Renderer Renderer;
        Level Level;
        Player Player;

        bool playing = true;

        public GameLoop(Board board, Renderer renderer, Level level, Player player)
        {
            Board = board;
            Renderer = renderer;
            Level = level;
            Player = player;
        }


        public void PlayGame()
        {
            while (playing)
            {
                Level.StartNewLevel();
                bool finishedLevel = false;
                bool madeTurn;
                while (!finishedLevel)
                {
                    foreach (Cell cell in Board.cellList)
                    {
                        cell.CheckPlayer(Player, Level.exit);
                    }

                    Renderer.ShowGameValues(Board, Level);
                    Renderer.ShowPlayerHealth(Player);
                    Renderer.DrawMap(Board, Level);
                    Console.WriteLine("Press 1, 2, 3, 4, 6, 7, 8 or 9 to move, according to the keypad. Then press enter to register movement");
                    int moveOption = Convert.ToInt32(Console.ReadLine());

                    Player.Move(moveOption, Board);
                    madeTurn = Player.hasMoved;

                    if (Player.playerPosition.Row == Level.exit.Row && Player.playerPosition.Column == Level.exit.Column)
                    {
                        Level.NextLevel();
                        finishedLevel = true;
                    }

                    if (madeTurn) Player.hp -= 1.0f;
                }
            }
        }
    }
}