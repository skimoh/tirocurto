//***CODE BEHIND - BY RODOLFO.FONSECA***//

namespace CodeBehind.TiroCurto.Seguranca.Models
{
    public class ClienteVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string SiteKey { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
        public string ValorNaoSeguro { get; set; }
    }
}
