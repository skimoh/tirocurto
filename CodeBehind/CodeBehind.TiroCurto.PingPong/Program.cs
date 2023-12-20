
using CodeBehind.TiroCurto.PingPong;

Engine.RemoverBarraLateral();

Engine.IniciandoPosicao();

while (true)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            Engine.MoverPraCima();
        }

        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            Engine.MoverPraBaixo();
        }
    }

    Engine.SecondPlayerAIMove();
    Engine.MoverBola();
    
    Console.Clear();

    Engine.DesenharP1();
    Engine.DesenharP2();
    Engine.DesenharBola();
    Engine.DesenhaResultado();

    Thread.Sleep(60);
}
