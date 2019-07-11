using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto2aEpoca
{
    public class Player
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public double hp;
        public float score;
        public bool hasMoved;
        public Position position;
        public bool hasMap;
        public int enemiesKilled;

        public List<Item> inventory;
        public float getInventoryWeight
        {
            get
            {
                float weight = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                    weight += inventory.ElementAt(i).Weight;
                }
                return weight;
            }
        }

        /// <summary>
        /// Creates An Instance Of 'Player'
        /// </summary>
        public Player()
        {
            position = new Position(0, 0);
            hp = 100.0f;
            score = 0.0f;
            enemiesKilled = 0;
            inventory = new List<Item>();
        }

        /// <summary>
        /// Changes Player's Position According To User's Input
        /// </summary>
        /// <param name="direction">
        /// User's Input That Will Affect Player's movement</param>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        public void Move(string direction, Board board)
        {
            /*
             * Creates A Wanted Position Of The Player,
             * That Will Be Changed According To User Input
             */
            Position wantedPosition = new Position(0, 0);
            hasMoved = false;

            // Checks User's Input And Sets The Wanted Position
            switch (direction)
            {
                case "1":                                                 // SW 
                    wantedPosition.Row = position.Row + 1;
                    wantedPosition.Column = position.Column - 1;
                    break;

                case "2":                                                 //  S
                    wantedPosition.Row = position.Row + 1;
                    wantedPosition.Column = position.Column;
                    break;

                case "3":                                                 // SE
                    wantedPosition.Row = position.Row + 1;
                    wantedPosition.Column = position.Column + 1;
                    break;

                case "4":                                                 //  W
                    wantedPosition.Row = position.Row;
                    wantedPosition.Column = position.Column - 1;
                    break;

                case "5":                                         // Same Place
                    wantedPosition.Row = position.Row;
                    wantedPosition.Column = position.Column;
                    break;

                case "6":                                                 //  E
                    wantedPosition.Row = position.Row;
                    wantedPosition.Column = position.Column + 1;
                    break;

                case "7":                                                 // NW
                    wantedPosition.Row = position.Row - 1;
                    wantedPosition.Column = position.Column - 1;
                    break;

                case "8":                                                 //  N
                    wantedPosition.Row = position.Row - 1;
                    wantedPosition.Column = position.Column;
                    break;

                case "9":                                                 // NE
                    wantedPosition.Row = position.Row - 1;
                    wantedPosition.Column = position.Column + 1;
                    break;

                default:
                    Console.WriteLine("\nInvalid direction.\n");
                    wantedPosition.Row = position.Row;
                    wantedPosition.Column = position.Column;
                    break;
            }

            // Sets Player's Position As The Wanted Position, If It's Valid
            if (CheckInsideBounds(wantedPosition, board))
            {
                position.Row = wantedPosition.Row;
                position.Column = wantedPosition.Column;
                hasMoved = true;
            }
            // If It's Not Valid, Display Error Message
            else Console.WriteLine("\nYou can't move there!\n");
        }

        /// <summary>
        /// Checks If The Wanted Position Is Inside The Map
        /// </summary>
        /// <param name="wantedPosition">Wanted Position To Be Checked</param>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        /// <returns></returns>
        private bool CheckInsideBounds(Position wantedPosition, Board board)
        {
            if (wantedPosition.Row < 0) return false;
            else if (wantedPosition.Row >= board.Rows) return false;
            else if (wantedPosition.Column < 0) return false;
            else if (wantedPosition.Column >= board.Columns) return false;
            return true;
        }

        /// <summary>
        /// Checks Which Cells Are In The Player's "Moore Neighborhood"
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        public void LookAround(Board board)
        {
            // Loops Trough All Cells In The The Cell List
            foreach (Cell cell in board.cellList)
            {
                // Check If It's The Cell Above The Player
                if (cell.cellRow == position.Row - 1 &&
                    cell.cellColumn == position.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Below The Player
                else if (cell.cellRow == position.Row + 1 &&
                         cell.cellColumn == position.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Left To The Player
                else if (cell.cellRow == position.Row &&
                         cell.cellColumn == position.Column - 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Right To The Player
                else if (cell.cellRow == position.Row &&
                         cell.cellColumn == position.Column + 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Top Left To The Player
                if (cell.cellRow == position.Row - 1 &&
                    cell.cellColumn == position.Column - 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Top Right To The Player
                else if (cell.cellRow == position.Row + 1 &&
                         cell.cellColumn == position.Column + 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Bottom Left To The Player
                else if (cell.cellRow == position.Row + 1 &&
                         cell.cellColumn == position.Column - 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Bottom Right To The Player
                else if (cell.cellRow == position.Row - 1 &&
                         cell.cellColumn == position.Column + 1)
                {
                    cell.hasBeenExplored = true;
                }
            }
        }

        /// <summary>
        /// Shows "Game Over" Message
        /// </summary>
        public void PlayerDeath()
        {
            Console.Clear();
            Console.WriteLine("Your HP Reached 0. You Lost.");
            Console.ReadLine();
        }
    }
}
