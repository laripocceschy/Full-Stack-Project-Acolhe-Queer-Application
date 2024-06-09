using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using acolhequeer.Models;

namespace acolhequeer.Models
{
    [Table("AtendimentosPsicologico")]
    public class AtendimentoPsi
    {
        [Key]
        public int Atendimento_id { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Obrigatório informar o usuário!")]
        [Display(Name = "Usuário")]
        public int Usuario_id { get; set; }

        [ForeignKey("Instituicao")]
        [Required(ErrorMessage = "Obrigatório informar a instituição!")]
        [Display(Name = "Instituicao_id")]
        public int Instituicao_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(500)]
        public string Observacao { get; set; }

        public Usuario Usuario { get; set; }
        public Instituicao Instituicao { get; set; }

    }
}
