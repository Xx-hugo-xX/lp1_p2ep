using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Board
    {
        //Instance Variables
        public int Rows, Columns, Difficulty;
        public List<Cell> cellList;

        //Constructor Method
        public Board(int rows, int columns, int difficulty)
        {
            Rows = rows;
            Columns = columns;
            Difficulty = difficulty;
            cellList = new List<Cell>();
        }
    }
}
