namespace Projeto2aEpoca
{
    /// <summary>
    /// Dictates items names and stats
    /// </summary>
    public class PossibleItems
    {
        public enum weaponTypes
        {
            LongClaw,
            Ryno,
            LightSaber,
            BladesOfChaos,
            Mjolnir,
            InfinityGauntlet
        };

        public enum foodTypes
        {
            SliceOfCheese,
            BigMac,
            Ratatouille,
            Pasta,
            BucketOfChicken,
        };

        public Weapon[] weapons = new Weapon[6]
        {
            new Weapon("LongClaw",          14, 0.8f, 6),
            new Weapon("Ryno",              16, 0.7f, 8),
            new Weapon("Light Saber",       18, 0.9f, 5),
            new Weapon("Blades Of Chaos",   20, 0.9f, 12),
            new Weapon("Mjolnir",           25, 0.6f, 30),
            new Weapon("Infinity Gauntlet", 35, 0.4f, 10)
        };

        public Food[] foods = new Food[5]
        {
            new Food("Slice of Cheese",   2,  0.1f),
            new Food("Big Mac",           5,  0.4f),
            new Food("Ratatouille",       6,  0.7f),
            new Food("Pasta",             9,  0.5f),
            new Food("Bucket of Chicken", 15, 3.1f)
        };
    }
}
