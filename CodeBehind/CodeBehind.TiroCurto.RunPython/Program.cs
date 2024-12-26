using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        //ExecutarViaProcess();
        //ExecutarViaLib();
        ExecutarViaLibFile();
    }

    private static void ExecutarViaProcess()
    {
        // Defina as variáveis que você quer enviar para o Python
        string var1 = "10";
        string var2 = "20";

        // Configura o processo para executar o Python
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "python",
            Arguments = $"C:\\pyteste\\main.py {var1} {var2}", // Passa argumentos ao script Python
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Executa o processo
        Process process = Process.Start(psi);

        // Lê a saída do Python
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine($"Saída do Python: {output}");
    }

    private static void ExecutarViaLib()
    {
        // Cria o engine do IronPython
        ScriptEngine engine = Python.CreateEngine();

        // Cria um dicionário para compartilhar variáveis entre C# e Python
        ScriptScope scope = engine.CreateScope();
        scope.SetVariable("var1", 10);
        scope.SetVariable("var2", 20);

        // Código Python como string
        string pythonCode = @"
result = var1 + var2
";

        // Executa o código Python
        engine.Execute(pythonCode, scope);

        // Lê a variável result do Python
        int result = scope.GetVariable<int>("result");

        Console.WriteLine($"Resultado obtido do Python: {result}");

    }

    private static void ExecutarViaLibFile()
    {
        // Cria o engine do IronPython
        ScriptEngine engine = Python.CreateEngine();

        // Define os argumentos para o script Python
        string[] pythonArgs = new string[] { "c:\\pyteste\\main.py", "10", "20" };

        // Define os argumentos no ambiente Python
        engine.GetSysModule().SetVariable("argv", pythonArgs);

        // Caminho para o script Python
        string scriptPath = "c:\\pyteste\\main.py";

        // Executa o script Python
        ScriptScope scope = engine.ExecuteFile(scriptPath);

        // Opcional: Pega uma variável do script Python
        if (scope.ContainsVariable("result"))
        {
            var result = scope.GetVariable("result");
            Console.WriteLine($"Resultado do script Python: {result}");
        }
    }

}