using System.Collections.Generic;

namespace Projeto2aEpoca
{
    /// <summary>
    /// Creats the game board
    /// </summary>

    public class Board
    {
        /// <summary>
        /// Instance Variable
        /// </summary>
        public int Rows, Columns, Difficulty;
        public List<Cell> cellList;

        /// <summary>
        /// Creates An Instance Of 'Board'
        /// </summary>
        /// <param name="rows">Rows For The Board</param>
        /// <param name="columns">Columns For The Board</param>
        /// <param name="difficulty">Difficulty For The Game</param>
        public Board(int rows, int columns, int difficulty)
        {
            Rows = rows;
            Columns = columns;
            Difficulty = difficulty;
            cellList = new List<Cell>();
        }

        /// <summary>
        /// Sets All Cell's State To Explored
        /// </summary>
        public void exploreAllCells()
        {
            foreach (Cell cell in cellList)
            {
                cell.hasBeenExplored = true;
            }
        }
    }
}
