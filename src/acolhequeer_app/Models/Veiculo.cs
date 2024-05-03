using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {a
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a placa!")]
        public int Placa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Ano de Fabricação!")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Ano do Modelo!")]
        [Display(Name = "Ano do Modelo")]
        public int AnoModelo { get; set; }

    }
}
