using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class GameLoop
    {
        Board Board;
        Renderer Renderer;

        bool play = true;
        bool finishedLevel = false;

        public GameLoop(Board board, Renderer renderer)
        {
            Board = board;
            Renderer = renderer;
        }


        public void PlayGame()
        {
            Position playerSpawn = PlayerSpawnPosition();
            Player player = new Player(playerSpawn.Row, playerSpawn.Column);
            while (play)
            {
                Renderer.ShowGameValues(Board);
                Renderer.DrawMap(Board, player);
                Console.WriteLine($"\n\n{player.playerPosition.Row},{player.playerPosition.Column}\n\n");
                Console.WriteLine("Press 1, 2, 3, 4, 6, 7, 8 or 9 to move, according to the keypad. Then press enter to register movement");
                int moveOption = Convert.ToInt32(Console.ReadLine());

                player.Move(moveOption, Board.Rows, Board.Columns);

                if (player.playerPosition == board.exitPosition)
                {
               
                }
            }
        }
        public Position PlayerSpawnPosition()
        {
            int row;
            int column = 0;
            Position spawnPosition;
            Random random = new Random();

            row = random.Next(0, Board.Rows +1);
            spawnPosition = new Position(row, column);

            return spawnPosition;
        }

    }
}