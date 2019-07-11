using System;
using System.Linq;

namespace Projeto2aEpoca
{
    /// <summary>
    /// As PickUpWeapon, PickUpFood  and DropItem fuctions that allow the 
    /// player to manage which items the player as in the inventory  
    /// </summary>
    
    public class InventoryManager
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        Level Level;
        Player Player;

        /// <summary>
        /// Creates An Instance Of 'InventoryManager'
        /// </summary>
        /// <param name="player">Player That Has The Needed Inventory</param>
        /// <param name="level">Level That Has The Needed Item Lists</param>
        public InventoryManager(Player player, Level level)
        {
            Player = player;
            Level = level;
        }


        /// <summary>
        /// Picks Up A Specific Weapon, Based On User Input
        /// </summary>
        /// <returns>
        /// Returns A String That Will Be Printed As An Event Message</returns>
        public string PickUpWeapon()
        {
            // String To Be Returned
            string pickupMessage;

            bool hasWeapons = false;

            // Checks If There Is Any Weapon In The Player's Position
            for (int i = 0; i < Level.weaponList.Count; i++)
            {
                if (Player.position.Row == Level.weaponList.
                                           ElementAt(i).Position.Row &&
                    Player.position.Column == Level.weaponList.
                                              ElementAt(i).Position.Column &&
                    !Level.weaponList.ElementAt(i).TakenByPlayer)
                {
                    hasWeapons = true;
                    break;
                }
            }

            // Sets Return Message If There Are No Weapons
            if (!hasWeapons)
                pickupMessage = "No weapon found.";

            // If There Are Weapons
            else
            {
                string wantedWeapon;

                // Gives User a List Of All The Weapons In The Map,
                //And Tells Him/Her Wich Of The Weapons Are In His Position
                Console.WriteLine("\nWhat weapon do you want to get?\n");
                for (int i = 0; i < Level.weaponList.Count; i++)
                {

                    if (Player.position.Row == Level.weaponList.
                                               ElementAt(i).Position.Row &&
                        Player.position.Column == Level.weaponList.
                                                  ElementAt(i).Position.Column
                    && !Level.weaponList.ElementAt(i).TakenByPlayer)
                    {
                        Console.WriteLine($"{i + 1}. " +
                    $"{Level.weaponList.ElementAt(i).Name} (Weapon In Sight)");
                    }


                    else if (!Level.weaponList.ElementAt(i).TakenByPlayer)
                        Console.WriteLine($"{i + 1}. " +
                                    $"{Level.weaponList.ElementAt(i).Name} " +
                                    $"(Weapon Is Somewhere Else)");
                }

                // Reads Which Weapon The User Wants To Pick Up
                wantedWeapon = Console.ReadLine();

                if (Convert.ToInt32(wantedWeapon) > 0 &&
                    Convert.ToInt32(wantedWeapon) <= Level.weaponList.Count)
                {

                    // Adds Weapon To Player's Inventory,
                    // Sets It's State To taken
                    // And Sets Message To Be Displayed With The Name
                    // Of The Weapon That has Been Picked Up
                    if (Player.position.Row == Level.weaponList.ElementAt
                       (Convert.ToInt32(wantedWeapon) - 1).Position.Row &&
                        Player.position.Column == Level.weaponList.ElementAt
                       (Convert.ToInt32(wantedWeapon) - 1).Position.Column &&
                     !Level.weaponList.ElementAt
                       (Convert.ToInt32(wantedWeapon) - 1).TakenByPlayer)
                    {
                        // See If The Player Can Carry More Items
                        if (Player.getInventoryWeight + Level.weaponList.ElementAt
                       (Convert.ToInt32(wantedWeapon) - 1).Weight > 100)
                        {
                            pickupMessage = "You're already carrying too " +
                                       "much weight. Maybe drop another item" +
                                       " to make some space.";
                        }
                        else
                        {
                            pickupMessage = $"You got the weapon: " +
       $"{Level.weaponList.ElementAt(Convert.ToInt32(wantedWeapon) - 1).Name}";

                            Player.inventory.Add(Level.weaponList.ElementAt
                                          (Convert.ToInt32(wantedWeapon) - 1));

                            Level.weaponList.ElementAt(Convert.ToInt32
                                (wantedWeapon) - 1).TakenByPlayer = true;

                            Level.weaponList.Remove(
                Level.weaponList.ElementAt(Convert.ToInt32(wantedWeapon) - 1));
                        }
                    }

                    // Sets Message To Be Displayed If The User
                    // Chooses A Weapon That Is In A Different Position
                    else pickupMessage = "That weapon is somewhere else";
                }

                // Sets Message To Be Displayed If The User's Option Is Invalid
                else pickupMessage = "Invalid option.";
            }
            return pickupMessage;
        }

