﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class GameLoop
    {
        Board Board;
        Renderer Renderer;
        Level Level;
        Player Player;

        bool playing = false;

        public GameLoop(Board board, Renderer renderer, Level level, Player player)
        {
            Board = board;
            Renderer = renderer;
            Level = level;
            Player = player;
        }


        public void PlayGame()
        {
            while(!playing)
            {
                Console.Clear();
                Renderer.MainMenu();
                char option = Convert.ToChar(Console.ReadLine());

                Console.Clear();
                if (option == '1')
                {
                    playing = true;
                }
                else if (option == '2')
                {
                    Renderer.HighScores();
                    Console.ReadLine();
                }

                else if (option == '3')
                {
                    Renderer.Credits();
                    Console.ReadLine();
                }
                else if (option == '4')
                {
                    Environment.Exit(0);
                }
            }

            while (playing)
            {
                Level.StartNewLevel();
                bool finishedLevel = false;
                bool madeTurn = false;
                while (!finishedLevel)
                {
                    foreach (Cell cell in Board.cellList)
                    {
                        cell.CheckOccupants(Player, Level);
                    }

                    Renderer.ShowGameValues(Board, Level);
                    Renderer.ShowPlayerStats(Player);
                    Renderer.DrawMap(Board, Level);

                    Renderer.ShowLegend();

                    string moveOption = Console.ReadLine();

                    if (moveOption == "1" || moveOption == "2" ||
                        moveOption == "3" || moveOption == "4" ||
                        moveOption == "5" || moveOption == "6" ||
                        moveOption == "7" || moveOption == "8" ||
                        moveOption == "9")
                    {
                        Player.Move(moveOption, Board);
                        madeTurn = Player.hasMoved;
                    }

                    else if (moveOption == "L")
                    {
                        Player.LookAround(Board);
                    }
                    else if (moveOption == "E")
                    {
                        if (Player.playerPosition.Row == Level.map.Row &&
                            Player.playerPosition.Column == Level.map.Column)
                        {
                            Player.hasMap = true;
                            Board.exploreAllCells();
                        }
                    }

                    if (Player.playerPosition.Row == Level.exit.Row && Player.playerPosition.Column == Level.exit.Column)
                    {
                        Level.NextLevel();
                        finishedLevel = true;
                    }

                    if (madeTurn) Player.hp -= 1.0f;
                    if (Player.hp <= 0.0f)
                    {
                        Player.PlayerDeath();
                        Environment.Exit(0);
                    }

                    Console.Clear();
                }
            }
        }
    }
}