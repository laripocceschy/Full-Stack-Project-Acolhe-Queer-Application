using Microsoft.AspNetCore.Mvc;
using acolhequeer_app.Models;
//using acolhequeer_app.ViewModels;
using System.Linq;
using acolhequeer.Models;

public class AccountController : Controller
{
    private readonly AppDbContextt _context;

    public AccountController(AppDbContextt context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.TipoUsuario == "Usuario" || model.TipoUsuario == "Admin")
            {
                var usuario = _context.Usuarios.SingleOrDefault(u => u.email == model.Email && u.senha == model.Senha);
                if (usuario != null && ((model.TipoUsuario == "Admin" && usuario.bool_admin) || model.TipoUsuario == "Usuario"))
                {
                    HttpContext.Session.SetString("UserId", usuario.usuario_id.ToString());
                    HttpContext.Session.SetString("UserType", model.TipoUsuario);
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (model.TipoUsuario == "Instituicao")
            {
                var instituicao = _context.Instituicao.SingleOrDefault(i => i.email == model.Email && i.senha == model.Senha);
                if (instituicao != null)
                {
                    HttpContext.Session.SetString("UserId", instituicao.instituicao_id.ToString());
                    HttpContext.Session.SetString("UserType", "Instituicao");
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Tentativa de login inválida.");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
