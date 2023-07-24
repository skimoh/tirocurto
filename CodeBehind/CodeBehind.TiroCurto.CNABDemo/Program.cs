//***CODE BEHIND - BY RODOLFO.FONSECA***//

using CodeBehind.TiroCurto.CNABDemo;
using System.Text;

//LerRemessa();

GerarRemessa();

#region Metodos

void LerRemessa()
{
    var arquivo = File.ReadAllText(@"c:\temp\retorno.txt");
    var arrArquivo = arquivo.Split(Environment.NewLine);

    var t = PreencherTemplate();

    var informacaoArquivo = string.Empty;
    var totalItens = 0;
    var clientes = new List<Cliente>();
    var certificado = string.Empty;

    foreach (var item in arrArquivo)
    {
        switch (item[0].ToString())
        {
            case "0": //Registro Header de Arquivo
                var colunasH = t.Where(x => x.Tipo == 0).Select(x => x);
                foreach (var coluna in colunasH.OrderBy(x => x.Ordem))
                {
                    if (coluna.Nome == "Banco")
                        informacaoArquivo = $"Arquivo do Banco {DevolveValor(item, coluna.Inicio, coluna.Total, coluna.ValorPadrao)}";
                }
                break;

            case "1"://Registro Header de Lote
                var colunasL = t.Where(x => x.Tipo == 1).Select(x => x);
                foreach (var coluna in colunasL.OrderBy(x => x.Ordem))
                {
                    if (coluna.Nome == "Total")
                        totalItens = Convert.ToInt32(DevolveValor(item, coluna.Inicio, coluna.Total, coluna.ValorPadrao));
                }
                break;

            case "3": //Registros de Detalhe
                var colunasD = t.Where(x => x.Tipo == 3).Select(x => x);
                var rg = string.Empty;
                var idade = 0;
                var nome = string.Empty;

                foreach (var coluna in colunasD.OrderBy(x => x.Ordem))
                {
                    if (coluna.Nome == "RG")
                        rg = DevolveValor(item, coluna.Inicio, coluna.Fim, coluna.ValorPadrao);

                    if (coluna.Nome == "Idade")
                        idade = Convert.ToInt32(DevolveValor(item, coluna.Inicio, coluna.Total, coluna.ValorPadrao));

                    if (coluna.Nome == "Nome")
                        nome = DevolveValor(item, coluna.Inicio, coluna.Total, coluna.ValorPadrao);

                }
                clientes.Add(new Cliente() { Idade = idade, RG = rg, Nome = nome });
                break;

            case "5"://Registro Trailerde Lote
                     //descartar
                break;

            case "9"://Registro Trailer de Arquivo
                var colunasT = t.Where(x => x.Tipo == 9).Select(x => x);
                foreach (var coluna in colunasT.OrderBy(x => x.Ordem))
                {
                    if (coluna.Nome == "Certificado")
                        certificado = DevolveValor(item, coluna.Inicio, coluna.Total, coluna.ValorPadrao);
                }
                break;
        }//fim linha
    }

    Console.WriteLine(informacaoArquivo);
    Console.WriteLine($"Total de clientes capturados:{clientes.Count()}");
    Console.WriteLine(certificado);
    Console.ReadLine();
}

