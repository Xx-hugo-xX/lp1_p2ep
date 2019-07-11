using System;
using System.Collections.Generic;

namespace Projeto2aEpoca
{
    public class Game
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        Board Board;
        Renderer Renderer;
        Level Level;
        Player Player;
        HighScoreManager HighScoreManager;

        /// <summary>
        /// Creates An Instance Of 'Game'
        /// </summary>
        /// <param name="board">Board To Use Defined Rows And Columns</param>
        /// <param name="renderer">Renderer For Displays</param>
        /// <param name="level">
        /// Level To Create The Exit, The Map And The Traps</param>
        /// <param name="player">Player That Moves Through The Board</param>
        public Game(Board board, Renderer renderer, Level level,
                    Player player, HighScoreManager highScoreManager)
        {
            Board = board;
            Renderer = renderer;
            Level = level;
            Player = player;
            HighScoreManager = highScoreManager;
        }

        /// <summary>
        /// Runs The GameLoop
        /// </summary>
        public void MainLoop()
        {
            // Run function to create HighScore file
            HighScoreManager.CreateHighScores();

            // Instance Variables
            bool playing = false;
            Player.hp = 100.0f;
            Player.score = 0.0f;
            Level.currentLevel = 1;

            while (!playing)
            {
                Console.Clear();
                Renderer.MainMenu();
                string option = Console.ReadLine();
                Console.Clear();

                // Starts Game
                if (option == "1")
                {
                    playing = true;
                }

                // Displays HighScores
                else if (option == "2")
                {
                    Renderer.HighScores(Board);
                    Console.ReadLine();
                }

                // Displays Credits
                else if (option == "3")
                {
                    Renderer.Credits();
                    Console.ReadLine();
                }

                // Displays 'QuitGame' Menu
                else if (option == "4")
                {
                    Renderer.QuitGame();
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
                    Player.score = (1 + 0.4f * Board.Difficulty)
                        * ((Level.currentLevel - 1) + 0.1f * Player.enemiesKilled);

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
                        HighScoreManager.HighScoreManagement();
                        Console.ReadLine();
                        MainLoop();
                    }

                    foreach (Cell cell in Board.cellList)
                    {
                        cell.CheckOccupants(Player, Level);
                    }

                    // Renderer
                    Renderer.ShowGameValues(Board, Level);
                    Renderer.ShowPlayerStats(Player);
                    Renderer.DrawBoard(Board, Level);
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
                        HighScoreManager.HighScoreManagement();
                        Console.ReadLine();
                        MainLoop();
                    }

                    Console.Clear();
                }
            }
        }
    }
}