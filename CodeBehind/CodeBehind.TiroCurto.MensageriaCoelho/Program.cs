using System;

namespace CodeBehind.MensageriaCoelho
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var msgEnviar = new ObjetoPersonalisado { Id = Guid.NewGuid(), Mensagem = "Ola" + new Random().Next(1, 8).ToString() };

                new Publicador().Publicar(msgEnviar);

                new Receptor().Consumir();

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class ObjetoPersonalisado
    {
        public Guid Id { get; set; }

        public string Mensagem { get; set; }
    }
}
