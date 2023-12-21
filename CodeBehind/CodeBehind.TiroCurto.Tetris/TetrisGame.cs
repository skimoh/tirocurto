//***CODE BEHIND - BY RODOLFO.FONSECA***//

namespace CodeBehind.TiroCurto.Tetris
{
    public interface ITetrisGame
    {
        Tetromino CurrentFigure { get; set; }
        int colunaCorrenteFigura { get; set; }
        int linhaCorrenteFigura { get; set; }
        int Level { get; }
        int TetrisColumns { get; }
        bool[,] TetrisField { get; }
        int TetrisRows { get; }

        void AddCurrentFigureToTetrisField();
        int CheckForFullLines();
        bool Collision(Tetromino figure);
        void GerarFiguraAleatoria();
        void UpdateLevel(int score);
        bool PodeMoverEsquerda();
        bool PodeMoverDireita();
    }

    public enum TetrisGameInput
    {
        None = 0,
        Esquerda = 1,
        Direita = 2,
        Baixo = 3,
        Rodar = 4,
        Sair = 99,
    }

    public class TetrisGame : ITetrisGame
    {
        protected readonly List<Tetromino> TetrisFigures = new List<Tetromino>()
            {
                new Tetromino(new bool[,] // ----
                {
                    { true, true, true, true }
                }),
                new Tetromino(new bool[,] // O
                {
                    { true, true },
                    { true, true }
                }),
                /*new bool[,] // big O
                {
                    { true, true, true },
                    { true, true, true },
                    { true, true, true },
                },*/
                new Tetromino(new bool[,] // T
                {
                    { false, true, false },
                    { true, true, true },
                }),
                new Tetromino(new bool[,] // S
                {
                    { false, true, true, },
                    { true, true, false, },
                }),
                new Tetromino(new bool[,] // Z
                {
                    { true, true, false },
                    { false, true, true },
                }),
                new Tetromino(new bool[,] // J
                {
                    { true, false, false },
                    { true, true, true }
                }),
                new Tetromino(new bool[,] // L
                {
                    { false, false, true },
                    { true, true, true }
                }),
            };

        private Random random;

        public TetrisGame(int tetrisRows, int tetrisColumns)
        {
            this.Level = 1;
            this.CurrentFigure = null;
            this.linhaCorrenteFigura = 0;
            this.colunaCorrenteFigura = 0;
            this.TetrisField = new bool[tetrisRows, tetrisColumns];
            this.TetrisRows = tetrisRows;
            this.TetrisColumns = tetrisColumns;
            this.random = new Random();
            this.GerarFiguraAleatoria();
        }

        public int Level { get; private set; }

        public Tetromino CurrentFigure { get; set; }

        public int linhaCorrenteFigura { get; set; }

        public int colunaCorrenteFigura { get; set; }

        public bool[,] TetrisField { get; private set; }

        public int TetrisRows { get; }

        public int TetrisColumns { get; }

        public void UpdateLevel(int score)
        {
            // TODO: On next level lower FramesToMoveFigure
            if (score <= 0)
            {
                this.Level = 1;
                return;
            }

            this.Level = (int)Math.Log10(score) - 1;
            if (this.Level < 1)
            {
                this.Level = 1;
            }

            if (this.Level > 10)
            {
                this.Level = 10;
            }
        }

        public virtual void GerarFiguraAleatoria()
        {
            this.CurrentFigure = TetrisFigures[this.random.Next(0, this.TetrisFigures.Count)];
            this.linhaCorrenteFigura = 0;
            this.colunaCorrenteFigura = this.TetrisColumns / 2 - this.CurrentFigure.Largura / 2;
        }

        public void AddCurrentFigureToTetrisField()
        {
            for (int row = 0; row < this.CurrentFigure.Largura; row++)
            {
                for (int col = 0; col < this.CurrentFigure.Altura; col++)
                {
                    if (this.CurrentFigure.Body[row, col])
                    {
                        this.TetrisField[this.linhaCorrenteFigura + row, this.colunaCorrenteFigura + col] = true;
                    }
                }
            }
        }

        public int CheckForFullLines() // 0, 1, 2, 3, 4
        {
            int lines = 0;

            for (int row = 0; row < this.TetrisField.GetLength(0); row++)
            {
                bool rowIsFull = true;
                for (int col = 0; col < this.TetrisField.GetLength(1); col++)
                {
                    if (this.TetrisField[row, col] == false)
                    {
                        rowIsFull = false;
                        break;
                    }
                }

                if (rowIsFull)
                {
                    for (int rowToMove = row; rowToMove >= 1; rowToMove--)
                    {
                        for (int col = 0; col < this.TetrisField.GetLength(1); col++)
                        {
                            this.TetrisField[rowToMove, col] = this.TetrisField[rowToMove - 1, col];
                        }
                    }

                    lines++;
                }
            }
            return lines;
        }

        public bool Collision(Tetromino figure)
        {
            if (this.colunaCorrenteFigura > this.TetrisColumns - figure.Altura)
            {
                return true;
            }

            if (this.linhaCorrenteFigura + figure.Largura == this.TetrisRows)
            {
                return true;
            }

            for (int row = 0; row < figure.Largura; row++)
            {
                for (int col = 0; col < figure.Altura; col++)
                {
                    if (figure.Body[row, col] &&
                        this.TetrisField[this.linhaCorrenteFigura + row + 1, this.colunaCorrenteFigura + col])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverEsquerda()
        {
            return (this.colunaCorrenteFigura >= 1 && !CheckForCollision(-1));
        }

        public bool PodeMoverDireita()
        {
            return (this.colunaCorrenteFigura < this.TetrisColumns - this.CurrentFigure.Altura)
                && !CheckForCollision(1);
        }
        private bool CheckForCollision(int direction) //direction = -1 left, = 1 right
        {
            for (int row = 0; row < CurrentFigure.Largura; row++)
            {
                for (int col = 0; col < CurrentFigure.Altura; col++)
                {
                    if (CurrentFigure.Body[row, col] &&
                        this.TetrisField[this.linhaCorrenteFigura + row, this.colunaCorrenteFigura + col + direction])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
