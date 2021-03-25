//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace CodeBehind.TiroCurto.Servico.Infrastructure
{
    public class CicloAlternativo
    {
        readonly Timer _timer;
        private string path = $"{Directory.GetCurrentDirectory()}\\Log.txt";
        public CicloAlternativo()
        {
            _timer = new Timer(60000) { AutoReset = true };//60s
            _timer.Elapsed += _rodar;
        }

        private void _rodar(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Passei aqui");

            File.AppendAllText(path, Environment.NewLine + $"Passei {DateTime.Now.ToString("ddMMyyyyHHmm")}");
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

}
