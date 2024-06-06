using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace acolhequeer_app.Models
{
    public class Agendamento
    {
        [Key]
        public int Atendimento_id { get; set; }

        [ForeignKey("Usuario")]
        public int Usuario_id { get; set; }

        [ForeignKey("Instituicao")]
        public int instituicao_id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public string Observacao { get; set; }

        public Usuario Usuario { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}
