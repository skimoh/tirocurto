namespace CodeBehind.TiroCurto.Tron
{
    public static class Engine
    {
        public static int _esquerda = 0;
        public static int _direita = 1;
        public static int _cima = 2;
        public static int _baixo = 3;
        
        public static int _P1Score = 0;
        public static int _P1Direcao = _direita;
        public static int _P1Coluna = 0; 
        public static int _P1Linha = 0; 
        
        public static int _P2Score = 0;
        public static int _P2Direcao = _esquerda;
        public static int _P2Coluna = 40; 
        public static int _P2Linha = 5; 


        public static bool[,] isUsed;

        public static void IniciandoOrientacao()
        {
            string heading = "** TRON GAME ** ";
            Console.CursorLeft = Console.BufferWidth / 2 - heading.Length / 2;
            Console.WriteLine(heading);


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("P1 CONTROLE:\n");
            Console.WriteLine("W - Cima");
            Console.WriteLine("A - Esquerda");
            Console.WriteLine("S - Baixo");
            Console.WriteLine("D - Direita");

            string longestString = "------------------------------------";
            int posicaoDaEsquerda = Console.BufferWidth - longestString.Length;

            Console.CursorTop = 1;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = posicaoDaEsquerda;
            Console.WriteLine("P2 CONTROLE:\n");
            Console.CursorLeft = posicaoDaEsquerda;
            Console.WriteLine("Seta - Cima");
            Console.CursorLeft = posicaoDaEsquerda;
            Console.WriteLine("Seta - Esquerda");
            Console.CursorLeft = posicaoDaEsquerda;
            Console.WriteLine("Seta - Baixo");
            Console.CursorLeft = posicaoDaEsquerda;
            Console.WriteLine("Seta - Direita");

            Console.ReadKey();
            Console.Clear();
        }
        public static void ReiniciarJogo()
        {
            isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
            DefinindoParametro();
            _P1Direcao = _direita;
            _P2Direcao = _esquerda;
            Console.WriteLine("PRESSIONE ESPACO PARA INICIAR NOVAMENTE");
            Console.ReadKey();
            Console.Clear();
            MovePlayers();
        }


        public static bool DoesPlayerLose(int row, int col)
        {
            if (row < 0)
            {
                return true;
            }
            if (col < 0)
            {
                return true;
            }
            if (row >= Console.WindowHeight)
            {
                return true;
            }
            if (col >= Console.WindowWidth)
            {
                return true;
            }


            if (isUsed[col, row])
            {
                return true;
            }


            return false;
        }


        public static void DefinindoParametro()
        {
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            Console.WindowWidth = 100;
            Console.BufferWidth = 100;

            _P1Coluna = 0;
            _P1Linha = Console.WindowHeight / 2;

            _P2Coluna = Console.WindowWidth - 1;
            _P2Linha = Console.WindowHeight / 2;
        }


        public static void MovePlayers()
        {
            if (_P1Direcao == _direita)
            {
                _P1Coluna++;
            }
            if (_P1Direcao == _esquerda)
            {
                _P1Coluna--;
            }
            if (_P1Direcao == _cima)
            {
                _P1Linha--;
            }
            if (_P1Direcao == _baixo)
            {
                _P1Linha++;
            }


            if (_P2Direcao == _direita)
            {
                _P2Coluna++;
            }
            if (_P2Direcao == _esquerda)
            {
                _P2Coluna--;
            }
            if (_P2Direcao == _cima)
            {
                _P2Linha--;
            }
            if (_P2Direcao == _baixo)
            {
                _P2Linha++;
            }
        }


        public static void DesenharTela(int x, int y, char ch, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }


        public static void MudarDirecao(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W && _P1Direcao != _baixo)
            {
                _P1Direcao = _cima;
            }
            if (key.Key == ConsoleKey.A && _P1Direcao != _direita)
            {
                _P1Direcao = _esquerda;
            }
            if (key.Key == ConsoleKey.D && _P1Direcao != _esquerda)
            {
                _P1Direcao = _direita;
            }
            if (key.Key == ConsoleKey.S && _P1Direcao != _cima)
            {
                _P1Direcao = _baixo;
            }


            if (key.Key == ConsoleKey.UpArrow && _P2Direcao != _baixo)
            {
                _P2Direcao = _cima;
            }
            if (key.Key == ConsoleKey.LeftArrow && _P2Direcao != _direita)
            {
                _P2Direcao = _esquerda;
            }
            if (key.Key == ConsoleKey.RightArrow && _P2Direcao != _esquerda)
            {
                _P2Direcao = _direita;
            }
            if (key.Key == ConsoleKey.DownArrow && _P2Direcao != _cima)
            {
                _P2Direcao = _baixo;
            }
        }

    }
}
