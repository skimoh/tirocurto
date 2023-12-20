using CodeBehind.TiroCurto.Cobra;
using static System.Formats.Asn1.AsnWriter;

Console.WriteLine($"-----------------------------------------");
Console.WriteLine($"BEM VINDO AO JOGO DA MINHOCA MALUCA");
Console.WriteLine("");
Console.WriteLine($"UTILIZE AS SETAS <- ^ v -> PARA MOVER A MINHOCA");
Console.WriteLine($"-----------------------------------------");

Thread.Sleep(4000);

var tempoSalto = TimeSpan.FromMilliseconds(100);
var jogoMinhoca = new MinhocaJogo();

using (var cts = new CancellationTokenSource())
{
    async Task MonitorKeyPresses()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                jogoMinhoca.OnKeyPress(key);
            }

            await Task.Delay(10);
        }
    }

    var monitorClique = MonitorKeyPresses();

    do
    {
        jogoMinhoca.MoveEValida();
        jogoMinhoca.Desenhar();
        await Task.Delay(tempoSalto);

    } while (!jogoMinhoca.fimJogo);

    // Allow time for user to weep before application exits.
    for (var i = 0; i < 3; i++)
    {
        Console.Clear();
        await Task.Delay(500);
        jogoMinhoca.Desenhar();
        await Task.Delay(500);
    }
    cts.Cancel();
    await monitorClique;

    Console.WriteLine($"SUA PONTUAÇÃO {MinhocaJogo._score}");
    Console.ReadLine();
}


enum Direcao
{
    Cima,
    Baixo,
    Esquerda,
    Direita
}

interface IRenderable
{
    void Desenhar();
}

readonly struct Posicao
{
    public Posicao(int topo, int esquerda)
    {
        Topo = topo;
        Esquerda = esquerda;
    }
    public int Topo { get; }
    public int Esquerda { get; }

    public Posicao RightBy(int n) => new Posicao(Topo, Esquerda + n);
    public Posicao DownBy(int n) => new Posicao(Topo + n, Esquerda);
}





