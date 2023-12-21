//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.Text.RegularExpressions;

namespace CodeBehind.TiroCurto.Tetris
{
    public class ScoreManager
    {        
        private readonly int[] ScorePerLines = { 1, 40, 100, 300, 1200 };

        public ScoreManager()
        {                        
        }

        public int Score { get; private set; }        

        public void AddToScore(int level, int lines)
        {
            this.Score += ScorePerLines[lines] * level;            
        }
    }
}
