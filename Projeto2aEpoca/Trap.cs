using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Trap
    {
        public int Row;
        public int Column;

        public TrapTypes Type;
        public int maxDamage;

        public bool fallenInto { get; private set; }

        private static Random random = new Random();

        public Trap(TrapTypes type, int row, int column)
        {
            Type = type;
            maxDamage = (int)Type;

            Row = row;
            Column = column;

            fallenInto = false;
        }

        public string dealDamage(Player player)
        {
            Random random = new Random();

            double damage = random.NextDouble() * maxDamage;
            player.hp -= damage;
            fallenInto = true;

            string trapMessage = $"You activated the trap {Type} and lost {damage.ToString("0.0")}HP";
            return trapMessage;
        }
    }
}
