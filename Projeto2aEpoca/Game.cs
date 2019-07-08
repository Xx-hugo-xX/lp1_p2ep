using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class GameLoop
    {
        /// <summary>
        /// Contains the method PlayGame and runs the game loop. 
        /// </summary>
        
        
        // Instance Variables
        Board Board;
        Renderer Renderer;
        Level Level;
        Player Player;
        bool playing = false;

        // Constructor Method
        public GameLoop(
            Board board, Renderer renderer, Level level, Player player)
        {
            Board = board;
            Renderer = renderer;
            Level = level;
            Player = player;
        }

        public void PlayGame()
        {
            while (!playing)
            {
                Console.Clear();
                Renderer.MainMenu();
                string option = Console.ReadLine();
                Console.Clear();

                // Reacts To Input In MainMenu
                if (option == "1")
                {
                    playing = true;
                }
                else if (option == "2")
                {
                    Renderer.HighScores();
                    Console.ReadLine();
                }
                else if (option == "3")
                {
                    Renderer.Credits();
                    Console.ReadLine();
                }
                else if (option == "4")
                {
                    Environment.Exit(0);
                }
            }

            while (playing)
            {
                // Restarts Level Variables
                Level.StartNewLevel();
                bool finishedLevel = false;
                bool madeTurn = false;

                // Messages To Be Rendered
                string m1;
                string m2;
                string m3;

                while (!finishedLevel)
                {
                    madeTurn = false;

                    // Restart Messages For New Turn
                    m1 = "";
                    m2 = "";
                    m3 = "";

                    foreach (Trap trap in Level.trapList)
                    {
                        // Displays Trap(s) Name/Damage Dealt If Activated
                        if (Player.playerPosition.Row == trap.Row &&
                            Player.playerPosition.Column == trap.Column)
                        {
                            // Pushes Recent Messages To Top Of Render
                            if (!trap.fallenInto)
                            {
                                m3 = m2;
                                m2 = m1;
                                m1 = trap.dealDamage(Player);
                            }
                        }
                    }

                    // Ends Game When Player's Health Is Equal/Below 0
                    if (Player.hp <= 0.0f)
                    {
                        Player.PlayerDeath();
                    }

                    foreach (Cell cell in Board.cellList)
                    {
                        cell.CheckOccupants(Player, Level);
                    }
                    
                    // Renderer
                    Renderer.ShowGameValues(Board, Level);
                    Renderer.ShowPlayerStats(Player);
                    Renderer.DrawMap(Board, Level);
                    Renderer.ShowMessage(m1, m2, m3);
                    Renderer.ShowLegend();

                    string moveOption = Console.ReadLine();

                    // "Move"
                    if (moveOption == "1" || moveOption == "2" ||
                        moveOption == "3" || moveOption == "4" ||
                        moveOption == "5" || moveOption == "6" ||
                        moveOption == "7" || moveOption == "8" ||
                        moveOption == "9")
                    {
                        Player.Move(moveOption, Board);
                        madeTurn = Player.hasMoved;
                    }

                    // "Look Around"
                    else if (moveOption == "L")
                    {
                        Player.LookAround(Board);
                        madeTurn = true;
                    }

                    // "Pick_Up Map"
                    else if (moveOption == "E")
                    {
                        if (Player.playerPosition.Row == Level.map.Row &&
                            Player.playerPosition.Column == Level.map.Column)
                        {
                            Player.hasMap = true;
                            Board.exploreAllCells();
                            madeTurn = true;
                        }
                    }

                    // "QuitGame"
                    else if (moveOption == "Q")
                    {
                        Renderer.QuitGame();
                    }

                    // Begins Change To Next Level if Player's in 'EXIT' Cell
                    if (Player.playerPosition.Row == Level.exit.Row &&
                        Player.playerPosition.Column == Level.exit.Column)
                    {
                        Level.NextLevel();
                        finishedLevel = true;
                    }

                    // Decreases Player's Health (-1 hp) when Turn Ends 
                    if (madeTurn) Player.hp -= 1.0f;

                    // Ends Game when Player's Health Is Equal/Below 0
                    if (Player.hp <= 0.0f)
                    {
                        Player.PlayerDeath();
                    }

                    Console.Clear();
                }
            }
        }
    }
}