using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer.Models
{

    [Table("ReservaQuartos")]

    public class ReservaQuarto
    {
        [Key]
        public int Reserva_id { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Obrigatório informar usuário!")]
        [Display(Name = "Usuário")]
        public int Usuario_id { get; set; }

        [ForeignKey("Instituicao")]
        [Required(ErrorMessage = "Obrigatório informar a instituiçao!")]
        [Display(Name = "Instituicao_id")]
        public int Instituicao_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de check_in")]
        public string Check_in { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de check_out")]
        public string Check_out { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de hoje")]
        public string Data_reserva { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(500)]
        public string Observacao { get; set; }

        public Usuario Usuario { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}