        /// <summary>
        /// Picks Up A Specific Food, Based On User Input
        /// </summary>
        /// <returns>
        /// Returns A String That Will Be Printed As An Event Message</returns>
        public string PickUpFood()
        {
            // String To Be Returned
            string pickupMessage;

            bool hasFood = false;

            // Checks If There Are Any Foods In The Player's Position
            for (int i = 0; i < Level.foodList.Count; i++)
            {
                if (Player.position.Row == Level.foodList.
                                           ElementAt(i).Position.Row &&
                    Player.position.Column == Level.foodList.
                                              ElementAt(i).Position.Column &&
                    !Level.foodList.ElementAt(i).TakenByPlayer)
                {
                    hasFood = true;
                    break;
                }
            }

            // Sets Return Message If There Is No Food
            if (!hasFood)
                pickupMessage = "No food found.";

            // If There Is Food
            else
            {
                string wantedFood;
                
                // Gives User a List Of All The Foods In The Map,
                //And Tells Him/Her Wich Of The Foods Are In His Position
                Console.WriteLine("\nWhat food do you want to get?\n");
                for (int i = 0; i < Level.foodList.Count; i++)
                {
                    if (Player.position.Row == Level.foodList.
                                               ElementAt(i).Position.Row &&
                        Player.position.Column == Level.foodList.
                                                  ElementAt(i).Position.Column
                    && !Level.foodList.ElementAt(i).TakenByPlayer)
                    {
                        Console.WriteLine($"{i + 1}. " +
                    $"{Level.foodList.ElementAt(i).Name} (Food In Sight)");
                    }
                    
                    else if (!Level.foodList.ElementAt(i).TakenByPlayer)
                        Console.WriteLine($"{i + 1}. " +
            $"{Level.foodList.ElementAt(i).Name} (Food Is Somewhere Else)");
                }

                // Reads Which Food The User Wants To Pick Up
                wantedFood = Console.ReadLine();

                if (Convert.ToInt32(wantedFood) > 0 &&
                    Convert.ToInt32(wantedFood) <= Level.foodList.Count)
                {

                    // Adds Food To Player's Inventory,
                    // Sets It's State To taken
                    // And Sets Message To Be Displayed With The Name
                    // Of The Food That has Been Picked Up
                    if (Player.position.Row == Level.foodList.ElementAt
                       (Convert.ToInt32(wantedFood) - 1).Position.Row &&
                        Player.position.Column == Level.foodList.ElementAt
                       (Convert.ToInt32(wantedFood) - 1).Position.Column &&
                     !Level.foodList.ElementAt
                       (Convert.ToInt32(wantedFood) - 1).TakenByPlayer)
                    {
                        // See If The Player Can Carry More Items
                        if (Player.getInventoryWeight + Level.foodList.
                       ElementAt(Convert.ToInt32(wantedFood) - 1).Weight > 100)
                        {
                            pickupMessage = "You're already carrying too " +
                                        "much weight. Maybe drop another item" +
                                        " to make some space.";
                        }
                        else
                        {
                            pickupMessage = $"You got the food: " +
           $"{Level.foodList.ElementAt(Convert.ToInt32(wantedFood) - 1).Name}";

                            Player.inventory.Add(Level.foodList.
                                ElementAt(Convert.ToInt32(wantedFood) - 1));

                            Level.foodList.ElementAt
                           (Convert.ToInt32(wantedFood) - 1).
                           TakenByPlayer = true;

                            Level.foodList.Remove(
                     Level.foodList.ElementAt(
                         Convert.ToInt32(wantedFood) - 1));
                        }
                    }

                    // Sets Message To Be Displayed If The User
                    // Chooses A Food That Is In A Different Position
                    else pickupMessage = "That food is somewhere else";
                }

                // Sets Message To Be Displayed If The User's Option Is Invalid
                else pickupMessage = "Invalid option.";
            }
            return pickupMessage;
        }

