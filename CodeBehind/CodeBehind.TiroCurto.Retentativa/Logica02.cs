//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System.Net.Http.Headers;

namespace CodeBehind.TiroCurto.Retentativa
{
    public static class Logica02
    {
        public static Task<bool> EnviarArquivo()
        {
            try
            {                
                
                Convert.ToInt16("XXX");

                return Task.FromResult(true);

            }
            catch (Exception)
            {
                throw new DominioExcecao() { Codigo = "02" };
            }
        }
    }
}
