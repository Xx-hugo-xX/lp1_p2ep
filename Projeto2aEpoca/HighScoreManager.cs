using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto2aEpoca
{
    class HighScoreManager
    {
        string fileName;
        char separator;
        List<HighScore> scoreList;

        Board Board;
        Player Player;

        public HighScoreManager(Board board, Player player)
        {
            Board = board;
            Player = player;

            fileName = $"HighScores_{Board.Rows}x{Board.Columns}.txt";
            separator = '\t';
        }
        /// <summary>
        /// Creates A File For The HighScores, And If The File 
        /// Already Exists, Adds The Existing Scores To 'scoreList'
        /// </summary>
        public void CreateHighScores()
        {
            scoreList = new List<HighScore>();

            // Creates A New File If It Doesn't Exist Already
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                }
            }

            StreamReader sr = new StreamReader(fileName);
            char separator = '\t';
            string s;

            /*
             *Reads Scores And Adds Them To
             *'scoreList' So They Can Be Compared
             */
            while ((s = sr.ReadLine()) != null)
            {
                string[] nameAndScore = s.Split(separator);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                scoreList.Add(new HighScore(name, score));
            }
            // Closes File So It Can Be Accessed In Other Methods
            sr.Close();
        }

        /// <summary>
        /// Adds The Player's Score To 'scoreList' If It's
        /// Better Than The Worst One
        /// </summary>
        public void AddScore()
        {
            string name;

            // If 'scoreList' Isn't Full, Add Player To The List
            if (scoreList.Count < 8)
            {
                Console.Clear();
                Console.WriteLine("New HighScore! What should we call you?\n");
                name = Console.ReadLine() + "          ";
                name = name.Substring(0, 10);

                Console.WriteLine($"\nYour score of {Player.score} was added to the {Board.Rows}x{Board.Columns} board HighScores!");

                scoreList.Add(new HighScore(name, Player.score));
                SortHighScores();
            }
            //If 'scoreList' Is Full
            else
            {
                // Checks If Player's Score Is Better Than Any Score In The List
                bool isHigher = false;
                for (int i = 0; i < scoreList.Count; i++)
                {
                    if (Player.score > scoreList[i].Score)
                    {
                        isHigher = true;
                    }
                }

                // Adds Score If It's Better
                if (isHigher)
                {
                    Console.Clear();
                    Console.WriteLine("New HighScore! What should we call you?\n");
                    name = Console.ReadLine() + "          ";
                    name = name.Substring(0, 10);

                    Console.WriteLine($"\nYour score of {Player.score} was added to the {Board.Rows}x{Board.Columns} board HighScores!");

                    scoreList.Add(new HighScore(name, Player.score));

                    SortHighScores();
                }
            }
        }

        /// <summary>
        /// Sorts HighScore With The Given Comparer And
        /// If The Player's Score Was Added To 'scoreList', 
        /// Removes The Lowest Score
        /// </summary>
        public void SortHighScores()
        {
            // Sorts HighScores With The Given Comparer

            scoreList.Sort(new ScoreComparer());

            //If A Score Was Added, Remove The Lowest Score
            if (scoreList.Count > 8)
            {
                scoreList.RemoveAt(8);
            }
        }

        /// <summary>
        /// Rewrites HighScores Using The Changed Values of 'scoreList'
        /// </summary>
        public void SaveHighScores()
        {
            StreamWriter sw = new StreamWriter(fileName);

            foreach (HighScore hs in scoreList)
            {
                sw.WriteLine(hs.Name + separator + hs.Score);
            }
            sw.Close();
        }

        /// <summary>
        /// Runs All HighScore Functions
        /// </summary>
        public void HighScoreManagement()
        {
            AddScore();
            SortHighScores();
            SaveHighScores();
        }
    }
}
