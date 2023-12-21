//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public class Tetromino
    {
        public Tetromino(bool[,] body)
        {
            this.Body = body;
        }

        public bool[,] Body { get; private set; }

        public int Largura => this.Body.GetLength(0);

        public int Altura => this.Body.GetLength(1);

        public Tetromino GetRotate()
        {
            var newFigure = new bool[this.Altura, this.Largura];
            for (int row = 0; row < this.Largura; row++)
            {
                for (int col = 0; col < this.Altura; col++)
                {
                    newFigure[col, this.Largura - row - 1] = this.Body[row, col];
                }
            }

            return new Tetromino(newFigure);
        }
    }
}
