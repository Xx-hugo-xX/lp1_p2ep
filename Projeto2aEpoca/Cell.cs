using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Cell
    {
        /// <summary>
        /// Instance Variables
        /// </summary> 
        public int cellRow, cellColumn;
        public bool hasBeenExplored { get; set; }

        public List<OccupantTypes> occupantList = new List<OccupantTypes>();

        /// <summary>
        /// Creates An Instance Of 'Cell'
        /// </summary>
        /// <param name="row">The Cell's Row On The Board</param>
        /// <param name="column">The Cell's Column On The Board</param>
        public Cell(int row, int column)
        {
            cellRow = row;
            cellColumn = column;

            hasBeenExplored = false;
        }
        
        /// <summary>
        /// Checks Cell Occupants and Adds Them To 'occupantList' and
        /// fills Remaining (Non-Occupied) Spaces With 'occupantType.empty'
        /// </summary>
        /// <param name="player">
        /// The Player's Position That Will Be
        /// Compared With The Cell's Position </param>
        /// <param name="level">
        /// The Level's Map and Traps Position That Will
        /// Be Compared With The Cell's Position </param>
        public void CheckOccupants(Player player, Level level)
        {
            occupantList.Clear();

            // Counter For Occupied Spaces In occupantList
            int occupants = 0;

            // Player
            if (player.playerPosition.Row == cellRow &&
                player.playerPosition.Column == cellColumn)
            {
                occupantList.Add(OccupantTypes.player);
                occupants++;
                hasBeenExplored = true;
            }

            // Map
            if (!player.hasMap && level.map.Row == cellRow &&
                level.map.Column == cellColumn)
            {
                occupantList.Add(OccupantTypes.map);
                occupants++;
            }

            // Traps
            foreach (Trap trap in level.trapList)
            {
                if (trap.Row == cellRow && trap.Column == cellColumn &&
                    !trap.fallenInto)
                {
                    occupantList.Add(OccupantTypes.trap);
                    occupants++;
                }
            }

            // Fill Remaining Spaces With Empty
            for (int i = 0; i < (10 - occupants); i++)
            {
                occupantList.Add(OccupantTypes.empty);
            }
        }
    }
}