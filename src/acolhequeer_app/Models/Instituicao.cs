using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


[Table("Instituicao")]
public class Instituicao
{
    [Key]
    public int instituicao_id { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o nome!")]
    [Display(Name = "Nome")]
    public string nome { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o CNPJ!")]
    [Display(Name = "CNPJ")]
    public string cnpj { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o email!")]
    [Display(Name = "Email")]
    public string email { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o telefone!")]
    [Display(Name = "Telefone")]
    public string telefone { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o logradouro!")]
    [Display(Name = "Logradouro")]
    public string endereco_rua { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o bairro!")]
    [Display(Name = "Bairro")]
    public string endereco_bairro { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a cidade!")]
    [Display(Name = "Cidade")]
    public string endereco_cidade { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o Estado!")]
    [Display(Name = "Estado")]
    public string endereco_estado { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o número!")]
    [Display(Name = "Número")]
    public int endereco_numero { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o CEP!")]
    [Display(Name = "CEP")]
    public string endereco_cep { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a senha!")]
    [Display(Name = "Senha")]
    public string senha { get; set; }

    [Display(Name = "Validação")]
    public bool adm_validacao { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o pix!")]
    [Display(Name = "Pix")]
    public string pix_doacao { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o número de vagas!")]
    [Display(Name = "Disponibilidade de vagas nos quartos")]
    public int n_vagas { get; set; }

    [Display(Name = "Possui atendimento psicológico?")]
    public bool bool_atd { get; set; }

    [Display(Name = "Disponibilidade de atendimentos psicológicos")]
    public int qtd_disponibilidade { get; set; }

}