        /// <summary>
        /// Removes A Specific Item From
        /// Player's Inventory, Based On User Input
        /// </summary>
        /// <returns>
        /// Returns A String That Will Be Printed As An Event Message</returns>
        public string DropItem()
        {
            // String To Be Returned
            string dropMessage;

            // Checks If There Are Items In The Inventory
            // And Sets Message To Be Displayed If There Is None
            if (Player.inventory.Count == 0)
            {
                dropMessage = "You have no items in your inventory.";
            }

            // If There Are Items
            else
            {
                string droppedItem;
                Weapon droppedWeapon = new Weapon("", 0, 0, 0);
                Food droppedFood = new Food("", 0, 0);

                // Gives User a List Of All The Items In The Inventory
                Console.WriteLine("\nWhat item do you want to drop?\n");
                for (int i = 0; i < Player.inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. " +
                        $"{Player.inventory.ElementAt(i).Name}");
                }

                // Reads Which Item The User Wants To Drop
                droppedItem = Console.ReadLine();
                
                // If The Input Is Valid, Sets Message To Be Displayed,
                // Sets The Item's Position As The Current Player's Position,
                // Sets The Item's State As Not Taken
                // And Removes The Item From The Player's Inventory
                if (Convert.ToInt32(droppedItem) > 0 &&
                    Convert.ToInt32(droppedItem) <= Player.inventory.Count)
                {
                    dropMessage = $"You dropped the item: " +
        $"{Player.inventory.ElementAt(Convert.ToInt32(droppedItem) - 1).Name}";

                    // Checks Which Item It Is And Creates a Copy 
                    // To Add To The Specific List
                    switch (Player.inventory.ElementAt
                          (Convert.ToInt32(droppedItem) - 1).Name)
                    {
                        case "LongClaw":
                            droppedWeapon = new Weapon(
                                "LongClaw", 14, 0.8f, 6);
                            break;

                        case "Ryno":
                            droppedWeapon = new Weapon("Ryno", 16, 0.7f, 8);
                            break;

                        case "Light Saber":
                            droppedWeapon = new Weapon(
                                "Light Saber", 18, 0.9f, 5);
                            break;

                        case "Blades Of Chaos":
                            droppedWeapon = new Weapon(
                                "Blades Of Chaos", 20, 0.9f, 12);
                            break;

                        case "Mjolnir":
                            droppedWeapon = new Weapon(
                                "Mjolnir", 25, 0.6f, 30);
                            break;

                        case "Infinity Gauntlet":
                            droppedWeapon = new Weapon(
                                "Infinity Gauntlet", 35, 0.4f, 10);
                            break;

                        case "Slice of Cheese":
                            droppedFood = new Food("Slice of Cheese", 2, 0.1f);
                            break;

                        case "Big Mac":
                            droppedFood = new Food("Big Mac", 5, 0.4f);
                            break;

                        case "Ratatouille":
                            droppedFood = new Food("Ratatouille", 6, 0.7f);
                            break;

                        case "Pasta":
                            droppedFood = new Food("Pasta", 9, 0.5f);
                            break;

                        case "Bucket of Chicken":
                            droppedFood = new Food(
                                "Bucket of Chicken", 15, 3.1f);
                            break;

                        default:
                            droppedWeapon = new Weapon("", 0, 0, 0);
                            droppedFood = new Food("", 0, 0);
                            break;

                    }

                    // If It's A Weapon, Add To 'weaponList'
                    if (Player.inventory.ElementAt(
                        Convert.ToInt32(droppedItem) - 1).isWeapon)
                    {
                        droppedWeapon.Position.Row = Player.position.Row;
                        droppedWeapon.Position.Column = Player.position.Column;
                        Level.weaponList.Add(droppedWeapon);
                    }

                    // If It's A Weapon, Add To 'foodList'
                    else
                    {
                        droppedFood.Position.Row = Player.position.Row;
                        droppedFood.Position.Column = Player.position.Column;

                        Level.foodList.Add(droppedFood);
                    }

                    // Set Item's State as "NotTaken"
                    Player.inventory.ElementAt(Convert.ToInt32
                        (droppedItem) - 1).TakenByPlayer = false;

                    // Remove Item From Inventory
                    Player.inventory.Remove(Player.inventory.ElementAt(
                                     Convert.ToInt32(droppedItem) - 1));
                }

                // Sets Message To Be Displayed If The Input Is Not Valid
                else dropMessage = "Invalid option.";
            }
            return dropMessage;
        }
    }
}
