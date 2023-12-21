//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public class ConsoleInputHandler : IInputHandler
    {
        public TetrisGameInput LerEntrada()
        {
            // Read user input
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    return TetrisGameInput.Sair;
                }

                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                {
                    return TetrisGameInput.Esquerda;
                }

                if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                {
                    return TetrisGameInput.Direita;
                }

                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                {
                    return TetrisGameInput.Baixo;
                }

                if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                {
                    return TetrisGameInput.Rodar;
                }
            }

            return TetrisGameInput.None;
        }
    }
}