List<InfoLinha> PreencherTemplate()
{
    //obter do banco
    var list = new List<InfoLinha>
    {
        //Registro Header de Arquivo
        new InfoLinha() { Tipo = 0, Inicio = 1, Fim = 5, Total = 4, Formato = "Numero", Nome = "Banco", Ordem = 1, ValorPadrao = "" },
        new InfoLinha() { Tipo = 0, Inicio = 5, Fim = 11, Total = 5, Formato = "Numero", Nome = "NSU", Ordem = 2, ValorPadrao = "" },
        //Registro Header de Lote
        new InfoLinha() { Tipo = 1, Inicio = 1, Fim = 3, Total = 2, Formato = "Numero", Nome = "Total", Ordem = 1, ValorPadrao = "" },
        //Registros de Detalhe
        new InfoLinha() { Tipo = 3, Inicio = 1, Fim = 5, Total = 4, Formato = "Numero", Nome = "RG", Ordem = 1, ValorPadrao = "" },
        new InfoLinha() { Tipo = 3, Inicio = 5, Fim = 20, Total = 14, Formato = "Texto", Nome = "Nome", Ordem = 2, ValorPadrao = "" },
        new InfoLinha() { Tipo = 3, Inicio = 19, Fim = 23, Total = 2, Formato = "Numero", Nome = "Idade", Ordem = 3, ValorPadrao = "" },       
        //Registro Trailerde Lote
        new InfoLinha() { Tipo = 5, Inicio = 1, Fim = 3, Total = 2, Formato = "Numero", Nome = "Total", Ordem = 1, ValorPadrao = "" },
        //Registro Trailer de Arquivo
        new InfoLinha() { Tipo = 9, Inicio = 1, Fim = 20, Total = 19, Formato = "Numero", Nome = "Certificado", Ordem = 1, ValorPadrao = "" },
    };

    return list;

}

string DevolveValor(string texto, int inicio, int total, string padrao)
{

    var valor = texto.Substring(inicio, total);
    if (string.IsNullOrEmpty(valor))
        valor = padrao;

    return valor;
}

string PreencheValor(string valor, int total, string padrao, string formato)
{
    if (string.IsNullOrEmpty(valor))
        return padrao;

    if (formato == "Numero")
        valor = valor.PadLeft(total, '0');

    if (formato == "Texto")
        valor = valor.PadRight(total, ' ');

    return valor;
}


void GerarRemessa()
{

    var listaCliente = new List<Cliente>
    {
        new Cliente()
        {
            Idade = 18,
            Nome = "Jao",
            RG = "1231"
        },
        new Cliente()
        {
            Idade = 68,
            Nome = "Antonio",
            RG = "7894"
        }
    };

    StringBuilder sb = new StringBuilder();
    var t = PreencherTemplate();

    sb.Append("0"); //Registro Header de Arquivo
    foreach (var item in t.Where(x => x.Tipo == 0).OrderBy(x => x.Ordem))
    {
        //valor passado é dinamico
        sb.Append(PreencheValor("6569", item.Total, item.ValorPadrao, item.Formato));
    }

    sb.Append(Environment.NewLine);
    sb.Append("1"); //Registro Header de Lote
    foreach (var item in t.Where(x => x.Tipo == 1).OrderBy(x => x.Ordem))
    {
        //total de registros
        sb.Append(PreencheValor("2", item.Total, item.ValorPadrao, item.Formato));
    }

    sb.Append(Environment.NewLine);
    sb.Append("3"); //Registros de Detalhe
    foreach (var cliente in listaCliente)
    {        
        foreach (var item in t.Where(x => x.Tipo == 3).OrderBy(x => x.Ordem))
        {
            if (item.Nome == "RG")
                sb.Append(PreencheValor(cliente.RG, item.Total, item.ValorPadrao, item.Formato));

            if (item.Nome == "Nome")
                sb.Append(PreencheValor(cliente.Nome, item.Total, item.ValorPadrao, item.Formato));

            if (item.Nome == "Idade")
                sb.Append(PreencheValor(cliente.Idade.ToString(), item.Total, item.ValorPadrao, item.Formato));
        }
        sb.Append(Environment.NewLine);
        sb.Append("3"); //Registros de Detalhe
    }

    sb.Append(Environment.NewLine);
    sb.Append("5");//Registro Trailerde Lote
    foreach (var item in t.Where(x => x.Tipo == 5).OrderBy(x => x.Ordem))
    {
        //total de registros
        sb.Append(PreencheValor("2", item.Total, item.ValorPadrao, item.Formato));
    }

    sb.Append(Environment.NewLine);
    sb.Append("9");
    foreach (var item in t.Where(x => x.Tipo == 9).OrderBy(x => x.Ordem))
    {
        //certificado
        sb.Append(PreencheValor("8789767498787879658", item.Total, item.ValorPadrao, item.Formato));
    }

    File.WriteAllText(@"c:\temp\remessa.txt", sb.ToString());
}
#endregion