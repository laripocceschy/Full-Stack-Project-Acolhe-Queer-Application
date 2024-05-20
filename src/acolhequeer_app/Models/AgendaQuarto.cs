using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer_app.Models
{
    [Table("AgendamentoQuarto")]
    public class AgendaQuarto
    {
        [Key]
        public int reserva_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar usuário!")]
        [Display(Name = "Usuário")]
        public string usuario_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a instituiçao!")]
        [Display(Name = "Instituicao_id")]
        public string instituicao_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de check_in")]
        public string check_in { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de check_out")]
        public string check_out { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de hoje")]
        public string data_reserva { get; set; }

        [Display(Name = "Observações")]
        public string observacao { get; set; }
    }
}
