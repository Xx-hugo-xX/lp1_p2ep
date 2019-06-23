using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Cell
    {
        public int cellRow, cellColumn;

        public bool hasBeenExplored { get; set; }

        public enum ocupantType { empty      = '.',
                                  player     = '\u0398',
                                  enemy      = '\u03A8',
                                  food       = '\u03A9',
                                  weapon     = '\u0713',
                                  trap       = '\u0416',
                                  map        = '\u0524',
                                  unexplored = '~',
                                  exit };

        public ocupantType[] ocupantList = new ocupantType[10];


        public Cell(int row, int column)
        {
            cellRow = row;
            cellColumn = column;
            for (int i = 0; i < ocupantList.Length; i++)
            {
                ocupantList[i] = ocupantType.unexplored;
            }
            hasBeenExplored = false;
        }

        public void CheckPlayer(Player player, Position exit)
        {
            if (hasBeenExplored)
            {
                for (int i = 0; i < ocupantList.Length; i++)
                {
                    ocupantList[i] = ocupantType.empty;
                }
            }

            if (player.playerPosition.Row == cellRow &&
                player.playerPosition.Column == cellColumn)
            {
                ocupantList[0] = ocupantType.player;
                for (int i = 1; i < ocupantList.Length; i++)
                {
                    ocupantList[i] = ocupantType.empty;
                }
                hasBeenExplored = true;
            }
            else if (exit.Row == cellRow &&
                exit.Column == cellColumn)
            {
                ocupantList[0] = ocupantType.exit;
            }
            else if (hasBeenExplored) ocupantList[0] = ocupantType.empty;
            else ocupantList[0] = ocupantType.unexplored;
        }
    }
}
