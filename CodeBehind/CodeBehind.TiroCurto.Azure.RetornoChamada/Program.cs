using CodeBehind.TiroCurto.Azure.RetornoChamada;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWebhookService, WebhookService>();

var sv = builder.Services;

sv.AddLogging();

var app = builder.Build();

app.MapPost("/webhook/atualizacao", async (HttpContext ctx, ILogger<Program> logger, IWebhookService wh) =>
{
    if (!ctx.Request.Headers.ContainsKey("Authorization"))
    {
        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized; return;
    }

    var apiKey = ctx.Request.Headers["Authorization"];
    if (apiKey != "TESTE")
    {
        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized; return;
    }

    var requestBody = await ctx.Request.ReadFromJsonAsync<WebHookPayLoad>();

    if (requestBody == null)
    {
        ctx.Response.StatusCode = StatusCodes.Status400BadRequest; return;
    }

    logger.LogInformation($"Received Header: {requestBody?.Header} Body {requestBody?.Body}");
    ctx.Response.StatusCode = StatusCodes.Status200OK;

    await wh.Handler(requestBody.Body);
});

app.Run();

public record WebHookPayLoad(string Header, string Body);