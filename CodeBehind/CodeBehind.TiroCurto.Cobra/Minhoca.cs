//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Cobra
{
    class Minhoca : IRenderable
    {
        private List<Posicao> _corpo;
        private int _crescimentoRestante;

        public Minhoca(Posicao spawnLocation, int initialSize = 1)
        {
            _corpo = new List<Posicao> { spawnLocation };
            _crescimentoRestante = Math.Max(0, initialSize - 1);
            Morto = false;
        }

        public bool Morto { get; private set; }
        public Posicao Cabeca => _corpo.First();
        private IEnumerable<Posicao> Body => _corpo.Skip(1);

        public void Mover(Direcao direction)
        {
            if (Morto) 
                throw new InvalidOperationException();

            Posicao novaCabeca;

            switch (direction)
            {
                case Direcao.Cima:
                    novaCabeca = Cabeca.DownBy(-1);
                    break;

                case Direcao.Esquerda:
                    novaCabeca = Cabeca.RightBy(-1);
                    break;

                case Direcao.Baixo:
                    novaCabeca = Cabeca.DownBy(1);
                    break;

                case Direcao.Direita:
                    novaCabeca = Cabeca.RightBy(1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_corpo.Contains(novaCabeca) || !PositionIsValid(novaCabeca))
            {
                Morto = true;
                return;
            }

            _corpo.Insert(0, novaCabeca);

            if (_crescimentoRestante > 0)
            {
                _crescimentoRestante--;
            }
            else
            {
                _corpo.RemoveAt(_corpo.Count - 1);
            }
        }

        public void Crescer()
        {
            if (Morto) 
                throw new InvalidOperationException();

            _crescimentoRestante++;
        }

        public void Desenhar()
        {
            Console.SetCursorPosition(Cabeca.Esquerda, Cabeca.Topo);
            Console.Write("◉");

            foreach (var position in Body)
            {
                Console.SetCursorPosition(position.Esquerda, position.Topo);
                Console.Write("■");
            }
        }

        private static bool PositionIsValid(Posicao position) => position.Topo >= 0 && position.Esquerda >= 0;
    }
}
