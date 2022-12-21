//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Injecao.Nativo;

var builder = WebApplication.CreateBuilder(args);

//AddTransient TODA VEZ que o controlador for instânciado, será gerada uma nova instância da classeinjetada
builder.Services.AddTransient<IClasseInjetada, ClasseInjetada>();

//AddTransient TODA VEZ que o controlador for instânciado, será mantido a instância da classeinjetada
//builder.Services.AddScoped<IClasseInjetada, ClasseInjetada>();

//AddTransient sempre teremos as mesmas informações (Mesma instância) do objeto para todos os usuários da aplicação
//builder.Services.AddSingleton<IClasseInjetada, ClasseInjetada>();


var app = builder.Build();


app.MapGet("/api/Cliente", (IClasseInjetada classe) =>
{
    return Results.Ok(classe.Metodo());
});

app.Run();