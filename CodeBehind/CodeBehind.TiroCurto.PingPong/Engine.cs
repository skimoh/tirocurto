namespace CodeBehind.TiroCurto.PingPong
{
    public static class Engine
    {
        public static int _tamanhoP1 = 10;
        public static int _tamanhoP2 = 5;
        public static int ballPositionX = 0;
        public static int ballPositionY = 0;
        public static bool ballDirectionUp = true; // Determines if the ball direction is up
        public static bool ballDirectionRight = false;
        public static int _posicaoP1 = 0;
        public static int _posicaoP2 = 0;
        public static int _contadorPontosP1 = 0;
        public static int _contadorPontosP2 = 0;
        public static Random rd = new Random();

        public static void RemoverBarraLateral()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public static void DesenharP1()
        {
            for (int y = _posicaoP1; y < _posicaoP1 + _tamanhoP1; y++)
            {
                DesenharTela(0, y, '|', ConsoleColor.Green);
                DesenharTela(1, y, '|', ConsoleColor.Green);
            }
        }

        public static void DesenharTela(int x, int y, char symbol, ConsoleColor cor = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = cor;
            Console.Write(symbol);
        }

        public static void DesenharP2()
        {
            for (int y = _posicaoP2; y < _posicaoP2 + _tamanhoP2; y++)
            {
                DesenharTela(Console.WindowWidth - 1, y, '|');
                DesenharTela(Console.WindowWidth - 2, y, '|');
            }
        }

        public static void IniciandoPosicao()
        {
            _posicaoP1 = Console.WindowHeight / 2 - _tamanhoP1 / 2;
            _posicaoP2 = Console.WindowHeight / 2 - _tamanhoP2 / 2;
            ColocandoBolaNoMeioTela();
        }

        public static void ColocandoBolaNoMeioTela()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        public static void DesenharBola()
        {
            DesenharTela(ballPositionX, ballPositionY, 'O', ConsoleColor.Yellow);
        }

        public static void DesenhaResultado()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("P1 {0}-{1} P2", _contadorPontosP1, _contadorPontosP2);
        }

        public static void MoverPraBaixo()
        {
            if (_posicaoP1 < Console.WindowHeight - _tamanhoP1)
            {
                _posicaoP1++;
            }
        }

        public static void MoverPraCima()
        {
            if (_posicaoP1 > 0)
            {
                _posicaoP1--;
            }
        }

        public static void MoveSecondPlayerDown()
        {
            if (_posicaoP2 < Console.WindowHeight - _tamanhoP2)
            {
                _posicaoP2++;
            }
        }

        public static void MoveSecondPlayerUp()
        {
            if (_posicaoP2 > 0)
            {
                _posicaoP2--;
            }
        }

        public static void SecondPlayerAIMove()
        {
            int randomNumber = rd.Next(1, 101);
            //if (randomNumber == 0)
            //{
            //    MoveSecondPlayerUp();
            //}
            //if (randomNumber == 1)
            //{
            //    MoveSecondPlayerDown();
            //}
            if (randomNumber <= 70)
            {
                if (ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }

        public static void MoverBola()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                ColocandoBolaNoMeioTela();
                ballDirectionRight = false;
                ballDirectionUp = true;
                _contadorPontosP1++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("P1 Venceu!");
                Console.ReadKey();
            }
            if (ballPositionX == 0)
            {
                ColocandoBolaNoMeioTela();
                ballDirectionRight = true;
                ballDirectionUp = true;
                _contadorPontosP2++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("P2 Venceu!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= _posicaoP1
                    && ballPositionY < _posicaoP1 + _tamanhoP1)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 3 - 1)
            {
                if (ballPositionY >= _posicaoP2
                    && ballPositionY < _posicaoP2 + _tamanhoP2)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }


            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }
    }
}
