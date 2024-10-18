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
    public class ContratosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContratosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Contratos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            return await _context.Contratos.ToListAsync();
        }

        // GET: api/Contratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }
        // GET: api/Contratos/activos
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratosActivos()
        {
            var contratosActivos = await _context.Contratos
                .Where(c => c.Estado_Contrato == "Activo")
                .ToListAsync();

            return contratosActivos;
        }
        // GET: api/Contratos/historial
        [HttpGet("historial")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetHistorialContratos()
        {
            // Filtra los contratos que tienen el estado "Finalizado"
            var contratosFinalizados = await _context.Contratos
                .Where(c => c.Estado_Contrato == "Finalizado")
                .ToListAsync();

            if (contratosFinalizados == null || contratosFinalizados.Count == 0)
            {
                return NotFound("No se encontraron contratos finalizados.");
            }

            return contratosFinalizados;
        }
        // POST: api/Contratos
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContrato", new { id = contrato.ID_Contrato }, contrato);
        }

        // PUT: api/Contratos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.ID_Contrato)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.ID_Contrato == id);
        }
    }
}
