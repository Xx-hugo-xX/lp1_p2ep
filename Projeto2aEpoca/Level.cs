using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Level
    {
        // Instance Variables
        public int currentLevel;
        public Position exit;
        public Position map;
        Board Board;
        Player Player;

        List<Cell> CellList;

        /* Not Necessary For "Fase 03":
         *  List<Enemy> enemyList = new List<Enemy>();
         *  List<Trap> trapList = new List<Trap>();
         */
        
        // Constructor Method
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

            // Sets Player's Beginning Position (Cell)
            Player.playerPosition = new Position(random.Next(Board.Rows), 0);
            // Sets Exit's Position (Cell)
            exit = new Position(random.Next(Board.Rows), Board.Columns-1);
            
            // Sets Map's Position (Cell)
            map = new Position(exit.Row, exit.Column);
            while (map.Row == exit.Row && map.Column == exit.Column)
            {
                map = new Position(random.Next(Board.Rows),
                                   random.Next(Board.Columns));
            }

            // Create Cell's According To Grid Size
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    CellList.Add(new Cell(i, j));
                }
            }
        }

        // Begin Change To Next Level
        public void NextLevel()
        {
            currentLevel++;
        }
    }
}
