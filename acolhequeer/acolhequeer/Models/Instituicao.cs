using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acolhequeer.Models
{
    [Table("Instituicoes")]
    public class Instituicao
    {
        [Key]
        public int Instituicao_id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CNPJ!")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o logradouro!")]
        [Display(Name = "Logradouro")]
        public string Endereco_rua { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro!")]
        [Display(Name = "Bairro")]
        public string Endereco_bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a cidade!")]
        [Display(Name = "Cidade")]
        public string Endereco_cidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Estado!")]
        [Display(Name = "Estado")]
        public string Endereco_estado { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número!")]
        [Display(Name = "Número")]
        public int Endereco_numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CEP!")]
        [Display(Name = "CEP")]
        public string Endereco_cep { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Validação")]
        public bool Adm_validacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o pix!")]
        [Display(Name = "Pix")]
        public string Pix_doacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número de vagas!")]
        [Display(Name = "Disponibilidade de vagas nos quartos")]
        public int N_vagas { get; set; }

        [Display(Name = "Possui atendimento psicológico?")]
        public bool Bool_atd { get; set; }

        [Display(Name = "Disponibilidade de atendimentos psicológicos")]
        public int? Qtd_disponibilidade { get; set; }

        public ICollection<ReservaQuarto> ReservaQuartos { get; set; }

        public ICollection<AtendimentoPsi> AtendimentosPsicologico { get; set; }

    }
}
