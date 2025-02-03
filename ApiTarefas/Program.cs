var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços de controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers(); // Isso permite que os Controllers sejam mapeados

app.Run();