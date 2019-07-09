using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Position
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public int Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// Creates An Instance Of Position
        /// </summary>
        /// <param name="row">Sets Row For The Position</param>
        /// <param name="column">Sets Column For The Position</param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
