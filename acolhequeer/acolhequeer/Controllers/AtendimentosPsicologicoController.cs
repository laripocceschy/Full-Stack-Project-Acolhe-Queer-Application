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
    public class AtendimentosPsicologicoController : Controller
    {
        private readonly AppDbContext _context;

        public AtendimentosPsicologicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AtendimentosPsicologico
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AtendimentosPsicologico.Include(a => a.Instituicao).Include(a => a.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AtendimentosPsicologico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoPsi = await _context.AtendimentosPsicologico
                .Include(a => a.Instituicao)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Atendimento_id == id);
            if (atendimentoPsi == null)
            {
                return NotFound();
            }

            return View(atendimentoPsi);
        }

        // GET: AtendimentosPsicologico/Create
        public IActionResult Create()
        {
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj");
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf");
            return View();
        }

        // POST: AtendimentosPsicologico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Atendimento_id,Usuario_id,Instituicao_id,Data,Observacao")] AtendimentoPsi atendimentoPsi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimentoPsi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", atendimentoPsi.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", atendimentoPsi.Usuario_id);
            return View(atendimentoPsi);
        }

        // GET: AtendimentosPsicologico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoPsi = await _context.AtendimentosPsicologico.FindAsync(id);
            if (atendimentoPsi == null)
            {
                return NotFound();
            }
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", atendimentoPsi.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", atendimentoPsi.Usuario_id);
            return View(atendimentoPsi);
        }

        // POST: AtendimentosPsicologico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Atendimento_id,Usuario_id,Instituicao_id,Data,Observacao")] AtendimentoPsi atendimentoPsi)
        {
            if (id != atendimentoPsi.Atendimento_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimentoPsi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoPsiExists(atendimentoPsi.Atendimento_id))
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
            ViewData["Instituicao_id"] = new SelectList(_context.Instituicoes, "Instituicao_id", "Cnpj", atendimentoPsi.Instituicao_id);
            ViewData["Usuario_id"] = new SelectList(_context.Usuarios, "Usuario_id", "Cpf", atendimentoPsi.Usuario_id);
            return View(atendimentoPsi);
        }

        // GET: AtendimentosPsicologico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoPsi = await _context.AtendimentosPsicologico
                .Include(a => a.Instituicao)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Atendimento_id == id);
            if (atendimentoPsi == null)
            {
                return NotFound();
            }

            return View(atendimentoPsi);
        }

        // POST: AtendimentosPsicologico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atendimentoPsi = await _context.AtendimentosPsicologico.FindAsync(id);
            if (atendimentoPsi != null)
            {
                _context.AtendimentosPsicologico.Remove(atendimentoPsi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoPsiExists(int id)
        {
            return _context.AtendimentosPsicologico.Any(e => e.Atendimento_id == id);
        }
    }
}
