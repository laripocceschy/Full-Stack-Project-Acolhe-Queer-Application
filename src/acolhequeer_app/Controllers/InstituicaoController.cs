using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using acolhequeer.Models;

namespace acolhequeer_app.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AppDbContextt _context;

        public InstituicaoController(AppDbContextt context)
        {
            _context = context;
        }

        // GET: Instituicao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicao.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("instituicao_id,nome,cnpj,email,telefone,endereco_rua,endereco_bairro,endereco_cidade,endereco_estado,endereco_numero,endereco_cep,senha,adm_validacao,pix_doacao,n_vagas,bool_atd,qtd_disponibilidade")] Instituicao instituicao)
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
        public async Task<IActionResult> Edit(int id, [Bind("instituicao_id,nome,cnpj,email,telefone,endereco_rua,endereco_bairro,endereco_cidade,endereco_estado,endereco_numero,endereco_cep,senha,adm_validacao,pix_doacao,n_vagas,bool_atd,qtd_disponibilidade")] Instituicao instituicao)
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
    }
}
