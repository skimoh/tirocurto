using System.Net.Http.Headers;

namespace CodeBehind.TiroCurto.Retentativa
{
    public static class Logica03
    {
        public static Cliente EnviarSMS(Cliente cli)
        {

            if (cli.Celular == "11988885555")
            {
                throw new DominioExcecao() { Codigo = "03" };
            }

            return cli;

        }
    }
}
