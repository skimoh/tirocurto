//***CODE BEHIND - BY RODOLFO.FONSECA***//
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Text;

namespace CodeBehind.TiroCurto.Util
{
    public static class HelperPDF
    {
        public static bool VerificaTexto(string caminho, string texto)
        {
            StringBuilder sb = new();
            using (PdfReader arquivoPDF = new PdfReader(caminho))
            {
                for (int i = 1; i <= arquivoPDF.NumberOfPages; i++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(arquivoPDF, i));
                }
            }

            return sb.ToString().IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
