using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Player : Character
    {
        //instanse variable
        public float hp;
        public bool hasMoved;
        public Position playerPosition;

        public Player(int row, int column)
        {
            playerPosition = new Position(row, column);

            hp = 100.0f;
        }

        public void Move(string direction, Board board)
        {
            Position wantedPosition = new Position(0,0);

            hasMoved = false;

            switch (direction)
            {
                case "1":
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "2":
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "3":
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case "4":
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "5":
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "6":
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case "7":
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case "8":
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case "9":
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;
                
                default:
                    Console.WriteLine("\nInvalid direction.\n");
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column;
                    break;
            }

            if (CheckInsideBounds(wantedPosition, board))
            {
                playerPosition.Row = wantedPosition.Row;
                playerPosition.Column = wantedPosition.Column;
                hasMoved = true;
            }
            else Console.WriteLine("\nYou can't move there!\n");
        }

        private bool CheckInsideBounds(Position wantedPosition, Board board)
        {
            if (wantedPosition.Row < 0) return false;
            else if (wantedPosition.Row >= board.Rows) return false;
            else if (wantedPosition.Column < 0) return false;
            else if (wantedPosition.Column >= board.Columns) return false;
            else return true;

        }

        public void LookAround(Board board)
        {
            /*Loops trough all the cells in the board to see
            wich ones are near the player (Moore Neighborhood)*/
            foreach (Cell cell in board.cellList)
            {
                // Check if it's the cell above the player
                if (cell.cellRow == playerPosition.Row - 1 &&
                    cell.cellColumn == playerPosition.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell below the player
                else if (cell.cellRow == playerPosition.Row + 1 &&
                         cell.cellColumn == playerPosition.Column)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell left to the player
                else if (cell.cellRow == playerPosition.Row &&
                         cell.cellColumn == playerPosition.Column - 1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell right to the player
                else if (cell.cellRow == playerPosition.Row &&
                         cell.cellColumn == playerPosition.Column + 1)
                {
                    cell.hasBeenExplored = true;
                }






                // Check if it's the cell top left to the player
                if (cell.cellRow == playerPosition.Row - 1 &&
                    cell.cellColumn == playerPosition.Column -1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell top right to the player
                else if (cell.cellRow == playerPosition.Row +1 &&
                         cell.cellColumn == playerPosition.Column +1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell bottom left to the player
                else if (cell.cellRow == playerPosition.Row +1 &&
                         cell.cellColumn == playerPosition.Column -1)
                {
                    cell.hasBeenExplored = true;
                }

                // Check if it's the cell bottom right to the player
                else if (cell.cellRow == playerPosition.Row -1 &&
                         cell.cellColumn == playerPosition.Column +1)
                {
                    cell.hasBeenExplored = true;
                }
            }
        }
    }
}
