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

        public void Move(int direction, Board board)
        {
            Position wantedPosition = new Position(0,0);

            hasMoved = false;

            switch (direction)
            {
                case 1:
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case 2:
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case 3:
                    wantedPosition.Row = playerPosition.Row + 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case 4:
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case 5:
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case 6:
                    wantedPosition.Row = playerPosition.Row;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;

                case 7:
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column - 1;
                    break;

                case 8:
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column;
                    break;

                case 9:
                    wantedPosition.Row = playerPosition.Row - 1;
                    wantedPosition.Column = playerPosition.Column + 1;
                    break;
                
                default:
                    Console.WriteLine("\nInvalid direction.\n");
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
    }
}
