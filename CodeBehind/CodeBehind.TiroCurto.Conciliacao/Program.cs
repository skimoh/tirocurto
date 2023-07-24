using OfxSharpLib;

try
{
    //OFX Money 2000 em diante
    var parser = new OfxDocumentParser();
    var ofxDocument = parser.Import(new FileStream(@"c:\temp\arquivo.ofx", FileMode.Open));

    foreach (var x in ofxDocument.Transactions)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine($"Valor da Transação: R$ {x.Amount}");
        Console.WriteLine($"Operação: {x.TransType}");
        Console.WriteLine($"Data Operação: {x.Date}");
        Console.WriteLine($"Descrição: {x.Memo}");
        Console.WriteLine($"Código da transação: 123");// {x.TransactionId}");

    }
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
