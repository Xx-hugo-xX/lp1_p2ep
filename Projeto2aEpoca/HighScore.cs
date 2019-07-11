namespace Projeto2aEpoca
{
    /// <summary>
    /// Creates HighScore details
    /// </summary>
    public struct HighScore
    {
        /// <summary>
        /// Instance Variables
        /// </summary>
        public string Name { get; }
        public float Score { get; }

        /// <summary>
        /// Creates An Instance Of 'HighScore'
        /// </summary>
        /// <param name="name">
        /// Player's Name To Be Displayed In The HighScores</param>
        /// <param name="score"></param>
        public HighScore(string name, float score)
        {
            Name = name;
            Score = score;
        }
    }
}