using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "Obrigatório informar o email!")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Obrigatório informar a senha!")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o tipo de usuário!")]
    [Display(Name = "Tipo de Usuário")]
    public string TipoUsuario { get; set; } // "Usuario", "Admin" ou "Instituicao"
}

