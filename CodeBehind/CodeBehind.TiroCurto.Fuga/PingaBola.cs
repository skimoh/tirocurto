//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Breakout
{
    public static class PingaBola
    {
        static object lockObject = new object();
        static int _tamanhoInicial = 10;
        static int _posicaoInicial = 0;
        static int _pontos = 0;
        static bool[,] _tijolos = new bool[10, 4];

        static int _posicaoBolaHorizontal = 0;
        static int _posicaoBolaVertical = 0;
        static int _direcaoBolaHorizontal = -1;
        static int _direcaoBolaVertical = 1;
        static int _score = 0;

        static Queue<int[]> filaBola = new Queue<int[]>();

        public static void Iniciar()
        {
            //limpando o console
            Console.Clear();
            _score = 0;
            _pontos = 0;
            _tijolos = new bool[10, 4];

            RemoverTijolo();

            _posicaoInicial = Console.WindowWidth / 2 - _tamanhoInicial / 2;

            PosicionandoNaTela();

            DesenharTijolo();

            DesenharPlataforma();
        }

        public static void RemoveBola()
        {
            int[] a;
            while (filaBola.Count > 0)
            {
                a = filaBola.Dequeue();
                DesenharTela(a[0], a[1], ' ');
            }
        }

        public static void DesenhaBola()
        {
            DesenharTela(_posicaoBolaHorizontal, _posicaoBolaVertical, 'O');

            filaBola.Enqueue(new int[] { _posicaoBolaHorizontal, _posicaoBolaVertical });
        }

        public static void CursorAtTheStart()
        {
            Console.SetCursorPosition(0, 0);
        }

        public static void RemoverTijolo()
        {
            for (int x = _posicaoInicial; x < _posicaoInicial + _tamanhoInicial; x++)
            {
                DesenharTela(x, Console.WindowHeight - 1, ' ');
            }
        }

        public static void DesenharPlataforma()
        {
            for (int x = _posicaoInicial; x < _posicaoInicial + _tamanhoInicial; x++)
            {
                DesenharTela(x, Console.WindowHeight - 1, '=');
            }
        }
        public static int AdicionarAltunaTijolo(int j)
        {
            return j + 5;
        }
        public static void DesenharTijolo()
        {
            for (int i = 0; i < _tijolos.GetLength(0); i++)
            {
                for (int j = 0; j < _tijolos.GetLength(1); j++)
                {
                    _tijolos[i, j] = true;
                    DesenharTela((i * 5), AdicionarAltunaTijolo(j), '[');
                    for (int k = 1; k < 4; k++)
                    {
                        DesenharTela((i * 5) + k, AdicionarAltunaTijolo(j), '=');
                    }
                    DesenharTela((i * 5) + 4, AdicionarAltunaTijolo(j), ']');
                }
            }
        }

        public static void MovePlataformaDireita()
        {
            if (_posicaoInicial < Console.WindowWidth - _tamanhoInicial - 2)
            {
                _posicaoInicial++;
            }
        }

        public static void MovePlataformaEsquerda()
        {
            if (_posicaoInicial > 0)
            {
                _posicaoInicial--;
            }
        }

        public static void PosicionandoNaTela()
        {
            _posicaoBolaHorizontal = Console.WindowWidth / 2;
            _posicaoBolaVertical = Console.WindowHeight / 2;
        }

        public static void RemoverBarraLateral()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public static void MoverBolinha()
        {
            _posicaoBolaHorizontal += _direcaoBolaHorizontal;
            _posicaoBolaVertical += _direcaoBolaVertical;

            for (int i = 0; i < _tijolos.GetLength(0); i++)
            {
                for (int j = 0; j < _tijolos.GetLength(1); j++)
                {
                    if (_tijolos[i, j])
                    {
                        if (_posicaoBolaHorizontal >= (i * 5) && _posicaoBolaHorizontal <= (i * 5 + 4) && _posicaoBolaVertical == AdicionarAltunaTijolo(j))
                        {
                            _direcaoBolaVertical *= -1;

                            _tijolos[i, j] = false;
                            _pontos++;
                            if (_pontos == 40)
                            {
                                Iniciar();
                                return;
                            }

                            for (int k = 0; k < 5; k++)
                            {
                                DesenharTela((i * 5) + k, AdicionarAltunaTijolo(j), ' ');
                            }
                            Console.Beep();
                            _score++;
                            DesenharTextoTela(0, 0, $"SCORE [{_score.ToString()}]");
                        }
                    }

                }
            }

            //top
            if (_posicaoBolaVertical == 0)
                _direcaoBolaVertical = 1;

            //sides
            if (_posicaoBolaHorizontal > Console.WindowWidth - 2 || _posicaoBolaHorizontal == 0)
                _direcaoBolaHorizontal = -1 * _direcaoBolaHorizontal;

            //paddle
            if (_posicaoBolaVertical > Console.WindowHeight - 3)
            {
                if (_posicaoInicial <= _posicaoBolaHorizontal && _posicaoInicial + _tamanhoInicial >= _posicaoBolaHorizontal)
                    _direcaoBolaVertical = -1 * _direcaoBolaVertical;
                else
                    Iniciar();
            }
        }

        public static void DesenharTela(int x, int y, char symbol)
        {
            lock (lockObject)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(symbol);
            }
        }

        public static void DesenharTextoTela(int horizontal, int vertical, string texto)
        {
            lock (lockObject)
            {
                Console.SetCursorPosition(horizontal, vertical);
                Console.Write(texto);
            }
        }
    }
}
