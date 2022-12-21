//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Injecao.Nativo
{
    public interface IClasseInjetada
    {
        string Metodo();
    }


    public class ClasseInjetada : IClasseInjetada
    {
        public string Metodo()
        {
            return "INJEÇÃO DE DEPENDENCIA COM NET 6 NATIVO";
        }
    }
}
