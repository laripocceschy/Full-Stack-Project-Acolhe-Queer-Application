using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer_app.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Usuario_id { get; set; }

        [Display(Name = "Nome Social")]
        public string Nome_social { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome completo!")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a idade!")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF!")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o logradouro!")]
        [Display(Name = "Logradouro")]
        public string Endereco_logradouro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro!")]
        [Display(Name = "Bairro")]
        public string Endereco_bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a cidade!")]
        [Display(Name = "Cidade")]
        public string Endereco_cidade { get; set;}

        [Required(ErrorMessage = "Obrigatório informar o estado!")]
        [Display(Name = "Estado")]
        public string Endereco_estado { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número!")]
        [Display(Name = "Número")]
        public int Endereco_numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CEP")]
        [Display(Name = "CEP")]
        public string Endereco_cep { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Administrador")]
        public bool Bool_admin { get; set; }
    }
}
