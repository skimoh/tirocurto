//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace CodeBehind.TiroCurto.Servico.Infrastructure
{
    public class Ciclo : ServiceControl
    {
        private Timer _timer;
        private string path = $"{Directory.GetCurrentDirectory()}\\Log.txt";

        private async Task ExecuteAsync()
        {
            try
            {
                //previnindo execução encavalada
                _timer.Change(Timeout.Infinite, Timeout.Infinite);

                Console.WriteLine("Passei aqui");

                File.AppendAllText(path, Environment.NewLine + $"Passei {DateTime.Now.ToString("ddMMyyyyHHmm")}");
            }
            finally
            {
                _timer.Change(TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
            }
        }

        public bool Start(HostControl hostControl)
        {
            _timer = new Timer(callback: async c => await ExecuteAsync(),

            //State: Objeto que carrega informações que podem ser utilizadas      pelo método de callback (ExecuteAsync)

            state: null,

            //dueTime: Delay para inicializar o ExecuteAsync

            dueTime: TimeSpan.Zero,

            //Period: Frequência que o ExecuteAsync deverá ser executado

            period: TimeSpan.FromSeconds(60));

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
