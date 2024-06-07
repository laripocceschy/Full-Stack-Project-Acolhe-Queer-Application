using acolhequeer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace acolhequeer.Controllers
{
    public class ReservaQuartosController : Controller
    {
        private readonly AppDbContext _context;
        public ReservaQuartosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.ReservaQuartos.ToListAsync();
            return View(dados);
        }
    }
}
