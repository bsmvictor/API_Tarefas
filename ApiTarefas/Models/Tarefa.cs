using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefas.Models;

[Table("Tarefas")]
public class Tarefa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; } = default;
    
    [Column(TypeName = "TEXT")]
    public string Descricao { get; set; } = default;
    
    public bool Concluida { get; set; } = default;
}