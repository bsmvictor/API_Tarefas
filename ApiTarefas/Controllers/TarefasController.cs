using ApiTarefas.Database;
using ApiTarefas.Models;
using ApiTarefas.ModelVielws;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers; 

[ApiController] // Define que a classe é um Controller
[Route("tarefas")] // Define a rota do Controller

// HomeController herda de ControllerBase para ter acesso a métodos de resposta
public class TarefasController : ControllerBase
{
    public TarefasController(TarefasContext database)
    {
        _database = database;
    }

    private TarefasContext _database;
    
    [HttpGet] // Define que o método responde a requisições GET
    public IActionResult Index()
    {
        var tarefas = _database.Tarefas.ToList();
        return StatusCode(200, tarefas);
    }
    
    [HttpPost("criar")] // Define que o método responde a requisições POST
    public IActionResult Create([FromBody] Tarefa tarefa)
    {
        if(string.IsNullOrEmpty(tarefa.Titulo))
        {
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        }
        
        _database.Tarefas.Add(tarefa);
        _database.SaveChanges();
        return StatusCode(201, tarefa);
    }
}