using ApiTarefas.Database;
using ApiTarefas.DTO;
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
    public IActionResult Create([FromBody] Tarefa tarefaDto)
    {
        if(string.IsNullOrEmpty(tarefaDto.Titulo))
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        
        var tarefa = new Tarefa
        {
            Titulo = tarefaDto.Titulo,
            Descricao = tarefaDto.Descricao,
            Concluida = tarefaDto.Concluida
        };
        
        _database.Tarefas.Add(tarefaDto);
        _database.SaveChanges();
        
        return StatusCode(201, tarefa);
    }
    
    [HttpPut("{id}")] // Define que o método responde a requisições PUT
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
    {
        if (string.IsNullOrEmpty(tarefaDto.Titulo))
        {
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        }

        var tarefaDb = _database.Tarefas.Find(id);
        if(tarefaDb == null)
        {
            return StatusCode(404, new { Mensagem = $"Tarefa ({id}) não encontrada!" });
        }
        
        tarefaDb.Titulo = tarefaDto.Titulo;
        tarefaDb.Descricao = tarefaDto.Descricao;
        tarefaDb.Concluida = tarefaDto.Concluida;
        
        _database.Tarefas.Update(tarefaDb);
        _database.SaveChanges();
        
        return StatusCode(200, tarefaDb);
    }
    
    [HttpGet("{id}")] 
    public IActionResult Show([FromRoute] int id)
    {
        var tarefaDb = _database.Tarefas.Find(id);
        if (tarefaDb == null)
        {
            return StatusCode(404, new { Mensagem = $"Tarefa ({id}) não encontrada!" });
        }

        return StatusCode(200, tarefaDb);
    }
    
    [HttpDelete("{id}")] // Define que o método responde a requisições PUT
    public IActionResult Update([FromRoute] int id)
    {
        var tarefaDb = _database.Tarefas.Find(id);
        if(tarefaDb == null)
        {
            return StatusCode(404, new { Mensagem = $"Tarefa ({id}) não encontrada!" });
        }
        
        _database.Tarefas.Remove(tarefaDb);
        _database.SaveChanges();
        
        return StatusCode(204);
    }
}