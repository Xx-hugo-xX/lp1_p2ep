using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Board
    {
        //Instance Variables
        public int Rows, Columns, Difficulty;
        public int level;

        public Position exitPosition;

        public List<Cell> cellList;

        //Constructor Method
        public Board(int rows, int columns, int difficulty)
        {
            Rows = rows;
            Columns = columns;
            Difficulty = difficulty;

            cellList = new List<Cell>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    cellList.Add(new Cell(i, j));
                }
            }
        }
    }
}
