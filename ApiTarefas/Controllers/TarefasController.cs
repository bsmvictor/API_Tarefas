using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Models;
using ApiTarefas.ModelVielws;
using ApiTarefas.Services;
using ApiTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers; 

[ApiController] // Define que a classe é um Controller
[Route("tarefas")] // Define a rota do Controller

// HomeController herda de ControllerBase para ter acesso a métodos de resposta
public class TarefasController : ControllerBase
{
    public TarefasController(ITarefasServicos servico)
    {
        _servico = servico;
    }

    private ITarefasServicos _servico;
    
    [HttpGet] // Define que o método responde a requisições GET
    public IActionResult Index(int page = 1)
    {
        var tarefas = _servico.ListarTarefas(page);
        
        return StatusCode(200, tarefas);
    }
    
    [HttpPost("criar")] // Define que o método responde a requisições POST
    public IActionResult Create([FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefa = _servico.Incluir(tarefaDto);
            return StatusCode(201, tarefa);
        }
        catch (Exception error)
        {
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        }
    }
    
    [HttpPut("{id}")] // Define que o método responde a requisições PUT
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefa = _servico.Update(id, tarefaDto);
            return StatusCode(200, tarefa);
        }
        catch (Exception e)
        {
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        }
    }
    
    [HttpGet("{id}")] 
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var tarefaDb = _servico.BuscaPorId(id);
            return StatusCode(200, tarefaDb);
        }
        catch (Exception error)
        {
            return StatusCode(404, new { Mensagem = $"Tarefa ({id}) não encontrada!" });
        }
    }
    
    [HttpDelete("{id}")] // Define que o método responde a requisições PUT
    public IActionResult Update([FromRoute] int id)
    {
        try
        {
            _servico.Delete(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(400, new { Mensagem = "O título não foi encontrado, a tarefa pode ser inexistente!" });
        }
    }
}