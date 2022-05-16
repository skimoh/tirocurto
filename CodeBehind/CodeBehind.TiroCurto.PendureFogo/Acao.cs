namespace CodeBehind.TiroCurto.PendureFogo
{
    public static class Acao
    {
        public static void RegistrarMensagem(string tipo)
        {
            System.IO.File.AppendAllText(@"C:\temp\loghang.txt", Environment.NewLine + $"EXECUTOU {tipo} {DateTime.Now}");
        }
    }
}
