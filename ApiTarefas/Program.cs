using ApiTarefas.Database;
using ApiTarefas.Services;
using ApiTarefas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adicionando serviços de banco de dados
builder.Services.AddDbContext<TarefasContext>(options =>
{
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(9,2,0)));
});

// Adicionando serviços de serviços
builder.Services.AddScoped<ITarefasServicos ,TarefasServico>();

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