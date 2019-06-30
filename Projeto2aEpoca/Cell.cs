using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Cell
    {
        // Instance Variables
        public int cellRow, cellColumn;
        public bool hasBeenExplored { get; set; }
        public occupantType[] occupantList = new occupantType[10];


        // Possible Cell Occupants
        public enum occupantType
        {
            empty = '.',
            player = '\u0398',
            enemy = '\u03A8',
            food = '\u03A9',
            weapon = '\u03EF',
            trap = '\u0416',
            map = '\u0524',
            exit
        };

        // Constructor Method
        public Cell(int row, int column)
        {
            cellRow = row;
            cellColumn = column;
            for (int i = 0; i < occupantList.Length; i++)
            {
                occupantList[i] = occupantType.empty;
            }
            hasBeenExplored = false;
        }
        
        // Checks Cell Occupants and Adds Them To The List
        public void CheckOccupants(Player player, Level level)
        {
            if (level.exit.Row == cellRow &&
                level.exit.Column == cellColumn)
            {
                occupantList[0] = occupantType.exit;
            }

            if (player.playerPosition.Row == cellRow &&
                player.playerPosition.Column == cellColumn)
            {
                occupantList[0] = occupantType.player;
                hasBeenExplored = true;
            }

            else occupantList[0] = occupantType.empty;

            if (!player.hasMap && level.map.Row == cellRow &&
                level.map.Column == cellColumn)
            {
                occupantList[9] = occupantType.map;
            }

            else occupantList[9] = occupantType.empty;

            if (level.exit.Row == cellRow &&
                     level.exit.Column == cellColumn)
            {
                occupantList[0] = occupantType.exit;
            }
        }
    }
}