using System.Collections.Generic;

namespace Projeto2aEpoca
{
    class ScoreComparer : IComparer<HighScore>
    {
        /// <summary>
        /// Compare Method For The Comparer Interface, That Defines
        /// How Two HighScores Should Be Compared
        /// </summary>
        /// <param name="highScore1">
        /// First HighScore To Be Compared With The Second</param>
        /// <param name="highScore2">
        /// Second HighScore To Be Compared With The First</param>
        /// <returns></returns>
        public int Compare(HighScore highScore1, HighScore highScore2)
        {
            return highScore2.Score.CompareTo(highScore1.Score);
        }
    }
}

