using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Level
    {
        public int currentLevel;
        public Position exit;

        Board Board;
        Player Player;

        List<Cell> CellList;

        //List<Enemy> enemyList = new List<Enemy>();
        //List<Trap> trapList = new List<Trap>();

        public Level(Board board, Player player)
        {
            Board = board;
            Player = player;
            CellList = Board.cellList;

            currentLevel = 1;
        }


        public void StartNewLevel()
        {
            CellList.Clear();

            Random random = new Random();
            Player.playerPosition =
                new Position(random.Next(Board.Rows), 0);

            exit = new Position(random.Next(Board.Rows), Board.Columns-1);

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    CellList.Add(new Cell(i, j));
                }
            }
        }

        public void NextLevel()
        {
            currentLevel++;
        }
    }
}
