using ApiTarefas.DTO;
using ApiTarefas.Models;

namespace ApiTarefas.Services.Interfaces;

public interface ITarefasServicos
{
    List<Tarefa> ListarTarefas(int page);

    Tarefa Incluir(TarefaDto tarefaDto);
    
    Tarefa Update(int id, TarefaDto tarefaDto);

    Tarefa BuscaPorId(int id);

    string Delete(int id);
}