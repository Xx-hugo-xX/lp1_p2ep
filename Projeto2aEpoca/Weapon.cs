namespace Projeto2aEpoca
{
    /// <summary>
    /// Sets weapon properties
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public float AttackPower;
        public float Durability;

        /// <summary>
        /// Creates An Instance Of 'Weapon'
        /// </summary>
        /// <param name="name">Name Of The Weapon</param>
        /// <param name="attackPower">Weapon's Attack Power</param>
        /// <param name="durability">
        /// Probability Of The Weapon Breaking After Attack</param>
        /// <param name="weight">
        /// Weight Of The Weapon On The Player's Inventory</param>
        public Weapon(
            string name, float attackPower, float durability, float weight)
        {
            Name = name;
            AttackPower = attackPower;
            Durability = durability;
            Weight = weight;
            Position = new Position(0, 0);
            TakenByPlayer = false;

            isWeapon = true;
        }
    }
}
