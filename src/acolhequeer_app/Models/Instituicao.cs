using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


[Table("Instituicao")]
public class Instituicao
{
    [Key]
    public int instituicao_id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Obrigatório informar o nome!")]
    public string nome { get; set; }

    [Display(Name = "Insira o cnpj")]
    [Required(ErrorMessage = "Obrigatório informar o cnpj!")]
    public string cnpj { get; set; }

    [Display(Name = "Insira o e-mail")]
    [Required(ErrorMessage = "Obrigatório informar o email!")]
    public string email { get; set; }

    [Display(Name = "Insira o telefone")]
    [Required(ErrorMessage = "Obrigatório informar o telefone!")]
    public string telefone { get; set; }

    [Display(Name = "Insira o nome")]
    [Required(ErrorMessage = "Obrigatório informar a rua!")]
    public string endereco_rua { get; set; }

    [Display(Name = "Insira o bairro")]
    [Required(ErrorMessage = "Obrigatório informar o bairro!")]
    public string endereco_bairro { get; set; }

    [Display(Name = "Insira a cidade")]
    [Required(ErrorMessage = "Obrigatório informar a cidade!")]
    public string endereco_cidade { get; set; }

    [Display(Name = "Insira o estado")]
    [Required(ErrorMessage = "Obrigatório informar o estado!")]
    public string endereco_estado { get; set; }

    [Display(Name = "Insira o numero")]
    [Required(ErrorMessage = "Obrigatório informar o numero!")]
    public int endereco_numero { get; set; }

    [Display(Name = "Insira o CEP")]
    [Required(ErrorMessage = "Obrigatório informar o cep!")]
    public string endereco_cep { get; set; }

    [Display(Name = "Insira a senha")]
    [Required(ErrorMessage = "Obrigatório informar a senha!")]
    public string senha { get; set; }

    [Display(Name = "Insira a validação")]
    [Required(ErrorMessage = "Obrigatório informar a validação!")]
    public bool adm_validacao { get; set; }

    [Display(Name = "Insira o pix")]
    [Required(ErrorMessage = "Obrigatório informar o pix!")]
    public string pix_doacao { get; set; }

    [Display(Name = "Insira o numero de vags")]
    [Required(ErrorMessage = "Obrigatório informar o numero de vagas!")]
    public int n_vagas { get; set; }

    [Display(Name = "Insira o atendimento psicológico")]
     public bool bool_atd { get; set; }

    [Display(Name = "Insira a disponibilidade")]
    public int? qtd_disponibilidade { get; set; }

}