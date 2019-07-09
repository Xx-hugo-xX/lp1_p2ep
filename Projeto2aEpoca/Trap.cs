using System;

namespace Projeto2aEpoca
{
    public class Trap
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public int Row;
        public int Column;
        public int maxDamage;

        public TrapTypes Type;

        public bool fallenInto { get; private set; }

        private static Random random = new Random();

        /// <summary>
        /// Creates An Instance Of 'Trap'
        /// </summary>
        /// <param name="type">Sets The Type Of The Trap</param>
        /// <param name="row">Sets The Row Of The Trap</param>
        /// <param name="column">Sets The Column Of The Trap</param>
        public Trap(TrapTypes type, int row, int column)
        {
            Type = type;
            maxDamage = (int)Type;

            Row = row;
            Column = column;

            fallenInto = false;
        }

        /// <summary>
        /// Sets DamageDealt (0 to maxDamage) and Sets Trap Activation Message
        /// </summary>
        /// <param name="player">
        /// Player That Will Take Damage Form The Trap</param>
        /// <returns>Returns The Trap Message</returns>
        public string dealDamage(Player player)
        {
            Random random = new Random();

            double damage = random.NextDouble() * maxDamage;
            player.hp -= damage;
            fallenInto = true;

            string trapMessage = $"You activated the trap {Type} " +
                                 $"and lost {damage.ToString("0.0")}HP";
            return trapMessage;
        }
    }
}
