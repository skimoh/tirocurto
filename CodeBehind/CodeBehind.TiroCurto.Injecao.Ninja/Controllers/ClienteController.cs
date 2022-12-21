//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.Web.Http;

namespace CodeBehind.TiroCurto.Injecao.Ninja.Controllers
{
    public class ClienteController : ApiController
    {
        public readonly IClasseInjetada _camada;

        public ClienteController(IClasseInjetada camada)
        {
            _camada = camada;
        }
        
        public string Get()
        {
            return _camada.Metodo();
        }
    }
}
