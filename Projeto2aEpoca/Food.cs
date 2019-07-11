using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Food : Item
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public float HPIncrease;

        /// <summary>
        /// Creates An Instance Of 'Food'
        /// </summary>
        /// <param name="name">Name Of The Food</param>
        /// <param name="hpIncrease">
        /// HP Restored To Player After Eating The Food</param>
        /// <param name="weight">
        /// Weight Of The Food On The Player's Inventory</param>
        public Food(string name, float hpIncrease, float weight)
        {
            Name = name;
            HPIncrease = hpIncrease;
            Weight = weight;
            Position = new Position(0, 0);
            TakenByPlayer = false;

            isWeapon = false;
        }
    }
}
