//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBehind.TiroCurto.AutoMapper
{
    [Table("Entidade")]
    public class Entidade
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public byte Idade { get; set; }

        public string Sexo { get; set; }
    }
}
