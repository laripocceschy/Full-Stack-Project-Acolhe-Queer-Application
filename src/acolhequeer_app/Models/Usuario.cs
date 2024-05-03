using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer_app.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]

        //[Display(Name = "Nome Completo")]
        public int usuario_id { get; set; }

        [Display(Name = "Nome Social")]
        public string nome_social { get; set; }

        [Display(Name = "Nome Completo")]
        public string nome { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Idade")]
        public int idade { get; set; }

        [Display(Name = "CPF")]
        public int cpf { get; set; }

        [Display(Name = "Telefone")]
        public int telefone { get; set; }

        [Display(Name = "Rua")]
        public string endereco_rua { get; set; }

        [Display(Name = "Bairro")]
        public string endereco_bairro { get; set; }

        [Display(Name = "Cidade")]
        public string endereco_cidade { get; set;}

        [Display(Name = "Estado")]
        public string endereco_estado { get; set; }

        [Display(Name = "Número")]
        public int endereco_numero { get; set; }

        [Display(Name = "CEP")]
        public string endereco_cep { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        //[Display(Name = "Nome Completo")]
        public bool bool_admin { get; set; }
    }
}
