using System;

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
        InventoryManager InventoryManager;
        PossibleItems PossibleItems;

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
            InventoryManager = new InventoryManager(Player, Level);
            PossibleItems = new PossibleItems();
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
                string m1 = "";
                string m2 = "";
                string m3 = "";

                while (!finishedLevel)
                {
                    madeTurn = false;
                    Player.score = (1 + 0.4f * Board.Difficulty)
                        * ((Level.currentLevel - 1) + 0.1f * 
                        Player.enemiesKilled);

                    foreach (Trap trap in Level.trapList)
                    {
                        // Displays Trap(s) Name/Damage Dealt If Activated
                        if (Player.position.Row == trap.Row &&
                            Player.position.Column == trap.Column)
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

                    // Restart Messages For New Turn
                    m1 = "";
                    m2 = "";
                    m3 = "";

                    string turnOption = Console.ReadLine();

                    // "Move"
                    if (turnOption == "1" || turnOption == "2" ||
                        turnOption == "3" || turnOption == "4" ||
                        turnOption == "5" || turnOption == "6" ||
                        turnOption == "7" || turnOption == "8" ||
                        turnOption == "9")
                    {
                        Player.Move(turnOption, Board);
                        madeTurn = Player.hasMoved;
                    }

                    // "Look Around"
                    else if (turnOption == "L")
                    {
                        Player.LookAround(Board);
                    }

                    // "Pick_Up Item"
                    else if (turnOption == "E")
                    {
                        string itemDesired;

                        Console.WriteLine("What do you want to pick up?");
                        Console.WriteLine("1. Map\n" +
                                          "2. Weapon\n" +
                                          "3. Food\n");
                        itemDesired = Console.ReadLine();

                        switch (itemDesired)
                        {
                            // "Map"
                            case "1":
                                if (Player.position.Row == Level.map.Row &&
                                    Player.position.Column == Level.map.Column)
                                {
                                    Player.hasMap = true;
                                    Board.exploreAllCells();
                                    madeTurn = true;
                                }
                                else m1 = "No map found.";
                                break;

                            // "Weapon"
                            case "2":
                                m1 = InventoryManager.PickUpWeapon();
                                madeTurn = true;
                                break;

                            // "Food"
                            case "3":
                                m1 = InventoryManager.PickUpFood();
                                madeTurn = true;
                                break;

                            default:
                                m1 = "Invalid option.";
                                break;
                        }
                    }

                    // "Drop Item"
                    else if (turnOption == "D")
                    {
                        m1 = InventoryManager.DropItem();
                    }

                    // "Help"
                    else if (turnOption == "H")
                    {
                        Renderer.ShowHelp(PossibleItems);
                    }

                    // Get Map Cheat
                    else if (turnOption == "GIMMETHIRDEYE")
                    {
                        Player.hasMap = true;
                        Board.exploreAllCells();
                    }

                    // Restore Health Cheat
                    else if (turnOption == "HEALME")
                    {
                        Player.hp = 100;
                    }

                    // "QuitGame"
                    else if (turnOption == "Q")
                    {
                        Renderer.QuitGame();
                    }

                    // Begins Change To Next Level if Player's in 'EXIT' Cell
                    if (Player.position.Row == Level.exit.Row &&
                        Player.position.Column == Level.exit.Column)
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