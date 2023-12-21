//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Cobra
{
    class Fruta : IRenderable
    {
        public Fruta(Posicao posicao)
        {
            Posicao = posicao;
        }

        public Posicao Posicao { get; }

        public void Desenhar()
        {
            Console.SetCursorPosition(Posicao.Esquerda, Posicao.Topo);
            Console.Write("🍏");
        }
    }
}
