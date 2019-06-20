using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class Cell
    {
        public Position cellPosition;

        public enum ocupantType { empty,
                                  player,
                                  enemy,
                                  food,
                                  weapon,
                                  trap,
                                  unexplored,
                                  exit };

        public ocupantType[] ocupantList;


        public Cell(int row, int column)
        {
            cellPosition = new Position(row, column);
            ocupantList = new ocupantType[10];
        }
    }
}
