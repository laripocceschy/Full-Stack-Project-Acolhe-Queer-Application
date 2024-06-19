using acolhequeer.Models;
using acolhequeer_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


[Route("Atendimento")]
public class AtendimentoController : Controller
{
    private readonly AppDbContextt _context;

    public AtendimentoController(AppDbContextt context)
    {
        _context = context;
    }

    [HttpGet("Index")]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var atendimentos = _context.Agendamentos
            .Include(a => a.Usuario)
            .Include(a => a.Instituicao)
            .ToListAsync();

        return View(await atendimentos);
    }

    [HttpGet("Create")]
    [Authorize]
    public IActionResult Create()
    {
        var userIdClaim = User.FindFirst("Id");
        int userId = int.Parse(userIdClaim.Value);
        //var nomeClaim = User.FindFirst(ClaimTypes.Name)?.Value;

        var usuarios = _context.Usuarios
            .Where(u => u.Usuario_id == userId)
            .Select(u => new { u.Usuario_id, u.Nome })
            .ToList();

        var instituicoes = _context.Instituicao
            .Select(i => new { i.instituicao_id, i.nome })
            .ToList();

        ViewBag.UsuarioListJson = System.Text.Json.JsonSerializer.Serialize(usuarios);
        ViewBag.InstituicaoListJson = System.Text.Json.JsonSerializer.Serialize(instituicoes);

        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create([Bind("Atendimento_id,Usuario_id,Instituicao_id,Data_psi,Data_in,Data_out,Observacao,IsQuarto,IsPsicologico")] Atendimento atendimento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(atendimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SeusAgendamentosUser));
        }
        return View(atendimento);
    }

    [HttpGet("Edit/{id}")]
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var atendimento = await _context.Agendamentos.FindAsync(id);
        if (atendimento == null)
        {
            return NotFound();
        }

        var userIdClaim = User.FindFirst("Id");
        int userId = int.Parse(userIdClaim.Value);
        //var nomeClaim = User.FindFirst(ClaimTypes.Name)?.Value;

        var usuarios = _context.Usuarios
            .Where(u => u.Usuario_id == userId)
            .Select(u => new { u.Usuario_id, u.Nome })
            .ToList();

        var instituicoes = _context.Instituicao
            .Select(i => new { i.instituicao_id, i.nome })
            .ToList();

        ViewBag.UsuarioListJson = System.Text.Json.JsonSerializer.Serialize(usuarios);
        ViewBag.InstituicaoListJson = System.Text.Json.JsonSerializer.Serialize(instituicoes);

        return  View(atendimento);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(int id, [Bind("Atendimento_id,Usuario_id,Instituicao_id,Data_psi,Data_in,Data_out,Observacao,IsQuarto,IsPsicologico")] Atendimento atendimento)
    {
        if (id != atendimento.Atendimento_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(atendimento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentosExists(atendimento.Atendimento_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(SeusAgendamentosUser));
        }
        return View(atendimento);
    }

    [HttpGet("Delete/{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var atendimento = await _context.Agendamentos
            .Include(a => a.Usuario)
            .Include(a => a.Instituicao)
            .FirstOrDefaultAsync(m => m.Atendimento_id == id);

        if (atendimento == null)
        {
            return NotFound();
        }

        return View(atendimento);
    }

    [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var atendimento = await _context.Agendamentos.FindAsync(id);
        if (atendimento != null)
        {
            _context.Agendamentos.Remove(atendimento);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }

    private bool AgendamentosExists(int id)
    {
        return _context.Agendamentos.Any(e => e.Atendimento_id == id);
    }

    [HttpGet("Details/{id}")]
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var atendimento = await _context.Agendamentos
            .Include(a => a.Usuario)
            .Include(a => a.Instituicao)
            .FirstOrDefaultAsync(m => m.Atendimento_id == id);
        if (atendimento == null)
        {
            return NotFound();
        }

        return View(atendimento);
    }
    [Authorize(Roles = "Instituicao")]
    [HttpGet("SeusAgendamentosCasas")]
    public async Task<IActionResult> SeusAgendamentosCasas()
    {
        var userIdClaim = User.FindFirst("Id");
        
        int userId = int.Parse(userIdClaim.Value);
        var instituicoes = _context.Instituicao
            .Select(i => new { i.instituicao_id, i.nome })
            .ToList();

        var atendimentos = _context.Agendamentos
            .Include(a => a.Usuario)
            .Include(a => a.Instituicao)
            .AsEnumerable()  // Converte para IEnumerable para permitir a avaliação no lado do cliente
            .Where(a => instituicoes.Any(i => a.Instituicao_id == userId))
            .ToList();

        return View(atendimentos);
    }

    [Authorize(Roles = "Usuario")]
    [HttpGet("SeusAgendamentosUser")]
    public async Task<IActionResult> SeusAgendamentosUser()
    {
        var userIdClaim = User.FindFirst("Id");

        int userId = int.Parse(userIdClaim.Value);
        
        var usuarios = _context.Usuarios
            .Select(u => new { u.Usuario_id, u.Nome })
            .ToList();


       /* try
        {*/
            var atendimentos = _context.Agendamentos
                .Include(a => a.Usuario)
                .Include(a => a.Instituicao)
                .AsEnumerable()  // Converte para IEnumerable para permitir a avaliação no lado do cliente
                .Where(a => usuarios.Any(i => a.Usuario_id == userId))
                .ToList();

            return View(atendimentos);
        /*}
        catch (InvalidOperationException ex)
        {
            // Aqui você pode logar a exceção se necessário
            return View("SemAgendamentos");
        }*/


    }

}
