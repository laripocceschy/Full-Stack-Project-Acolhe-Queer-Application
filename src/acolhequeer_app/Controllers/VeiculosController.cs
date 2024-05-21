using acolhequeer.Models;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace acolhequeer_app.Controllers
{
    public class VeiculosController(AppDbContextt context) : Controller
    {
        private readonly AppDbContextt _context = context;

        public async Task<IActionResult> Index()
        {
            // Use `ToListAsync()` corretamente dentro de um `List<>` para a coleção de veículos
            List<Veiculo> dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }
        
        public IActionResult Create() 
        { 
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid) 
            {
               _context.Veiculos.Add(veiculo); 
               await _context.SaveChangesAsync();
               return RedirectToAction("Index");
            }
            return View(veiculo);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            //var dados = await _context.Veiculos.FindAsync(id);
            var dadosList = await _context.Veiculos.ToListAsync();

            var dados = dadosList.FirstOrDefault(a => a.Id == id);

            if (dados == null)
                return NotFound();
        
            
            return View(dados);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                _context.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public AppDbContextt Get_context()
        {
            return _context;
        }

        public async Task<IActionResult> Details(int? id, AppDbContextt _context)
        { 
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = _context.Veiculos.Find(id);

            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }
}

