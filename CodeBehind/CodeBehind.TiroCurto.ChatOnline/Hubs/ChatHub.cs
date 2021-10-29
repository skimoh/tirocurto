//***CODE BEHIND - BY RODOLFO.FONSECA***//

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId() => Context.ConnectionId;

        public async Task SendMessage(string usuarioLogado, string mensagem, string usuarioDestino, string connectionId)
        {
            //gravar na base de dados nosql
            await Clients.All.SendAsync("ReceiveMessage", usuarioLogado, mensagem, usuarioDestino, connectionId);
        }
    }
}