using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Position
    {
        // Instance Variables
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructor Method
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
