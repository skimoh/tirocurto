//***CODE BEHIND - BY RODOLFO.FONSECA***//
using AutoMapper;
using System;

namespace CodeBehind.TiroCurto.AutoMapper
{
    /// <summary>
    /// AUTOMAPPER mapeamento entre dois objetos
    /// </summary>
    class Program
    {
        private static IMapper _mapper;
        static void Main(string[] args)
        {
            Console.WriteLine("codeBehind - Mapeamento de objetos");

            var mapper = new MapperConfiguration(p => p.CreateMap<Entidade, EntidadeDto>().ReverseMap());
            _mapper = mapper.CreateMapper();

            var dto = new EntidadeDto()
            {
                Id = 1,
                Nome = "Fulano",
                SobreNome = "Silva",
                Idade = 18,
                Sexo = "M"
            };

            var entidade1 = MetodoTradicional(dto);

            var entidade2 = MetodoAutoMapper(dto);

            Console.ReadKey();
        }

        private static Entidade MetodoTradicional(EntidadeDto dto)
        {
            return new Entidade
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Idade = dto.Idade,
                Sexo = dto.Sexo,
                SobreNome = dto.SobreNome
            };
        }

        private static Entidade MetodoAutoMapper(EntidadeDto dto)
        {
            return _mapper.Map<Entidade>(dto);
        }
    }
}
