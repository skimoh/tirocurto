//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Carro
{
    public static class Engine
    {
        public static void DesenharTextoTela(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        public static void DesenhaCaracterTela(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
    }
}
