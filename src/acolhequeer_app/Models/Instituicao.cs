using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


[Table("Instituicao")]
public class Instituicao
{
    [Key]
    public int instituicao_id { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o nome!")]
    public string nome { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o cnpj!")]
    public string cnpj { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o email!")]
    public string email { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o telefone!")]
    public string telefone { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a rua!")]
    public string endereco_rua { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o bairro!")]
    public string endereco_bairro { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a cidade!")]
    public string endereco_cidade { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o estado!")]
    public string endereco_estado { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o numero!")]
    public int endereco_numero { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o cep!")]
    public string endereco_cep { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a senha!")]
    public string senha { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a validação!")]
    public bool adm_validacao { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o pix!")]
    public string pix_doacao { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o numero de vagas!")]
    public int n_vagas { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o atendimento!")]
    public bool bool_atd { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a disponibilidade!")]
    public int qtd_disponibilidade { get; set; }

}