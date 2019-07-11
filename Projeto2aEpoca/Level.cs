using System;
using System.Collections.Generic;

namespace Projeto2aEpoca
{
    public class Level
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public int currentLevel;
        public int currentLevelDifficulty;

        public int numberOfCells = 0;
        public int numberOfTraps = 0;

        public int numberOfItems;
        public int numberOfWeapons;
        public int numberOfFood;

        public Position exit;
        public Position map;

        public List<Trap> trapList;
        public List<Weapon> weaponList;
        public List<Food> foodList;

        List<Cell> CellList;
        Board Board;
        Game Game;
        Player Player;
        PossibleItems PossibleItems;

        /// <summary>
        /// Creates An Instance of 'Level'
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        /// <param name="possibleItems">Items That Can Be In The Level</param>
        /// <param name="player">Player To Set It's Initial Position</param>
        public Level(Board board, Player player, PossibleItems possibleItems)
        {
            Board = board;
            Player = player;
            PossibleItems = possibleItems;

            CellList = Board.cellList;

            numberOfCells = Board.Rows * Board.Columns;
            trapList = new List<Trap>();
            weaponList = new List<Weapon>();
            foodList = new List<Food>();

            currentLevel = 1;
        }

        /// <summary>
        /// Starts A New Level, Resets The Necessary Variables For Each One
        /// And Randomizes a New Position For The Player, For The Exit,
        /// For The Map And For Each Trap in 'trapList'
        /// </summary>
        public void StartNewLevel()
        {
            Player.hasMap = false;
            // Level Difficulty
            currentLevelDifficulty = currentLevel + Board.Difficulty;

            // Number Of Traps (According To Cells and Level Difficulty)
            numberOfTraps = numberOfCells * currentLevelDifficulty / 25;

            // Cap The Number Of Traps Per Level According To Grid Size
            if (numberOfTraps > Convert.ToInt32(numberOfCells * 0.75))
            {
                numberOfTraps = Convert.ToInt32(numberOfCells * 0.75);
            }
            
            numberOfWeapons = 
               Convert.ToInt32(numberOfCells / (currentLevelDifficulty / 1.5));

            if (numberOfWeapons < Convert.ToInt32(numberOfCells * 0.10))
            {
                Console.Clear();
                Console.WriteLine("REACHED WEAPONS CAP");
                Console.ReadLine();
                numberOfWeapons = Convert.ToInt32(numberOfCells * 0.10);
            }
            
            numberOfFood = 
               Convert.ToInt32(numberOfCells / (currentLevelDifficulty / 2.5));

            if (numberOfFood < Convert.ToInt32(numberOfCells * 0.15))
            {
                Console.Clear();
                Console.WriteLine("REACHED FOOD CAP");
                Console.ReadLine();
                numberOfFood = Convert.ToInt32(numberOfCells * 0.15);
            }
            
            CellList.Clear();
            trapList.Clear();
            weaponList.Clear();
            foodList.Clear();

            // Create Cell's According To Grid Size
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    CellList.Add(new Cell(i, j));
                }
            }

            Random random = new Random();

            // Sets Player's Beginning Position (Cell)
            Player.position = new Position(random.Next(Board.Rows), 0);

            // Sets Exit's Position (Cell)
            exit = new Position(random.Next(Board.Rows), Board.Columns - 1);

            // Sets Map's Position (Cell)
            map = new Position(exit.Row, exit.Column);
            while (map.Row == exit.Row && map.Column == exit.Column)
            {
                map = new Position(random.Next(Board.Rows),
                                   random.Next(Board.Columns));
            }

            // Creates Array With Possible 'TrapTypes'
            Array trapTypes = Enum.GetValues(typeof(TrapTypes));

            for (int i = 0; i < numberOfTraps; i++)
            {
                int row = 0;
                int column = 0;

                // Sets Trap Type (Randomly)
                TrapTypes randomType =
                    (TrapTypes)trapTypes.GetValue
                    (random.Next(trapTypes.Length));

                bool validPosition = false;

                // Loops Until Trap's Position Is Valid
                while (!validPosition)
                {
                    // Sets Trap's Position (Cell)
                    row = random.Next(Board.Rows);
                    column = random.Next(Board.Columns);

                    // Restricts Trap's Position
                    if (row == exit.Row && column == exit.Column)
                    {
                        continue;
                    }
                    else if (row == Player.position.Row &&
                             column == Player.position.Column)
                    {
                        continue;
                    }

                    else validPosition = true;
                }
                // Adds Trap To 'trapList'
                trapList.Add(new Trap(randomType, row, column));
            }


            // Creates Array With Possible 'weaponTypes'
            Array weaponTypes = Enum.GetValues(
                typeof(PossibleItems.weaponTypes));

            for (int i = 0; i < numberOfWeapons; i++)
            {
                Weapon newWeapon;

                int row = 0;
                int column = 0;

                // Sets Weapon Type (Randomly)
                PossibleItems.weaponTypes randomType =
                    (PossibleItems.weaponTypes)weaponTypes.GetValue(
                        random.Next(weaponTypes.Length));

                switch (randomType)
                {
                    case PossibleItems.weaponTypes.LongClaw:
                        newWeapon = new Weapon("LongClaw", 14, 0.8f, 6);
                        break;
                    case PossibleItems.weaponTypes.Ryno:
                        newWeapon = new Weapon("Ryno", 16, 0.7f, 8);
                        break;
                    case PossibleItems.weaponTypes.LightSaber:
                        newWeapon = new Weapon("Light Saber", 18, 0.9f, 5);
                        break;
                    case PossibleItems.weaponTypes.BladesOfChaos:
                        newWeapon = new Weapon(
                            "Blades Of Chaos", 20, 0.9f, 12);
                        break;
                    case PossibleItems.weaponTypes.Mjolnir:
                        newWeapon = new Weapon("Mjolnir", 25, 0.6f, 30);
                        break;
                    case PossibleItems.weaponTypes.InfinityGauntlet:
                        newWeapon = new Weapon(
                            "Infinity Gauntlet", 35, 0.4f, 10);
                        break;
                    default:
                        newWeapon = new Weapon("", 0, 0, 0);
                        break;
                }

                bool validPosition = false;

                // Loops Until Weapon's Position Is Valid
                while (!validPosition)
                {
                    // Sets Weapon's Position (Cell)
                    row = random.Next(Board.Rows);
                    column = random.Next(Board.Columns);

                    // Restricts Weapon's Position
                    if (row == exit.Row && column == exit.Column)
                    {
                        continue;
                    }
                    else if (row == Player.position.Row &&
                             column == Player.position.Column)
                    {
                        continue;
                    }

                    else validPosition = true;
                }

                // Sets New Position For The Weapon
                newWeapon.Position.Row = row;
                newWeapon.Position.Column = column;

                // Adds Weapon To 'weaponList'
                weaponList.Add(newWeapon);
            }

            // Creates Array With Possible 'foodTypes'
            Array foodTypes = Enum.GetValues(typeof(PossibleItems.foodTypes));

            for (int i = 0; i < numberOfFood; i++)
            {
                Food newFood;

                int row = 0;
                int column = 0;

                // Sets Food Type (Randomly)
                PossibleItems.foodTypes randomType =
                    (PossibleItems.foodTypes)weaponTypes.GetValue(
                        random.Next(foodTypes.Length));

                switch (randomType)
                {
                    case PossibleItems.foodTypes.SliceOfCheese:
                        newFood = new Food("Slice of Cheese", 2, 0.1f);
                        break;
                    case PossibleItems.foodTypes.BigMac:
                        newFood = new Food("Big Mac", 5, 0.4f);
                        break;
                    case PossibleItems.foodTypes.Ratatouille:
                        newFood = new Food("Ratatouille", 18, 0.7f);
                        break;
                    case PossibleItems.foodTypes.Pasta:
                        newFood = new Food("Pasta", 6, 0.9f);
                        break;
                    case PossibleItems.foodTypes.BucketOfChicken:
                        newFood = new Food("Bucket of Chicken", 9, 0.5f);
                        break;
                    default:
                        newFood = new Food("", 0, 0);
                        break;
                }

                bool validPosition = false;

                // Loops Until Food's Position Is Valid
                while (!validPosition)
                {
                    // Sets Food's Position (Cell)
                    row = random.Next(Board.Rows);
                    column = random.Next(Board.Columns);

                    // Restricts Foods's Position
                    if (row == exit.Row && column == exit.Column)
                    {
                        continue;
                    }
                    else if (row == Player.position.Row &&
                             column == Player.position.Column)
                    {
                        continue;
                    }

                    else validPosition = true;
                }

                // Sets New Position For The Food
                newFood.Position.Row = row;
                newFood.Position.Column = column;

                // Adds Weapon To 'weaponList'
                foodList.Add(newFood);
            }
        }

        /// <summary>
        /// Sets The Current Level As The Next Level
        /// </summary>
        public void NextLevel()
        {
            currentLevel++;
        }
    }
}
