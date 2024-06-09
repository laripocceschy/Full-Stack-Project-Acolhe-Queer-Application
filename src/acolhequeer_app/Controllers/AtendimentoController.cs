using acolhequeer.Models;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

[Route("Atendimento")]
public class AtendimentoController : Controller
{
    private readonly AppDbContextt _context;

    public AtendimentoController(AppDbContextt context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dados = await _context.Agendamentos
            .Include(a => a.Instituicao)
            .Include(a => a.Usuario)
            .ToListAsync();
        return View(dados);
    }

    [HttpPost]
    public IActionResult BuscarAtendimentosDisponiveis([FromBody] DateTime data)
    {
        var atendimentos = _context.Instituicao
            .Where(a => a.bool_atd == true)
            .Select(a => new
            {
                a.nome,
                a.telefone,
                a.email
            })
            .ToList();

        return Json(atendimentos);
    }


    [HttpPost("ReservarAtendimento")]
    public IActionResult ReservarAtendimento([FromBody] int atendimentoId)
    {
        try
        {
            var atendimento = _context.Agendamentos.FirstOrDefault(a => a.Atendimento_id == atendimentoId);
            if (atendimento == null)
            {
                return NotFound("Atendimento não encontrado.");
            }

            if (atendimento.Usuario_id != null)
            {
                return BadRequest("Este atendimento já foi reservado.");
            }

            // Supondo que você tenha o ID do usuário atual
            var userId = 1; // Altere para obter o ID do usuário atual
            atendimento.Usuario_id = userId;

            _context.SaveChanges();

            return Ok("Atendimento reservado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao reservar o atendimento: " + ex.Message);
        }
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Atendimento_id,Data,Observacao")] Atendimento atendimento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(atendimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(atendimento);
    }
}
