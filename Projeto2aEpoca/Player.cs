using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Player : Character
    {
        //instanse variable
        public float hp;
        public Position playerPosition;

        public Player(int row, int column)
        {
            playerPosition = new Position(row, column);

            hp = 100.0f;
        }

        public void Move(int direction, int gridRows, int gridCols)
        {
            Position wantedPosition = new Position(0,0);

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

            if ((wantedPosition.Row > 0 || wantedPosition.Row < gridRows) &&
               (wantedPosition.Column > 0 || wantedPosition.Column < gridCols))
            {
                playerPosition.Row = wantedPosition.Row;
                playerPosition.Column = wantedPosition.Column;
            }
            else Console.WriteLine("\nYou can't move there!\n");
        }
    }
}
