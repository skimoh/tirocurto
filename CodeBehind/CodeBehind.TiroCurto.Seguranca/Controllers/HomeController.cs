//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Seguranca.Core;
using CodeBehind.TiroCurto.Seguranca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace CodeBehind.TiroCurto.Seguranca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _http;
        public readonly GoogleCaptchaConfig _config;
        public readonly GoogleCaptchaService _service;

        public HomeController(ILogger<HomeController> logger,
            IHttpContextAccessor http,
            IOptions<GoogleCaptchaConfig> config,
            GoogleCaptchaService service)
        {
            _logger = logger;
            _http = http;
            _config = config.Value;
            _service = service;
        }

        public IActionResult Index()
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);
            _http.HttpContext.Response.Cookies.Append("CodeBehindSeguro", Criptografia.Encriptar("123"), option);

            return View();
        }

        public IActionResult SelecionarPorId(string token)
        {
            var id = Criptografia.Decriptar(token);

            _logger.LogInformation($"Id: {id} ");

            ViewBag.Sucesso = true;

            return View("Index");
        }

        public IActionResult SelecionarPorIdPuro(Guid id)
        {
            _logger.LogInformation($"Id: {id} ");


            //VALIDAR SE O ID CORRESPONDE AOS DADOS DE UM USUARIO LOGADO

            ViewBag.Sucesso = true;
            return View("Index");
        }

        public IActionResult TesteLimiteAcesso()
        {
            _logger.LogInformation($"Entrou");
            return Ok("Sucesso");
        }


        public ActionResult Cadastrar()
        {
            var vm = new ClienteVM();
            vm.SiteKey = _config.SiteKey;
            vm.ValorNaoSeguro = "CPF_CLIENTE";
            return View(vm);
        }

        /// <summary>
        /// ValidateAntiForgeryToken => É um método que gera e insere no HTML gerado na view um código para evitar que se falsifique o envio de dados para o servidor.
        /// Teste de Turing => Testa a capacidade de uma máquina exibir comportamento inteligente equivalente a um ser humano, ou indistinguível deste.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ClienteVM vm)
        {
            var valido = _service.Verificar(vm.Token).GetAwaiter().GetResult();
            if (!valido)
            {
                vm.Mensagem = "Captha Inválido";
            }
            else
            {
                vm.Mensagem = "Sucesso";
            }
            vm.SiteKey = _config.SiteKey;
            return View(vm);
        }

        //SEMPRE MANTER AS BIBLIOTECAS ATUALIZADAS
        //CUIDADO COM AS SENHAS MANJADAS 123456, DATA NASCIMENTO ETC

    }
}