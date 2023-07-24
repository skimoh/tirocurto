//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;

namespace CodeBehind.TiroCurto.Util
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\arquivo.pdf";
            var encontrou = HelperPDF.VerificaTexto(path, "genially");

            Console.WriteLine("O texto foi encontrado ? " + encontrou);


            //var txt2 = EmailHelper.GetUnreadMailsImap();
        }
    }
}
