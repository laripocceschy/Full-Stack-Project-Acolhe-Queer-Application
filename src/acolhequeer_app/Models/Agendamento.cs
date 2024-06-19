using acolhequeer_app.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Atendimento
{
    [Key]
    public int Atendimento_id { get; set; }

    [ForeignKey("Usuario")]
    public int Usuario_id { get; set; }

    [ForeignKey("Instituicao")]
    public int Instituicao_id { get; set; }

    public DateTime? Data_psi { get; set; }

    public DateTime? Data_in { get; set; }

    public DateTime? Data_out { get; set; }

    public string Observacao { get; set; }

    public bool IsQuarto { get; set; } // Indica se é um agendamento de quarto
    public bool IsPsicologico { get; set; } // Indica se é um agendamento psicológico

    public Usuario Usuario { get; set; }
    public Instituicao Instituicao { get; set; }
}
