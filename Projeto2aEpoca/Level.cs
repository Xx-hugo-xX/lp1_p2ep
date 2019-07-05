using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Level
    {
        // Instance Variables
        public int currentLevel;
        public int currentLevelDifficulty;

        public int numberOfCells = 0;
        public int numberOfTraps = 0;

        public Position exit;
        public Position map;
        
        public List<Trap> trapList;

        List<Cell> CellList;
        Board Board;
        Player Player;
        
        /* Not Necessary For "Fase 04":
         *  List<Enemy> enemyList = new List<Enemy>();
         */

        // Constructor Method
        public Level(Board board, Player player)
        {
            Board = board;
            Player = player;
            CellList = Board.cellList;

            numberOfCells = Board.Rows * Board.Columns;
            trapList = new List<Trap>();
            
            currentLevel = 1;
        }


        public void StartNewLevel()
        {
            currentLevelDifficulty = currentLevel + Board.Difficulty;
            numberOfTraps = numberOfCells * (currentLevelDifficulty) / 50;

            CellList.Clear();
            trapList.Clear();
            
            // Create Cell's According To Grid Size
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    CellList.Add(new Cell(i, j));
                }
            }
            
            Random random = new Random();

            // Sets Player's Beginning Position (Cell)
            Player.playerPosition = new Position(random.Next(Board.Rows), 0);

            // Sets Exit's Position (Cell)
            exit = new Position(random.Next(Board.Rows), Board.Columns - 1);

            // Sets Map's Position (Cell)
            map = new Position(exit.Row, exit.Column);
            while (map.Row == exit.Row && map.Column == exit.Column)
            {
                map = new Position(random.Next(Board.Rows),
                                   random.Next(Board.Columns));
            }

            Array types = Enum.GetValues(typeof(TrapTypes));
            for (int i = 0; i < numberOfTraps; i++)
            {
                int row = 0;
                int column = 0;

                TrapTypes randomType = 
                    (TrapTypes)types.GetValue(random.Next(types.Length));

                bool validPosition = false;

                while (!validPosition)
                {
                    row = random.Next(Board.Rows);
                    column = random.Next(Board.Columns);

                    if (row == exit.Row && column == exit.Column)
                    {
                        continue;
                    }
                    else if (row == Player.playerPosition.Row &&
                             column == Player.playerPosition.Column)
                    {
                        continue;
                    }
                    else validPosition = true;
                }

                trapList.Add(new Trap(randomType, row, column));
            }
        }

        // Begin Change To Next Level
        public void NextLevel()
        {
            currentLevel++;
        }
    }
}
