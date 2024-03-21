using System.Runtime.InteropServices;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CancellationTokenSource cts = new();

var botClient = new TelegramBotClient("xxxx");

var opt = new ReceiverOptions()
{
    AllowedUpdates = new UpdateType[]
    {
        UpdateType.Message
    }
};

//Recebendo mensagens do bot
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: opt,
    cancellationToken: cts.Token
);

Thread.Sleep(6000);

//dados do bot
var me = await botClient.GetMeAsync();
Console.WriteLine($"Usuario {me.Id} nome {me.FirstName}.");


async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
{
    var id = update.Id;

    if (update.Message is not { } message)
        return;

    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Mensagem '{messageText}' Id do Chat {chatId}.");

}

Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}

cts.Cancel();
Console.ReadLine();