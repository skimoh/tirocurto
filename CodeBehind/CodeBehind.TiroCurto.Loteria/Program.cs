using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBehind.Loteria
{
    class Program
    {
        static void Main(string[] args)
        {
            MegaSena();
           // LotoFacil();

            Console.WriteLine("Fim");
            Console.ReadKey();
        }

        private static void MegaSena()
        {
            var book = new LinqToExcel.ExcelQueryFactory(@"c:\temp\Mega Sena.xlsx");

            var query =
                from row in book.Worksheet("MEGA SENA")
                let item = new
                {
                    Concurso = row["Concurso"].Cast<int>(),
                    Local = row["Cidade / UF"].Cast<string>(),
                    D1 = row["Bola1"].Cast<int>(),
                    D2 = row["Bola2"].Cast<int>(),
                    D3 = row["Bola3"].Cast<int>(),
                    D4 = row["Bola4"].Cast<int>(),
                    D5 = row["Bola5"].Cast<int>(),
                    D6 = row["Bola6"].Cast<int>()
                }
                where row["Bola1"].Cast<int>() != 0
                select item;


            List<int> todosNumeros =
            [
                .. query.Select(x => x.D1).ToArray(),
                .. query.Select(x => x.D2).ToArray(),
                .. query.Select(x => x.D3).ToArray(),
                .. query.Select(x => x.D4).ToArray(),
                .. query.Select(x => x.D5).ToArray(),
                .. query.Select(x => x.D6).ToArray(),
            ];

            var queryGrupo = todosNumeros
                .GroupBy(x => x)
                .Select(g => new { Numero = g.Key, Quantidade = g.Count() }).ToList();

            var ultimo = query.Select(x => x.Concurso).ToList().OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"MEGA SENA Total de Resultados {query.Count()}");
            Console.WriteLine("");
            Console.WriteLine($"MEGA SENA Ultimo Consurso da Planilha {ultimo}");
            Console.WriteLine("");

            foreach (var item in queryGrupo.OrderByDescending(x => x.Quantidade))
            {
                Console.WriteLine($"Numero {item.Numero} - Repeticoes {item.Quantidade}");
            }

            Console.WriteLine("");
        }

        private static void LotoFacil()
        {
            var book = new LinqToExcel.ExcelQueryFactory(@"c:\temp\loto.xlsx");

            Console.WriteLine($"Step Query");

            var query =
                from row in book.Worksheet("loto")
                let item = new
                {
                    Concurso = row["Concurso"].Cast<int>(),                    
                    D1 = row["Bola1"].Cast<int>(),
                    D2 = row["Bola2"].Cast<int>(),
                    D3 = row["Bola3"].Cast<int>(),
                    D4 = row["Bola4"].Cast<int>(),
                    D5 = row["Bola5"].Cast<int>(),
                    D6 = row["Bola6"].Cast<int>(),
                    D7 = row["Bola7"].Cast<int>(),
                    D8 = row["Bola8"].Cast<int>(),
                    D9 = row["Bola9"].Cast<int>(),
                    D10 = row["Bola10"].Cast<int>(),
                    D11 = row["Bola11"].Cast<int>(),
                    D12 = row["Bola12"].Cast<int>(),
                    D13 = row["Bola13"].Cast<int>(),
                    D14 = row["Bola14"].Cast<int>(),
                    D25 = row["Bola15"].Cast<int>()                    
                }
                where row["Bola1"].Cast<int>() != 0
                    && row["Bola1"].Cast<int>() <= 25
                    && row["Bola2"].Cast<int>() <= 25
                    && row["Bola3"].Cast<int>() <= 25
                    && row["Bola4"].Cast<int>() <= 25
                    && row["Bola5"].Cast<int>() <= 25
                    && row["Bola6"].Cast<int>() <= 25
                    && row["Bola7"].Cast<int>() <= 25
                    && row["Bola8"].Cast<int>() <= 25
                    && row["Bola9"].Cast<int>() <= 25
                    && row["Bola10"].Cast<int>() <= 25
                    && row["Bola11"].Cast<int>() <= 25
                    && row["Bola12"].Cast<int>() <= 25
                    && row["Bola13"].Cast<int>() <= 25
                    && row["Bola14"].Cast<int>() <= 25
                    && row["Bola15"].Cast<int>() <= 25
                select item;

            Console.WriteLine($"Step Unificar");

            List<int> todosNumeros = new List<int>();
            todosNumeros.AddRange(query.Select(x => x.D1).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D2).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D3).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D4).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D5).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D6).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D7).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D8).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D9).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D10).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D11).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D12).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D13).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D14).ToArray());
            todosNumeros.AddRange(query.Select(x => x.D25).ToArray());            

            var queryGrupo = todosNumeros
                .GroupBy(x => x)
                .Select(g => new { Numero = g.Key, Quantidade = g.Count() }).ToList();

            var ultimo = query.Select(x => x.Concurso).ToList().OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"LOTOFACIL Total de Resultados {query.Count()}");
            Console.WriteLine("");
            Console.WriteLine($"LOTOFACIL Ultimo Consurso da Planilha {ultimo}");
            Console.WriteLine("");

            foreach (var item in queryGrupo.OrderByDescending(x => x.Quantidade))
            {
                Console.WriteLine($"Numero {item.Numero} - Repeticoes {item.Quantidade}");
            }

            Console.WriteLine("");
        }
    }
}
