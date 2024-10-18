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
    public class InquilinosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InquilinosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inquilinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquilino>>> GetInquilinos()
        {
            return await _context.Inquilinos.ToListAsync();
        }

        // GET: api/Inquilinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquilino>> GetInquilino(int id)
        {
            var inquilino = await _context.Inquilinos.FindAsync(id);

            if (inquilino == null)
            {
                return NotFound();
            }

            return inquilino;
        }

        // POST: api/Inquilinos
        [HttpPost]
        public async Task<ActionResult<Inquilino>> PostInquilino(Inquilino inquilino)
        {
            _context.Inquilinos.Add(inquilino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInquilino", new { id = inquilino.ID_Inquilino }, inquilino);
        }

        // PUT: api/Inquilinos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquilino(int id, Inquilino inquilino)
        {
            if (id != inquilino.ID_Inquilino)
            {
                return BadRequest();
            }

            _context.Entry(inquilino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(id))
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

        // DELETE: api/Inquilinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquilino(int id)
        {
            var inquilino = await _context.Inquilinos.FindAsync(id);
            if (inquilino == null)
            {
                return NotFound();
            }

            _context.Inquilinos.Remove(inquilino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InquilinoExists(int id)
        {
            return _context.Inquilinos.Any(e => e.ID_Inquilino == id);
        }
    }
}
