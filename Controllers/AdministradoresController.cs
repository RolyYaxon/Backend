using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdministradoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            return await _context.Administradores.ToListAsync();
        }

        // GET: api/Administradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // POST: api/Administradores
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.ID_Administrador }, administrador);
        }

        // PUT: api/Administradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.ID_Administrador)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.ID_Administrador == id);
        }
    }
}
