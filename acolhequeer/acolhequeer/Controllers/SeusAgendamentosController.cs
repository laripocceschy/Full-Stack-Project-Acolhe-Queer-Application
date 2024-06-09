using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

namespace acolhequeer.Controllers
{
    [Authorize]
    public class SeusAgendamentosController : Controller
    {
        private readonly AppDbContext _context;

        public SeusAgendamentosController(AppDbContext context)
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
                var atendimentos = await _context.AtendimentosPsicologico
                    .Include(a => a.Usuario)
                    .Include(a => a.Instituicao)
                    .Where(a => a.Usuario_id == int.Parse(userId))
                    .ToListAsync();

                // Retorna a view com os atendimentos se existirem
                if (atendimentos.Count == 0)
                {
                    return View(atendimentos);
                }
                else
                {
                    return View("Você não possui nenhum agendamento.");
                }
            }

            return View();
            
        }
    }
}
