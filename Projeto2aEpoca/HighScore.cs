using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto2aEpoca
{
    public struct HighScore
    {
        /// <summary>
        /// Saves an instance that has the player's name and his score
        /// </summary>
        
        public string Name { get; }
        public float Score { get; }

        public HighScore(string name, float score)
        {
            Name = name;
            Score = score;
        }
    }
}