//***CODE BEHIND - BY RODOLFO.FONSECA***//
/*
 
"Injeção de Dependência é um é um padrão de projeto usado para evitar o 
alto nível de acoplamento de código dentro de uma aplicação. Sistemas 
com baixo acoplamento de código são melhores pelos seguintes motivos: 
Aumento na facilidade de manutenção/implementação de novas funcionalidades e 
também habilita a utilização de mocks para realizar unit testes."
 
 https://medium.com/@eduardolanfredi/inje%C3%A7%C3%A3o-de-depend%C3%AAncia-ff0372a1672

" Injeção de Dependência é apenas uma forma para resolvermos a Inversão de Controle."

https://www.devmedia.com.br/inversao-de-controle-x-injecao-de-dependencia/18763
 */
namespace CodeBehind.TiroCurto.Injecao.Estrutura
{
    public interface IClasseInjetada
    {
        string Metodo();
    }


    public class ClasseInjetada : IClasseInjetada
    {
        public string Metodo()
        {
            return "INJEÇÃO DE DEPENDENCIA COM STRUCTUREMAP";
        }
    }
}
