using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    class ScoreComparer : IComparer<HighScore>
    {
        public int Compare(HighScore highScore1, HighScore highScore2)
        {
            return highScore2.Score.CompareTo(highScore1.Score);
        }
    }
}

