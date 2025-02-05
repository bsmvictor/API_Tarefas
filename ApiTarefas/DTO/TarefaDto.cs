namespace ApiTarefas.DTO;

public record TarefaDto
{
    public int Id { get; set; }
    
    public string Titulo { get; set; } = default;

    public string Descricao { get; set; } = default;
    
    public bool Concluida { get; set; } = default;
}