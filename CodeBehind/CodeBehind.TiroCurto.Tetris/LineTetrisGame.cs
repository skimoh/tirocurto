//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public class LineTetrisGame : TetrisGame
    {
        public LineTetrisGame(int tetrisRows, int tetrisColumns) :
            base(tetrisRows, tetrisColumns)
        {
        }

        public override void GerarFiguraAleatoria()
        {
            this.CurrentFigure = TetrisFigures[0].GetRotate();
            this.linhaCorrenteFigura = 0;
            this.colunaCorrenteFigura = this.TetrisColumns / 2 - this.CurrentFigure.Largura / 2;
        }
    }
}
