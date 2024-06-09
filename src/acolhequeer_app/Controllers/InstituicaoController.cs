using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using acolhequeer.Models;
using acolhequeer_app.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace acolhequeer_app.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AppDbContextt _context;
        private readonly ILogger<InstituicaoController> _logger;

        public InstituicaoController(AppDbContextt context, ILogger<InstituicaoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Instituicao
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Instituicao.ToListAsync();
            return View(dados);
        }

        //Login Instituição
        // GET: Usuarios/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Instituicao instituicao)
        {

            /* if (!ModelState.IsValid)
             {
                 return View(usuario);
             }*/

            // var dados = await _context.Usuarios
            // .FindAsync( usuario.Email);
            var matchingUsers = _context.Instituicao.Where(u => u.email == instituicao.email);

            // Assuming Senha is hashed (security best practice)
            var dados = matchingUsers.FirstOrDefault(u => u.senha == instituicao.senha);
            //var u = await _context.Usuarios.FindByEmailAsync(model.Email);

            if (dados == null)
            {
                ViewBag.Message = "Instituição e/ou Senha inválidos.";
                return View(instituicao);
            }

            //bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (dados != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.nome),
                    new Claim(ClaimTypes.Email, dados.email)
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                _logger.LogInformation("Instituição {Email} logado com sucesso.", dados.email);
                return Redirect("/");
            }
            else
            {
                return ViewBag.Message = "Instituição e/ou Senha inválidos.";
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        // GET: Instituicao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicao
                .FirstOrDefaultAsync(m => m.instituicao_id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: Instituicao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("instituicao_id,nome,cnpj,email,telefone,endereco_rua,endereco_bairro,endereco_cidade,endereco_estado,endereco_numero,endereco_cep,senha,adm_validacao,pix_doacao,n_vagas,descricao_casa,bool_atd,qtd_disponibilidade")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("instituicao_id,nome,cnpj,email,telefone,endereco_rua,endereco_bairro,endereco_cidade,endereco_estado,endereco_numero,endereco_cep,senha,adm_validacao,pix_doacao,n_vagas,descricao_casa,bool_atd,qtd_disponibilidade")] Instituicao instituicao)
        {
            if (id != instituicao.instituicao_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.instituicao_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicao
                .FirstOrDefaultAsync(m => m.instituicao_id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // POST: Instituicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);
            if (instituicao != null)
            {
                _context.Instituicao.Remove(instituicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicao.Any(e => e.instituicao_id == id);
        }

        // GET: Instituicao/Casas
        public async Task<IActionResult> Casas()
        {
            var instituicoes = await _context.Instituicao.ToListAsync();
            return View(instituicoes);
        }

        // GET: Instituicao/Doacoes
        public async Task<IActionResult> Doacoes()
        {
            var instituicoes = await _context.Instituicao.ToListAsync();
            return View(instituicoes);
        }
    }
}
