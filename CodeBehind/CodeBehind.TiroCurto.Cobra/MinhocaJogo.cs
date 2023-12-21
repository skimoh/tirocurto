//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Cobra
{
    public class MinhocaJogo : IRenderable
    {
        private static readonly Posicao Origin = new Posicao(0, 0);

        private Direcao _direcaoAtual;
        private Direcao _proximaDirecao;
        private Minhoca _minhoca;
        private Fruta _fruta;
        public static int _score = 0;

        public MinhocaJogo()
        {
            _minhoca = new Minhoca(Origin, initialSize: 5);
            _fruta = CriarFruta();
            _direcaoAtual = Direcao.Direita;
            _proximaDirecao = Direcao.Direita;
        }

        public bool fimJogo => _minhoca.Morto;

        public void OnKeyPress(ConsoleKey key)
        {
            Direcao novaDirecaoQuandoApertar;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    novaDirecaoQuandoApertar = Direcao.Cima;
                    break;

                case ConsoleKey.LeftArrow:
                    novaDirecaoQuandoApertar = Direcao.Esquerda;
                    break;

                case ConsoleKey.DownArrow:
                    novaDirecaoQuandoApertar = Direcao.Baixo;
                    break;

                case ConsoleKey.RightArrow:
                    novaDirecaoQuandoApertar = Direcao.Direita;
                    break;

                default:
                    return;
            }

            // Snake cannot turn 180 degrees.
            if (novaDirecaoQuandoApertar == OppositeDirectionTo(_direcaoAtual))
            {
                return;
            }

            _proximaDirecao = novaDirecaoQuandoApertar;
        }

        public void MoveEValida()
        {
            if (fimJogo) 
                throw new InvalidOperationException();

            _direcaoAtual = _proximaDirecao;
            _minhoca.Mover(_direcaoAtual);

            //se encontrou a fruta
            if (_minhoca.Cabeca.Equals(_fruta.Posicao))
            {
                _minhoca.Crescer();
                _fruta = CriarFruta();
                _score++;
            }
        }

        public void Desenhar()
        {
            Console.Clear();
            _minhoca.Desenhar();
            _fruta.Desenhar();
            Console.SetCursorPosition(0, 0);
        }

        private static Direcao OppositeDirectionTo(Direcao direction)
        {
            switch (direction)
            {
                case Direcao.Cima: return Direcao.Baixo;
                case Direcao.Esquerda: return Direcao.Direita;
                case Direcao.Direita: return Direcao.Esquerda;
                case Direcao.Baixo: return Direcao.Cima;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Criando a maça na proxima posição apos a minhoca comer
        /// </summary>
        /// <returns></returns>
        private static Fruta CriarFruta()
        {            
            const int numeroLinha = 20;
            const int numeroColuna = 20;

            var random = new Random();
            var topo = random.Next(0, numeroLinha + 1);
            var esquerda = random.Next(0, numeroColuna + 1);
            var posicao = new Posicao(topo, esquerda);
            var fruta = new Fruta(posicao);

            return fruta;
        }
    }
}
