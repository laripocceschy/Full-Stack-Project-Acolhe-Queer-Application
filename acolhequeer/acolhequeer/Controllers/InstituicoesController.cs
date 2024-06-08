using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using acolhequeer.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace acolhequeer.Controllers
{
    public class InstituicoesController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<InstituicoesController> _logger;

        public InstituicoesController(AppDbContext context, ILogger<InstituicoesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Configuração base
        //public InstituicoesController(AppDbContext context)
        //{
            //_context = context;
        //}

        // GET: Instituicoes
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Instituicoes.ToListAsync();
            return View(dados);

            //return View(await _context.Instituicoes.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Instituicao instituicao)
        {
            var matchingUsers = _context.Usuarios.Where(u => u.Email == instituicao.Email);
            var dados = matchingUsers.FirstOrDefault(u => u.Senha == instituicao.Senha);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou Senha inválidos.";
                return View(instituicao);
            }

            if (dados != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.Email, dados.Email)
                };

                var instituicaoIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(instituicaoIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                _logger.LogInformation("Usuário {Email} logado com sucesso.", dados.Email);
                return Redirect("/");
            }
            else
            {
                return ViewBag.Message = "Usuário e/ou Senha inválidos.";
            }

        }


        // GET: Instituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Instituicao_id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Instituicao_id,Nome,Cnpj,Email,Telefone,Endereco_rua,Endereco_bairro,Endereco_cidade,Endereco_estado,Endereco_numero,Endereco_cep,Senha,Adm_validacao,Pix_doacao,N_vagas,Bool_atd,Qtd_disponibilidade")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                instituicao.Senha = BCrypt.Net.BCrypt.HashPassword(instituicao.Senha);
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Instituicao_id,Nome,Cnpj,Email,Telefone,Endereco_rua,Endereco_bairro,Endereco_cidade,Endereco_estado,Endereco_numero,Endereco_cep,Senha,Adm_validacao,Pix_doacao,N_vagas,Bool_atd,Qtd_disponibilidade")] Instituicao instituicao)
        {
            if (id != instituicao.Instituicao_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    instituicao.Senha = BCrypt.Net.BCrypt.HashPassword(instituicao.Senha);
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.Instituicao_id))
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

        // GET: Instituicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Instituicao_id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao != null)
            {
                _context.Instituicoes.Remove(instituicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicoes.Any(e => e.Instituicao_id == id);
        }
    }
}
