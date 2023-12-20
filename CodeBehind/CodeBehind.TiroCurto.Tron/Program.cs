using CodeBehind.TiroCurto.Tron;

Engine.DefinindoParametro();
Engine.IniciandoOrientacao();

Engine.isUsed = new bool[Console.WindowWidth, Console.WindowHeight];


while (true)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        Engine.MudarDirecao(key);
    }


    Engine.MovePlayers();


    bool P1Perdeu = Engine.DoesPlayerLose(Engine._P1Linha, Engine._P1Coluna);
    bool P2Perdeu = Engine.DoesPlayerLose(Engine._P2Linha, Engine._P2Coluna);


    if (P1Perdeu && P2Perdeu)
    {
        Engine._P1Score++;
        Engine._P2Score++;
        Console.WriteLine();
        Console.WriteLine("GAME OVER");
        Console.WriteLine("Empate!!!");        
    }

    if (P1Perdeu)
    {
        Engine._P2Score++;
        Console.WriteLine();
        Console.WriteLine("GAME OVER");
        Console.WriteLine("P2 Ganhou!!!");
        
    }

    if (P2Perdeu)
    {
        Engine._P1Score++;
        Console.WriteLine();
        Console.WriteLine("GAME OVER");
        Console.WriteLine("P1 Ganhou!!!");
        
    }

    Console.WriteLine("P1 {0} - {1} P2", Engine._P1Score, Engine._P2Score);
    Engine.ReiniciarJogo();

    Engine.isUsed[Engine._P1Coluna, Engine._P1Linha] = true;
    Engine.isUsed[Engine._P2Coluna, Engine._P2Linha] = true;


    Engine.DesenharTela(Engine._P1Coluna, Engine._P1Linha, '*', ConsoleColor.Yellow);
    Engine.DesenharTela(Engine._P2Coluna, Engine._P2Linha, '*', ConsoleColor.Cyan);


    Thread.Sleep(100);
}