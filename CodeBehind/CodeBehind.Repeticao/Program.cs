//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.Repeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            //ForSimples();

            //WhileSimples();

            //DoWhileSimples();

            //ForeachSimples();

            //ForeachComParada();

            //ForeachAvancando();

            //ForeachComIndex();

            //ForeachLambda();

            //ForeachParalelo();

            ///ForParalelo();

            ///LoopInfinito();

            Console.ReadKey();
        }

        private static void ForeachAvancando()
        {
            int[] vctos = { 1, 2, 3, 4, 5, 6 };
            foreach (var vcto in vctos)
            {
                Console.WriteLine($"FOREACH Passou aqui avançando {vcto}");
                continue;

                Console.WriteLine($"FOREACH Não passa aqui nunca {vcto}");
            }
        }

        private static void ForeachComParada()
        {
            int[] meses = { 1, 2, 3, 4, 5, 6 };
            foreach (var mes in meses)
            {
                Console.WriteLine($"FOREACH Passou aqui com interrupção {mes}");
                break;
            }
        }

        private static void LoopInfinito()
        {
            for (; ; )
                Console.WriteLine("FOR Passou aqui infinito");
        }

        private static void ForParalelo()
        {
            int[] dias = { 1, 2, 3, 4, 5, 6 };
            Parallel.For(0, dias.Length - 1,
                            index =>
                            {
                                Console.WriteLine($"FOR THREAD Passou aqui Interpolado {dias[index]}");
                            });
        }

        private static void ForeachParalelo()
        {
            int[] dias = { 1, 2, 3, 4, 5, 6 };
            Parallel.ForEach(dias, x => Console.WriteLine($"FOREACH THREAD Passou aqui Interpolado {x}"));
        }

        private static void ForeachLambda()
        {
            int[] dias = { 1, 2, 3, 4, 5, 6 };
            dias.ToList().ForEach(x => Console.WriteLine($"FOREACH LAMBDA Passou aqui Interpolado {x}"));
        }

        private static void ForeachComIndex()
        {
            int[] dias = { 10, 20, 30, 40, 50, 60 };
            foreach (var dia in dias.Select((value, index) => new { index, value }))
            {
                Console.WriteLine($"FOREACH Passou aqui Interpolado {dia.value} Index {dia.index}");
            }
        }

        private static void ForeachSimples()
        {
            int[] idades = { 10, 20, 30, 40, 50, 60 };
            foreach (var idade in idades)
            {
                Console.WriteLine($"FOREACH Passou aqui Interpolado {idade}");
            }
        }

        private static void DoWhileSimples()
        {
            int contador = 1;
            do
            {
                Console.WriteLine($"DO WHILE Passou aqui Interpolado {contador}");
                contador++;
            } while (contador <= 5);
        }

        private static void WhileSimples()
        {
            int contador = 5;
            while (contador <= 5)
            {
                Console.WriteLine($"WHILE Passou aqui Interpolado {contador}");
                contador++;
            }
        }

        private static void ForSimples()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"FOR Passou aqui Interpolado {i}");
                //Console.WriteLine(string.Format("Passou aqui StringFormat {0}", i));
            }
        }
    }
}
