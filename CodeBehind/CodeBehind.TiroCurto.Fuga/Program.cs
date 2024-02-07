//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Breakout;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("");
Console.WriteLine($"-----------------------------------------");
Console.WriteLine($"BEM VINDO AO JOGO BREAKOUT");
Console.WriteLine("");
Console.WriteLine($"UTILIZE AS SETAS <- -> PARA MOVER A PLATAFORMA");
Console.WriteLine($"-----------------------------------------");
Thread.Sleep(4000);



Console.WindowWidth = 50;
Console.BufferWidth = 50;

PingaBola.RemoverBarraLateral();
PingaBola.Iniciar();

new Thread(() =>
{
    while (true)
    {

        if (Console.KeyAvailable)
        {
            PingaBola.RemoverTijolo();
            
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            //direita
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                PingaBola.MovePlataformaDireita();
            }
            //esquerda
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                PingaBola.MovePlataformaEsquerda();
            }

            PingaBola.DesenharPlataforma();
        }
    }
}).Start();

PingaBola.CursorAtTheStart();

while (true)
{
    PingaBola.RemoveBola();
    
    PingaBola.MoverBolinha();

    PingaBola.DesenhaBola();

    Thread.Sleep(120);
}

