using ApiTarefas.Models;
using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Services.Interfaces;

namespace ApiTarefas.Services;

public class TarefasServico : ITarefasServicos
{
    public TarefasServico(TarefasContext database)
    {
        _database = database;
    }
    
    private TarefasContext _database;
    
    public List<Tarefa> ListarTarefas(int page = 1)
    {
        if (page < 1) page = 1; 
        int limit = 10;
        int offset = (page - 1) * limit;
        return _database.Tarefas.Skip(offset).Take(limit).ToList();
    }

    public Tarefa Incluir(TarefaDto tarefaDto)
    {
        if (string.IsNullOrEmpty(tarefaDto.Titulo))
            throw new Exception("O Título não foi encontrado, a tarefa pode ser inexistente!");

        var tarefa = new Tarefa
        {
            Titulo = tarefaDto.Titulo,
            Descricao = tarefaDto.Descricao,
            Concluida = tarefaDto.Concluida
        };
        
        _database.Tarefas.Add(tarefa);
        _database.SaveChanges();
        
        return tarefa;
    }
    
    public Tarefa Update(int id, TarefaDto tarefaDto)
    {
        var tarefaDb = _database.Tarefas.Find(id);
        
        if (string.IsNullOrEmpty(tarefaDto.Titulo))
            throw new Exception("O Título não foi encontrado, a tarefa pode ser inexistente!");

        if (tarefaDb == null)
            throw new Exception($"Tarefa ({id}) não encontrada!");
        
        tarefaDb.Titulo = tarefaDto.Titulo;
        tarefaDb.Descricao = tarefaDto.Descricao;
        tarefaDb.Concluida = tarefaDto.Concluida;
        
        _database.Tarefas.Update(tarefaDb);
        _database.SaveChanges();
        
        return tarefaDb;
    }
    
    public Tarefa BuscaPorId(int id)
    {
        var tarefaDb = _database.Tarefas.Find(id);

        if (tarefaDb == null)
            throw new Exception($"Tarefa ({id}) não encontrada!");
        
        return tarefaDb;
    }
    
    public string Delete(int id)
    {
        var tarefaDb = _database.Tarefas.Find(id);

        if (tarefaDb == null)
            throw new Exception($"Tarefa ({id}) não encontrada!");
        
        _database.Tarefas.Remove(tarefaDb);
        _database.SaveChanges();
        
        return $"Tarefa ({id}) removida com sucesso!";
    }
}