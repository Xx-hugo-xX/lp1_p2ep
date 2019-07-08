using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Cell
    {
        /// <summary>
        /// Saves the information about each cell
        /// </summary>
        
        // Instance Variables
        public int cellRow, cellColumn;
        public bool hasBeenExplored { get; set; }

        public List<occupantType> occupantList = new List<occupantType>();


        // Possible Cell Occupants
        public enum occupantType
        {
            empty  = '.',
            player = '\u0398',
            enemy  = '\u03A8',
            food   = '\u03A9',
            weapon = '\u03EF',
            trap   = '\u0416',
            map    = '\u0524',
            exit
        };

        // Constructor Method
        public Cell(int row, int column)
        {
            cellRow = row;
            cellColumn = column;

            hasBeenExplored = false;
        }

        public void CheckOccupants(Player player, Level level)
        {
            /// <summary>
            /// Checks Cell Occupants and Adds Them To 'occupantList' and
            /// fills Remaining (Non-Occupied) Spaces With 'occupantType.empty'
            /// </summary>

            occupantList.Clear();

            // Counter For Occupied Spaces In occupantList
            int occupants = 0;

            // Player
            if (player.playerPosition.Row == cellRow &&
                player.playerPosition.Column == cellColumn)
            {
                occupantList.Add(occupantType.player);
                occupants++;
                hasBeenExplored = true;
            }

            // Map
            if (!player.hasMap && level.map.Row == cellRow &&
                level.map.Column == cellColumn)
            {
                occupantList.Add(occupantType.map);
                occupants++;
            }

            // Traps
            foreach (Trap trap in level.trapList)
            {
                if (trap.Row == cellRow && trap.Column == cellColumn &&
                    !trap.fallenInto)
                {
                    occupantList.Add(occupantType.trap);
                    occupants++;
                }
            }

            for (int i = 0; i < (10 - occupants); i++)
            {
                occupantList.Add(occupantType.empty);
            }
        }
    }
}