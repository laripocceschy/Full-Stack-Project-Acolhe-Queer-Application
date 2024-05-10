using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer_app.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        [Display(Name = "Nome Social")]
        public string nome_social { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome completo!")]
        [Display(Name = "Nome Completo")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email!")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a idade!")]
        [Display(Name = "Idade")]
        public int idade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF!")]
        [Display(Name = "CPF")]
        public int cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone!")]
        [Display(Name = "Telefone")]
        public int telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o logradouro!")]
        [Display(Name = "Logradouro")]
        public string endereco_logradouro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro!")]
        [Display(Name = "Bairro")]
        public string endereco_bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a cidade!")]
        [Display(Name = "Cidade")]
        public string endereco_cidade { get; set;}

        [Required(ErrorMessage = "Obrigatório informar o estado!")]
        [Display(Name = "Estado")]
        public string endereco_estado { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número!")]
        [Display(Name = "Número")]
        public int endereco_numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CEP")]
        [Display(Name = "CEP")]
        public string endereco_cep { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Display(Name = "Administrador")]
        public bool bool_admin { get; set; }

    }
}
