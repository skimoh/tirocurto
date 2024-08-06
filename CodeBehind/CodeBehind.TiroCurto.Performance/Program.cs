using CodeBehind.TiroCurto.Performance;
using System.Diagnostics;

Dictionary<string, string> dic = new Dictionary<string, string>();

for (int i = 0; i < 5000000; i++)
{
    var rg = new Random().Next(11111111, 99999999);
    dic.Add($"FULANO {i}", $"RG {rg}");
}

try
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    //protobuf
    //Protocol Buffers é um método de serialização de dados estruturados.
    var resultado3 = ProtoSerialize.Serialize<Dictionary<string, string>>(dic);

    stopwatch.Stop();

    Console.WriteLine($"Tempo passado protobuf: {stopwatch.Elapsed}");

    stopwatch.Restart();
    //json
    //O formato JSON (JavaScript Object Notation) é, como o nome sugere, uma forma de notação de objetos JavaScript, de modo que eles possam ser representados de uma forma comum a diversas linguagens.
    var resultado2 = Newtonsoft.Json.JsonConvert.SerializeObject(dic);

    stopwatch.Stop();

    Console.WriteLine($"Tempo passado json: {stopwatch.Elapsed}");

    stopwatch.Restart();
    //xml
    //A Extensible Markup Language (XML) permite definir e armazenar dados de maneira compartilhável.
    using (var writer = new StringWriter())
    {
        XMLSerialize.Serialize(writer, dic);
        var resultado1 = writer.ToString();
    }
    stopwatch.Stop();

    Console.WriteLine($"Tempo passado xml: {stopwatch.Elapsed}");



    Console.ReadKey();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    throw;
}