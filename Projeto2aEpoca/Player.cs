using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Player : Character
    {
        // Instance Variables
        public float hp;
        public bool hasMoved;
        public Position playerPosition;
        public bool hasMap;

        // Constructor Method
        public Player(int row, int column)
        {
            playerPosition = new Position(row, column);
            hp = 100.0f;
        }

        public void Move(string direction, Board board)
        {
            Position wantedPosition = new Position(0,0);
            hasMoved = false;

            // Sets "Wanted Position"
            switch (direction)
            {
                case "1":                                                 // SW 
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "2":                                                 //  S
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "3":                                                 // SE
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case "4":                                                 //  W
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "5":                                         // Same Place
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "6":                                                 //  E
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case "7":                                                 // NW
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "8":                                                 //  N
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "9":                                                 // NE
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;
                
                default:
                    Console.WriteLine("\nInvalid direction.\n");
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column;
                    break;
            }

            // Sets Player's Position As The Wanted Position (Valid Movement)
            if (CheckInsideBounds(wantedPosition, board))
            {
                playerPosition.Row = wantedPosition.Row;
                playerPosition.Column = wantedPosition.Column;
                hasMoved = true;
            }
            else Console.WriteLine("\nYou can't move there!\n");
        }

        // Checks If The Wanted Position Is Inside The Map
        private bool CheckInsideBounds(Position wantedPosition, Board board)
        {
            if (wantedPosition.Row < 0) return false;
            else if (wantedPosition.Row >= board.Rows) return false;
            else if (wantedPosition.Column < 0) return false;
            else if (wantedPosition.Column >= board.Columns) return false;
            else return true;
        }

        // Checks Which Cells Are In The Player's "Moore Neighborhood"
        public void LookAround(Board board)
        {
            // Loops Trough All Cells In The The Cell List
            foreach (Cell cell in board.cellList)
            {
                // Check If It's The Cell Above The Player
                if (cell.cellRow == playerPosition.Row - 1 &&
                    cell.cellColumn == playerPosition.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Below The Player
                else if (cell.cellRow == playerPosition.Row + 1 &&
                         cell.cellColumn == playerPosition.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Left To The Player
                else if (cell.cellRow == playerPosition.Row &&
                         cell.cellColumn == playerPosition.Column - 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Right To The Player
                else if (cell.cellRow == playerPosition.Row &&
                         cell.cellColumn == playerPosition.Column + 1)
                {
                    cell.hasBeenExplored = true;
                }
                
                // Check If It's The Cell Top Left To The Player
                if (cell.cellRow == playerPosition.Row - 1 &&
                    cell.cellColumn == playerPosition.Column -1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Top Right To The Player
                else if (cell.cellRow == playerPosition.Row +1 &&
                         cell.cellColumn == playerPosition.Column +1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Bottom Left To The Player
                else if (cell.cellRow == playerPosition.Row +1 &&
                         cell.cellColumn == playerPosition.Column -1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check If It's The Cell Bottom Right To The Player
                else if (cell.cellRow == playerPosition.Row -1 &&
                         cell.cellColumn == playerPosition.Column +1)
                {
                    cell.hasBeenExplored = true;
                }
            }
        }

        // Shows "Game Over" Message
        public void PlayerDeath()
        {
            Console.Clear();
            Console.WriteLine("Your HP Reached 0. You Lost.");
            Console.ReadLine();
        }
    }
}
