using acolhequeer.Models;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace acolhequeer_app.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AppDbContextt _context;

        public InstituicaoController(AppDbContextt context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Instituicao> dados = await _context.Instituicao.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Instituicao.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Instituicao.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Instituicao instituicao)
        {
            if (id != instituicao.instituicao_id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = _context.Instituicao.Find(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = _context.Instituicao.Find(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = _context.Instituicao.Find(id);

            if (dados == null)
                return NotFound();

            _context.Instituicao.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}
