using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto2aEpoca
{
    class HighScores
    {
        Board Board;
        public HighScores(Board board)
        {
            Board = board;
        }
        public void CreateNewFile(string path)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }
        }

        public Tuple<bool, int, int[]> CheckScore(Player player, string path)
        {

            bool canBeAdded = false;
            int posInHS = 0;
            int[] scoreList = new int[8];
            using (StreamReader streamReader = File.OpenText(path))
            {
                string score;
                int counter = 0;
                while ((score = streamReader.ReadLine()) != null)
                {
                    scoreList[counter] = Convert.ToInt32(score);
                    counter++;
                }
            }
            for (int i = 0; i < scoreList.Length; i++)
            {
                if (player.score >= scoreList[i])
                {
                    if (player.score == scoreList[7])
                    {
                        continue;
                    }
                    else
                    {
                        canBeAdded = true;
                        posInHS = i;
                    }
                }
            }
            Tuple<bool, int, int[]> returnValues = new Tuple<bool, int, int[]>(canBeAdded, posInHS, scoreList);

            return returnValues;
        }

        public void AddHighScore(Player player, Tuple<bool, int, int[]> scoreValues)
        {
            for (int i = scoreValues.Item3.Length; i < scoreValues.Item2; i--)
            {
                scoreValues.Item3[i] = scoreValues.Item3[i-1];
            }
        }
    }
}
