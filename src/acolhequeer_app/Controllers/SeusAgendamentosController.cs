using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using acolhequeer_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using acolhequeer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace acolhequeer_app.Controllers
{
    [Authorize]
    public class AtendimentoController : Controller
    {
        private readonly AppDbContextt _context;

        public AtendimentoController(AppDbContextt context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Obtém o ID do usuário logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                // Busca os atendimentos do usuário logado
                var atendimentos = await _context.Agendamentos
                    .Include(a => a.Usuario)
                    .Include(a => a.Instituicao)
                    .Where(a => a.Usuario_id == int.Parse(userId))
                    .ToListAsync();

                // Retorna a view com os atendimentos se existirem
                if (atendimentos.Any())
                {
                    return View(atendimentos);
                }
            }

            // Se não houver atendimentos ou se userId for nulo, retorna uma mensagem
            return View("NoAtendimentos");
        }
    }
}
