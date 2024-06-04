using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using acolhequeer_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using acolhequeer.Models;

namespace acolhequeer_app.Controllers
{
    [Authorize]
    public class AgendamentoController : Controller
    {
        private readonly AppDbContextt _context;

        public AgendamentoController(AppDbContextt context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Obtém o ID do usuário logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                // Busca o agendamento do usuário logado
                var agendamento = await _context.agendaQuartos
                    .Where(a => a.usuario_id == userId)
                    .ToListAsync();

                // Retorna a view com os agendamentos se existirem
                if (agendamento.Any())
                {
                    return View(agendamento);
                }
            }

            // Se não houver agendamentos ou se userId for nulo, retorna uma mensagem
            return View("NoAgendamentos");
        }
    }
}
