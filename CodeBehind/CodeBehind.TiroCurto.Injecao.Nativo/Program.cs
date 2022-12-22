//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.TiroCurto.Injecao.Nativo;

var builder = WebApplication.CreateBuilder(args);

//AddTransient TODA VEZ que o controlador for inst�nciado, ser� gerada uma nova inst�ncia da classeinjetada
builder.Services.AddTransient<IClasseInjetada, ClasseInjetada>();

//AddScoped TODA VEZ que o controlador for inst�nciado, ser� mantido a inst�ncia da classeinjetada
//builder.Services.AddScoped<IClasseInjetada, ClasseInjetada>();

//AddSingleton sempre teremos as mesmas informa��es (Mesma inst�ncia) do objeto para todos os usu�rios da aplica��o
//builder.Services.AddSingleton<IClasseInjetada, ClasseInjetada>();

//https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0

var app = builder.Build();


app.MapGet("/api/Cliente", (IClasseInjetada classe) =>
{
    return Results.Ok(classe.Metodo());
});

app.Run();