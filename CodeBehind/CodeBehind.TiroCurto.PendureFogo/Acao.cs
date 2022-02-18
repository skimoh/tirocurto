namespace CodeBehind.TiroCurto.PendureFogo
{
    public static class Acao
    {
        public static void RegistrarMensagem(string tipo)
        {
            System.IO.File.AppendAllText(@"C:\temp\log.txt", $"EXECUTOU {tipo} {DateTime.Now}");
        }
    }
}
