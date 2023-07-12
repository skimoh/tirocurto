﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind.TiroCurto.Util
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\arquivo.pdf";
            var encontrou = HelperPDF.VerificaTexto(path, "genially");

            Console.WriteLine("O texto foi encontrado ? " + encontrou);

        }
    }
}
