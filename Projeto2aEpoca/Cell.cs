using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Cell
    {
        public int cellRow, cellColumn;
        public Position cellPosition;

        public enum ocupantType { empty      = '.',
                                  player     = 'P',
                                  enemy      = 'E',
                                  food       = 'F',
                                  weapon     = 'W',
                                  trap       = 'T',
                                  unexplored = 'U',
                                  exit       = 'E'};

        public ocupantType[] ocupantList = new ocupantType[10];


        public Cell(int row, int column)
        {
            cellRow = row;
            cellColumn = column;
            cellPosition = new Position(cellRow, cellColumn);
            for (int i = 0; i < ocupantList.Length; i++)
            {
                ocupantList[i] = ocupantType.empty;
            }
        }

        public void CheckPlayer(Player player)
        {
            if (player.playerPosition == cellPosition)
            {
                Console.WriteLine("É IGUAL CARALHUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU");
                ocupantList[0] = ocupantType.player;
            }
            else ocupantList[0] = ocupantType.empty;
        }
    }
}
