using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using acolhequeer_app.Data; // Namespace onde o DbContext está localizado
using acolhequeer_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace acolhequeer_app.Controllers
{
    [Authorize]
    public class AgendamentoController : Controller
    {
        private readonly acolhequeer.Models.AppDbContextt _context;

        public AgendamentoController(acolhequeer.Models.AppDbContextt context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Obtém o ID do usuário logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Busca o agendamento do usuário logado
            var agendamento = await _context.AgendaQuarto
                .Where(a => a.usuario_id == userId)
                .ToListAsync();

            // Verifica se o agendamento existe
            if (agendamento != null && agendamento.Count > 0)
            {
                // Retorna a view com os agendamentos
                return View(agendamento);
            }
            else
            {
                // Se não houver agendamentos, retorna uma mensagem
                ViewBag.Message = "Você não possui agendamentos.";
                return View();
            }
        }
    }
}
