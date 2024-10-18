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
    public class PropiedadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropiedadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Propiedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propiedad>>> GetPropiedades()
        {
            return await _context.Propiedades.ToListAsync();
        }

        // GET: api/Propiedades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Propiedad>> GetPropiedad(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);

            if (propiedad == null)
            {
                return NotFound();
            }

            return propiedad;
        }

        // POST: api/Propiedades
        [HttpPost]
        public async Task<ActionResult<Propiedad>> PostPropiedad(Propiedad propiedad)
        {
            _context.Propiedades.Add(propiedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropiedad", new { id = propiedad.ID_Propiedad }, propiedad);
        }

        // PUT: api/Propiedades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropiedad(int id, Propiedad propiedad)
        {
            if (id != propiedad.ID_Propiedad)
            {
                return BadRequest();
            }

            _context.Entry(propiedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropiedadExists(id))
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

        // DELETE: api/Propiedades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropiedad(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad == null)
            {
                return NotFound();
            }

            _context.Propiedades.Remove(propiedad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropiedadExists(int id)
        {
            return _context.Propiedades.Any(e => e.ID_Propiedad == id);
        }
    }
}
