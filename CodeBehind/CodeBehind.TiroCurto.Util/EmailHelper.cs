using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System.Collections.Generic;
using MailKit.Net.Pop3;
using MailKit.Security;
using System;
using System.Threading.Tasks;
using System.Linq;
using MimeKit;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace CodeBehind.TiroCurto.Util
{
    /// <summary>
    /// GMAIL https://myaccount.google.com/apppasswords
    /// </summary>
    public static class EmailHelper
    {
        public static string _senha = "xx";


        private static int _portaIMAP = 993;
        private static int _portaPOP = 995;
        public static string _email = "codebehindbrasil@gmail.com";
        public static string _servidor = "pop.gmail.com";

        /// <summary>
        /// O protocolo POP sincroniza apenas a caixa de entrada, todas as outras pastas vão ser armazenadas dentro do servidor de e-mail.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<string>> GetUnreadMailsPop()
        {
            var retorno = new List<string>();

            using (var client = new Pop3Client())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect(_servidor, _portaPOP, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_email, _senha);

                // Verificar se a autenticação foi bem-sucedida
                if (client.IsAuthenticated)
                {
                    // Obter o número total de e-mails na caixa de entrada
                    int totalEmails = client.Count;
                    Console.WriteLine("Total de e-mails: " + totalEmails);

                    // Percorrer os e-mails e exibir algumas informações
                    for (int i = 0; i < totalEmails; i++)
                    {
                        var mensagem = client.GetMessage(i);
                        retorno.Add(mensagem.HtmlBody);
                    }
                }
                else
                {
                    Console.WriteLine("Falha na autenticação do cliente POP3.");
                }
                return retorno;
            }
        }

        /// <summary>
        /// O protocolo IMAP sincroniza os emails do seu servidor com o gerenciador de emails do seu dispositivos, ou seja, existirá uma cópia da sua mensagem no seu webmail e em seu gerenciador de email 
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<string>> GetUnreadMailsImap()
        {
            var retorno = new List<string>();

            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect(_servidor, _portaIMAP, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_email, _senha);

                var caixa = client.Inbox;

                if (client.IsAuthenticated)
                {
                    caixa.Open(FolderAccess.ReadWrite);

                    //somente os não lidos
                    var uids = client.Inbox.Search(SearchQuery.NotSeen);

                    foreach (var uid in uids)
                    {
                        var mensagem = client.Inbox.GetMessage(uid);

                        if (mensagem.Subject.StartsWith("CEMIG FATURA ONLINE")){
                            //buscar somente de um assunto especifico
                        }

                        //marcar como lido no servidor
                        caixa.SetFlags(uid, MessageFlags.Seen, true);

                        //baixar anexo
                        foreach (MimeEntity attachment in mensagem.Attachments)
                        {
                            var nomeAnexo = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                            var caminhoCompleto = @$"c:\temp\{nomeAnexo}";
                            using (var stream = File.Create(caminhoCompleto))
                            {
                                if (attachment is MimeKit.MessagePart)
                                {
                                    var rfc822 = (MimeKit.MessagePart)attachment;
                                    rfc822.Message.WriteTo(stream);
                                }
                                else
                                {
                                    var part = (MimeKit.MimePart)attachment;
                                    part.Content.DecodeTo(stream);
                                }                                
                            }
                        }

                        //encontrar link e baixar

                        string emailBody = mensagem.HtmlBody;
                        
                        var document = new HtmlDocument();
                        document.LoadHtml(emailBody);
                        
                        //Somente url com a palavra fatura no link
                        var linkNode = document.DocumentNode.Descendants("a").FirstOrDefault(x=>x.InnerText.Contains("xxxxx"));
                        if (linkNode != null)
                        {
                            string link = linkNode.GetAttributeValue("href", string.Empty);

                            using WebClient clientWeb = new WebClient();
                            var caminhoCompletoWeb = @$"c:\temp\{Guid.NewGuid()}.pdf";
                            clientWeb.DownloadFile(link, caminhoCompletoWeb);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum link encontrado no corpo do email.");
                        }
                        
                        retorno.Add(mensagem.HtmlBody);

                    }//fim each

                }
                else
                {
                    Console.WriteLine("Falha na autenticação do cliente POP3.");
                }

                return retorno;
            }
        }
    }
}
