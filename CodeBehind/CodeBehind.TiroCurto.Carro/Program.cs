//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Carro;

double velocidade = 100.0;
double aceleracao = 0.5;

int larguraTela = 5;
int contadorVida = 5;

Console.BufferHeight = Console.WindowHeight = 20;
Console.BufferWidth = Console.WindowWidth = 30;

Objeto carro = new Objeto
{
    horizontal = 2,
    vertical = Console.WindowHeight - 1,
    icone = '@',
    cor = ConsoleColor.Yellow
};

Random rd = new Random();
List<Objeto> listaObjetos = new List<Objeto>();

while (true)
{
    velocidade += aceleracao;
    if (velocidade > 400)
    {
        velocidade = 400;
    }

    //cria objetos aleatórios no cenário
    bool morto = false;
    {
        int escolha = rd.Next(0, 100);
        if (escolha < 10)
        {
            //adiciona vida
            listaObjetos.Add(new Objeto
            {
                cor = ConsoleColor.Yellow,
                icone = 'Ö',
                horizontal = rd.Next(0, larguraTela),
                vertical = 0
            });
        }
        else if (escolha < 20)
        {
            //adiciona velocidade
            listaObjetos.Add(new Objeto
            {
                cor = ConsoleColor.Cyan,
                icone = '¥',
                horizontal = rd.Next(0, larguraTela),
                vertical = 0
            });
        }
        else
        {
            //adiciona obstaculo
            listaObjetos.Add(new Objeto
            {
                cor = ConsoleColor.Green,
                horizontal = rd.Next(0, larguraTela),
                vertical = 0,
                icone = '#'
            });
        }
    }

    while (Console.KeyAvailable)
    {
        ConsoleKeyInfo clique = Console.ReadKey(true);
        
        //esquerda
        if (clique.Key == ConsoleKey.LeftArrow)
        {
            if (carro.horizontal - 1 >= 0)
            {
                carro.horizontal = carro.horizontal - 1;
            }
        }//direita
        else if (clique.Key == ConsoleKey.RightArrow)
        {
            if (carro.horizontal + 1 < larguraTela)
            {
                carro.horizontal = carro.horizontal + 1;
            }
        }
    }//fim while infinito

    List<Objeto> newList = new List<Objeto>();
    for (int i = 0; i < listaObjetos.Count; i++)
    {
        Objeto oldCar = listaObjetos[i];
        Objeto newObject = new Objeto
        {
            horizontal = oldCar.horizontal,
            vertical = oldCar.vertical + 1,
            icone = oldCar.icone,
            cor = oldCar.cor
        };

        //reduz velocidade
        if (newObject.icone == '¥' && newObject.vertical == carro.vertical && newObject.horizontal == carro.horizontal)
        {
            velocidade -= 20;
        }

        //soma vida
        if (newObject.icone == 'Ö' && newObject.vertical == carro.vertical && newObject.horizontal == carro.horizontal)
        {
            contadorVida++;
        }

        //bateu no obstaculo
        if (newObject.icone == '#' && newObject.vertical == carro.vertical && newObject.horizontal == carro.horizontal)
        {
            contadorVida--;
            morto = true;
            velocidade += 50;

            if (velocidade > 400)
            {
                velocidade = 400;
            }

            if (contadorVida <= 0)
            {
                Engine.DesenharTextoTela(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                Engine.DesenharTextoTela(8, 12, "Pressione [enter] para sair", ConsoleColor.Red);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        if (newObject.vertical < Console.WindowHeight)
        {
            newList.Add(newObject);
        }
    }

    listaObjetos = newList;
    Console.Clear();

    if (morto)
    {
        listaObjetos.Clear();
        Engine.DesenhaCaracterTela(carro.horizontal, carro.vertical, 'X', ConsoleColor.Red);
    }
    else
    {
        Engine.DesenhaCaracterTela(carro.horizontal, carro.vertical, carro.icone, carro.cor);
    }

    foreach (Objeto car in listaObjetos)
    {
        Engine.DesenhaCaracterTela(car.horizontal, car.vertical, car.icone, car.cor);
    }

    
    Engine.DesenharTextoTela(8, 4, "Vidas: " + contadorVida, ConsoleColor.Yellow);
    Engine.DesenharTextoTela(8, 5, "Velocidade: " + velocidade, ConsoleColor.Cyan);
    Engine.DesenharTextoTela(8, 6, "Aceleração: " + aceleracao, ConsoleColor.White);

    //Console.Beep();
    Thread.Sleep((int)(600 - velocidade));
}

struct Objeto
{
    public int horizontal;
    public int vertical;
    public char icone;
    public ConsoleColor cor;
}




  
        
