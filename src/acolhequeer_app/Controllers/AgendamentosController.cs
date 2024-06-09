using acolhequeer.Models;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AgendamentosController : Controller
{
    private readonly AppDbContextt _context;

    public AgendamentosController(AppDbContextt context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dados = await _context.Agendamentos.ToListAsync();
        return View();
    }

    [HttpPost]
    public IActionResult BuscarAtendimentosDisponiveis(DateTime data)
    {
        var atendimentos = _context.Agendamentos
            .Where(a => a.Data.Date == data.Date)
            .Select(a => new
            {
                a.Atendimento_id,
                a.Data,
                UsuarioNome = a.Usuario.Nome,
                InstituicaoNome = a.Instituicao.nome,
                a.Observacao
            })
            .ToList();

        return Json(atendimentos);
    }

    [HttpPost]
    public IActionResult ReservarAtendimento([FromBody] int atendimentoId)
    {
        try
        {
            // Verificar se o atendimento existe
            var atendimento = _context.Agendamentos.FirstOrDefault(a => a.Atendimento_id == atendimentoId);
            if (atendimento == null)
            {
                return NotFound("Atendimento não encontrado.");
            }

            // Verificar se o atendimento já foi reservado
            if (atendimento.Usuario_id != null)
            {
                return BadRequest("Este atendimento já foi reservado.");
            }

            // Aqui você pode adicionar lógica adicional, como verificar se o usuário tem permissão para reservar o atendimento.

            // CORRIGIR ESSA PARTE
            atendimento.Usuario_id = atendimento.Usuario_id;

            // Salvar as mudanças no banco de dados
            _context.SaveChanges();

            return Ok("Atendimento reservado com sucesso!");
        }
        catch (Exception ex)
        {
            // Lidar com qualquer exceção que possa ocorrer durante o processo de reserva
            return StatusCode(500, "Ocorreu um erro ao reservar o atendimento: " + ex.Message);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
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