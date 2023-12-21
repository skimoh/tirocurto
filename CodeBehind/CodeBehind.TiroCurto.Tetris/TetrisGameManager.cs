//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public class TetrisGameManager
    {
        private ITetrisGame tetrisGame;
        private IInputHandler consoleInputHandler;
        private TetrisConsoleWriter tetrisConsoleWriter;
        private ScoreManager scoreManager;

        public TetrisGameManager(int TetrisRows, int TetrisCols)
        {
            this.tetrisGame = new TetrisGame(TetrisRows, TetrisCols);
            this.consoleInputHandler = new ConsoleInputHandler();
            this.tetrisConsoleWriter = new TetrisConsoleWriter(TetrisRows, TetrisCols, '▓');
            this.scoreManager = new ScoreManager();
        }

        public void MainLoop()
        {
            while (true)
            {
                tetrisConsoleWriter.Frame++;
                this.tetrisGame.UpdateLevel(scoreManager.Score);
                
                var entrada = this.consoleInputHandler.LerEntrada();

                switch (entrada)
                {
                    case TetrisGameInput.Esquerda:
                        if (this.tetrisGame.PodeMoverEsquerda())
                        {
                            this.tetrisGame.colunaCorrenteFigura--;
                        }
                        break;

                    case TetrisGameInput.Direita:
                        if (this.tetrisGame.PodeMoverDireita())
                        {
                            this.tetrisGame.colunaCorrenteFigura++;
                        }
                        break;


                    case TetrisGameInput.Baixo:
                        tetrisConsoleWriter.Frame = 1;
                        scoreManager.AddToScore(this.tetrisGame.Level, 0);
                        this.tetrisGame.linhaCorrenteFigura++;
                        break;

                    case TetrisGameInput.Rodar:
                        var newFigure = this.tetrisGame.CurrentFigure.GetRotate();
                        if (!this.tetrisGame.Collision(newFigure))
                        {
                            this.tetrisGame.CurrentFigure = newFigure;
                        }
                        break;

                    case TetrisGameInput.Sair:
                        return;
                }

                // Update the game state
                if (tetrisConsoleWriter.Frame % (tetrisConsoleWriter.FramesToMoveFigure - this.tetrisGame.Level) == 0)
                {
                    this.tetrisGame.linhaCorrenteFigura++;
                    tetrisConsoleWriter.Frame = 0;
                }

                if (this.tetrisGame.Collision(this.tetrisGame.CurrentFigure))
                {
                    this.tetrisGame.AddCurrentFigureToTetrisField();
                    int lines = this.tetrisGame.CheckForFullLines();
                    scoreManager.AddToScore(this.tetrisGame.Level, lines);
                    this.tetrisGame.GerarFiguraAleatoria();

                    if (this.tetrisGame.Collision(this.tetrisGame.CurrentFigure)) // game is over
                    {                        
                        tetrisConsoleWriter.DrawAll(this.tetrisGame, scoreManager);
                        tetrisConsoleWriter.DesenharGameOver(scoreManager.Score);
                        Thread.Sleep(100000);
                        return;
                    }
                }

                // Redraw UI
                tetrisConsoleWriter.DrawAll(this.tetrisGame, scoreManager);

                Thread.Sleep(40);
            }
        }
    }
}
