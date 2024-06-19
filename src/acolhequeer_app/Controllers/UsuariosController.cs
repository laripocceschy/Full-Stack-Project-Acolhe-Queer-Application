using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using acolhequeer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace acolhequeer_app.Controllers
{
    [Authorize]
    public class UsuariosController : Controller

    {
        private readonly AppDbContextt _context;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(AppDbContextt context, ILogger<UsuariosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Usuarios.ToListAsync();
            return View(dados);
        }

        // GET: Usuarios/Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {

            /* if (!ModelState.IsValid)
             {
                 return View(usuario);
             }*/

            // var dados = await _context.Usuarios
            // .FindAsync( usuario.Email);
            var matchingUsers = _context.Usuarios.Where(u => u.Email == usuario.Email);

            // Assuming Senha is hashed (security best practice)
            var dados = matchingUsers.FirstOrDefault(u => u.Senha == usuario.Senha);
            //var u = await _context.Usuarios.FindByEmailAsync(model.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou Senha inválidos.";
                return View(usuario);
            }

            // Verifica se o usuário é um administrador
            if (usuario.Bool_admin && !dados.Bool_admin)
            {
                ViewBag.Message = "Acesso negado. Este usuário não é um administrador.";
                return View(usuario);
            }

            //bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (dados != null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.Email, dados.Email),
                    new Claim(ClaimTypes.Role, "Usuario"), // Adiciona o papel "Usuario"
                    new Claim("Id", dados.Usuario_id.ToString()) // Adiciona o ID do usuário
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync( principal, props);
                
                _logger.LogInformation("Usuário {Email} logado com sucesso.", dados.Email);
                 return Redirect("/");
            }
            else
            {
               return ViewBag.Message = "Usuário e/ou Senha inválidos.";
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("Usuario_id,Nome_social,Nome,Email,Idade,Cpf,Telefone,Endereco_logradouro,Endereco_bairro,Endereco_cidade,Endereco_estado,Endereco_numero,Endereco_cep,Senha,Bool_admin")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_id,Nome_social,Nome,Email,Idade,Cpf,Telefone,Endereco_logradouro,Endereco_bairro,Endereco_cidade,Endereco_estado,Endereco_numero,Endereco_cep,Senha,Bool_admin")] Usuario usuario)
        {
            if (id != usuario.Usuario_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Usuario_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var userIdClaim = User.FindFirst("Id");
                
                string userId = userIdClaim.Value;
                return RedirectToAction(nameof(Details), new { id = userId });
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirst("Id");
            string userId = userIdClaim.Value;


            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (usuario == null)
            {
                return NotFound();
            }


            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Usuario_id == id);
        }
    }
}
