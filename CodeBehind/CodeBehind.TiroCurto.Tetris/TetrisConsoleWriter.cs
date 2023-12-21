//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.VisualBasic;

namespace CodeBehind.TiroCurto.Tetris
{
    public class TetrisConsoleWriter
    {
        private int tetrisRows;
        private int tetrisColumns;
        private int infoColumns;
        private int consoleRows;
        private int consoleColumns;
        private char tetrisCharacter;

        public TetrisConsoleWriter(
            int tetrisRows,
            int tetrisColumns,
            char tetrisCharacter = '*',
            int infoColumns = 11)
        {
            this.tetrisRows = tetrisRows;
            this.tetrisColumns = tetrisColumns;
            this.tetrisCharacter = tetrisCharacter;
            this.infoColumns = infoColumns;
            this.consoleRows = 1 + this.tetrisRows + 1;
            this.consoleColumns = 1 + this.tetrisColumns + 1 + this.infoColumns + 1;

            this.Frame = 0;
            this.FramesToMoveFigure = 15;

            Console.WindowHeight = this.consoleRows + 1;
            Console.WindowWidth = this.consoleColumns;
            Console.BufferHeight = this.consoleRows + 1;
            Console.BufferWidth = this.consoleColumns;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Tetris v1.0";
            Console.CursorVisible = false;
        }

        public int Frame { get; set; }

        public int FramesToMoveFigure { get; private set; }

        public void DrawAll(ITetrisGame state, ScoreManager scoreManager)
        {
            this.MontarAreaJogo();
            this.MontarAreaInformacao(3 + this.tetrisColumns, state, scoreManager);
            this.MontarBlocosTela(state.TetrisField);
            this.MontarBlocoAtual(state.CurrentFigure, state.linhaCorrenteFigura, state.colunaCorrenteFigura);

        }

        public void MontarAreaInformacao(int startColumn, ITetrisGame state, ScoreManager scoreManager)
        {
            this.DesenharTexto("Level:", 1, startColumn);
            this.DesenharTexto(state.Level.ToString(), 2, startColumn);
            this.DesenharTexto("Score:", 4, startColumn);
            this.DesenharTexto(scoreManager.Score.ToString(), 5, startColumn);            
            this.DesenharTexto("Quadros:", 10, startColumn);
            this.DesenharTexto(this.Frame.ToString() + " / " + (this.FramesToMoveFigure - state.Level).ToString(), 11, startColumn);
            this.DesenharTexto("Posicao:", 13, startColumn);
            this.DesenharTexto($"{state.linhaCorrenteFigura}, {state.colunaCorrenteFigura}", 14, startColumn);
            this.DesenharTexto("Botoes:", 16, startColumn);
            this.DesenharTexto($"  ^ ", 18, startColumn);
            this.DesenharTexto($"<   > ", 19, startColumn);
            this.DesenharTexto($"  v  ", 20, startColumn);
        }

        public void MontarAreaJogo()
        {
            Console.SetCursorPosition(0, 0);
            string line = "╔";
            line += new string('═', this.tetrisColumns);
            /* for (int i = 0; i < TetrisCols; i++)
            {
                line += "═";
            } */

            line += "╦";
            line += new string('═', this.infoColumns);
            line += "╗";
            Console.Write(line);

            for (int i = 0; i < this.tetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', this.tetrisColumns);
                middleLine += "║";
                middleLine += new string(' ', this.infoColumns);
                middleLine += "║";
                Console.Write(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', this.tetrisColumns);
            endLine += "╩";
            endLine += new string('═', this.infoColumns);
            endLine += "╝";
            Console.Write(endLine);
        }

        public void DesenharGameOver(int score)
        {
            int row = this.tetrisRows / 2 - 3;
            int column = (this.tetrisColumns + 3 + this.infoColumns) / 2 - 6;

            var scoreAsString = score.ToString();
            scoreAsString = new string(' ', 7 - scoreAsString.Length) + scoreAsString;
            DesenharTexto("╔═════════╗", row, column);
            DesenharTexto("║ Game    ║", row + 1, column);
            DesenharTexto("║   over! ║", row + 2, column);
            DesenharTexto($"║ {scoreAsString} ║", row + 3, column);
            DesenharTexto("╚═════════╝", row + 4, column);
        }

        public void MontarBlocosTela(bool[,] tetrisField)
        {
            for (int row = 0; row < tetrisField.GetLength(0); row++)
            {
                string line = "";
                for (int col = 0; col < tetrisField.GetLength(1); col++)
                {
                    if (tetrisField[row, col])
                    {
                        line += tetrisCharacter;
                    }
                    else
                    {
                        line += "";
                    }
                }

                this.DesenharTexto(line, row + 1, 1);
            }
        }

        public void MontarBlocoAtual(Tetromino currentFigure, int currentFigureRow, int currentFigureColumn)
        {
            for (int row = 0; row < currentFigure.Largura; row++)
            {
                for (int col = 0; col < currentFigure.Altura; col++)
                {
                    if (currentFigure.Body[row, col])
                    {
                        DesenharCaracter(row + 1 + currentFigureRow, 1 + currentFigureColumn + col, tetrisCharacter);
                    }
                }
            }
        }

        private void DesenharTexto(string text, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }

        public void DesenharCaracter(int vertical, int horizontal, char symbol, ConsoleColor cor = ConsoleColor.White)
        {
            Console.SetCursorPosition(horizontal, vertical);
            Console.ForegroundColor = cor;
            Console.Write(symbol);
        }
    }
}
