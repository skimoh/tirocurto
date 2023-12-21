//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public interface IInputHandler
    {
        TetrisGameInput LerEntrada();
    }

    public class AiInputHandler : IInputHandler
    {
        private readonly TetrisGame game;

        public AiInputHandler(TetrisGame game)
        {
            this.game = game;
        }

        public TetrisGameInput LerEntrada()
        {
            return TetrisGameInput.Baixo;
        }
    }
}
