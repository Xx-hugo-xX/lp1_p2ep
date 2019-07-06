using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Board
    {
        /// <summary>
        /// Creats the game board
        /// </summary>
       
        // Instance Variables
        public int Rows, Columns, Difficulty;
        public List<Cell> cellList;

        // Constructor Method
        public Board(int rows, int columns, int difficulty)
        {
            Rows = rows;
            Columns = columns;
            Difficulty = difficulty;
            cellList = new List<Cell>();
        }

        // Changes All Cell's State To 'Explored'
        public void exploreAllCells()
        {
            foreach (Cell cell in cellList)
            {
                cell.hasBeenExplored = true;
            }
        }
    }
}
