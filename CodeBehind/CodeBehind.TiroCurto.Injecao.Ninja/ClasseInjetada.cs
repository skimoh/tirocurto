namespace CodeBehind.TiroCurto.Injecao.Ninja.Controllers
{
    public interface IClasseInjetada
    {
        string Metodo();
    }


    public class ClasseInjetada : IClasseInjetada
    {
        public string Metodo()
        {
            return "INJECAO DE DEPENDENCIA COM NINJECT";
        }
    }
}
