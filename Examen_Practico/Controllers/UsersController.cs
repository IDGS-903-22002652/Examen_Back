using Examen_Practico.Data;
using Examen_Practico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("/api/registro")]
    public async Task<IActionResult> RegistrarParticipante([FromBody] User nuevoUsuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _context.Users.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipantePorId), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpGet("/api/participante/{id}")]
    public async Task<ActionResult<User>> GetParticipantePorId(int id)
    {
        var usuario = await _context.Users.FindAsync(id);

        if (usuario == null)
        {
            return NotFound("Participante no encontrado");
        }

        return Ok(usuario);
    }

    [HttpGet("/api/listado")]
    public async Task<ActionResult<IEnumerable<User>>> GetListado([FromQuery] string? q)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(q))
        {

            query = query.Where(p =>
                p.Nombre.Contains(q) ||
                p.Apellidos.Contains(q) ||
                p.Email.Contains(q) ||
                p.Ocupacion.Contains(q) ||
                p.UsuarioTwitter.Contains(q)
            );
        }

        var participantes = await query.ToListAsync();
        return Ok(participantes);
    }
}