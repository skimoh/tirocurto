using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind.TiroCurto.ComparandoLista
{
    public static class ListaHelper
    {
        public static List<int> PreencherLista()
        {
            var lista = new List<int>();
            for (int i = 1; i < 6; i++)
            {
                lista.Add(new Random().Next(1, 20));
            }
            return lista;
        }

        public static List<Objeto> PreencherListaObjeto()
        {
            var lista = new List<Objeto>();
            for (int i = 1; i < 6; i++)
            {
                var idgerado = new Random().Next(1, 20);
                lista.Add(new Objeto() { Id = idgerado, Nome = $"NOME{idgerado}" });
            }
            return lista;
        }

        public static List<int> CompararManualEsquerda(List<int> esquerda, List<int> direita)
        {
            var listaSaida = new List<int>();
            foreach (var item in esquerda)
            {
                if (!direita.Contains(item))
                {
                    listaSaida.Add(item);
                }
            }

            return listaSaida;
        }

        public static List<int> CompararManualDireita(List<int> esquerda, List<int> direita)
        {
            var listaSaida = new List<int>();
            foreach (var item in direita)
            {
                if (!esquerda.Contains(item))
                {
                    listaSaida.Add(item);
                }
            }

            return listaSaida;
        }


        public static List<int> CompararEsquerda(List<int> esquerda, List<int> direita)
        {
            return esquerda.Except(direita).ToList();
        }

        public static List<int> CompararDireita(List<int> esquerda, List<int> direita)
        {
            return direita.Except(esquerda).ToList();
        }


        public static List<string> ComparaEsquerda<T>(IEnumerable<T> left, IEnumerable<T> right)
        {
            var leftCompare = new List<string>();
            var rightCompare = new List<string>();


            foreach (var item in left) { leftCompare.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item)); }
            foreach (var item in right) { rightCompare.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item)); }

            var resultDifference = leftCompare.Except(rightCompare, StringComparer.OrdinalIgnoreCase).ToList();

            return resultDifference;
        }

        public static List<string> ComparaDireita<T>(IEnumerable<T> left, IEnumerable<T> right)
        {
            var leftCompare = new List<string>();
            var rightCompare = new List<string>();


            foreach (var item in left) { leftCompare.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item)); }
            foreach (var item in right) { rightCompare.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item)); }

            var resultDifference = rightCompare.Except(leftCompare, StringComparer.OrdinalIgnoreCase).ToList();

            return resultDifference;
        }

        public static string Transformar(this List<int> lista)
        {
            return string.Join("-", lista);
        }

        public static bool CompararManual(List<Objeto> listaA, List<Objeto> listaB)
        {
            CompareLogic compareLogic = new CompareLogic();

            ComparisonResult result = compareLogic.Compare(listaA, listaB);

            return result.AreEqual;
        }
    }

    public class Objeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
