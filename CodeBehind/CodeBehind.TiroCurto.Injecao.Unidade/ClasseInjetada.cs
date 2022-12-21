namespace CodeBehind.TiroCurto.Injecao.Unidade
{
    public interface IClasseInjetada
    {
        string Metodo();
    }


    public class ClasseInjetada : IClasseInjetada
    {
        public string Metodo()
        {
            return "INJEÇÃO DE DEPENDENCIA COM UNITY";
        }
    }
}
