using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using acolhequeer.Models;

namespace acolhequeer.Controllers
{
    public class ReservaQuartosController : Controller
    {
        private readonly AppDbContext _context;

        public ReservaQuartosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReservaQuartos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ReservaQuartos.Include(r => r.Instituicao).Include(r => r.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ReservaQuartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuarto = await _context.ReservaQuartos
                .Include(r => r.Instituicao)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Reserva_id == id);
            if (reservaQuarto == null)
            {
                return NotFound();
            }

            return View(reservaQuarto);
        }

        // GET: ReservaQuartos/Create
        public IActionResult Create()
        {
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj");
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf");
            return View();
        }

        // POST: ReservaQuartos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Reserva_id,Usuario_id,Instituicao_id,Check_in,Check_out,Data_reserva,Observacao")] ReservaQuarto reservaQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", reservaQuarto.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", reservaQuarto.Usuario_id);
            return View(reservaQuarto);
        }

        // GET: ReservaQuartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);
            if (reservaQuarto == null)
            {
                return NotFound();
            }
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", reservaQuarto.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", reservaQuarto.Usuario_id);
            return View(reservaQuarto);
        }

        // POST: ReservaQuartos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Reserva_id,Usuario_id,Instituicao_id,Check_in,Check_out,Data_reserva,Observacao")] ReservaQuarto reservaQuarto)
        {
            if (id != reservaQuarto.Reserva_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaQuartoExists(reservaQuarto.Reserva_id))
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
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", reservaQuarto.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", reservaQuarto.Usuario_id);
            return View(reservaQuarto);
        }

        // GET: ReservaQuartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaQuarto = await _context.ReservaQuartos
                .Include(r => r.Instituicao)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Reserva_id == id);
            if (reservaQuarto == null)
            {
                return NotFound();
            }

            return View(reservaQuarto);
        }

        // POST: ReservaQuartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);
            if (reservaQuarto != null)
            {
                _context.ReservaQuartos.Remove(reservaQuarto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaQuartoExists(int id)
        {
            return _context.ReservaQuartos.Any(e => e.Reserva_id == id);
        }
    }
}
