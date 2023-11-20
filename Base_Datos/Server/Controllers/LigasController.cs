using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base_Datos.Server.Data;
using Base_Datos.Shared.Modelos;
using Base_Datos.Shared.Modelos.DTO;

namespace Base_Datos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigasController : ControllerBase
    {
        private readonly DataFutbolDBContext _context;

        public LigasController(DataFutbolDBContext context)
        {
            _context = context;
        }

        // GET: api/Ligas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigaDTO>>> GetLigas()
        {
            if (_context.Ligas == null)
            {
                return NotFound();
            }
            var respuesta = _context.Ligas.Include(c => c.Confederacion).Select(r => new LigaDTO() { Id = r.Id, Nombre_liga = r.Nombre_liga, Pais = r.Pais, Logo = r.Logo, Confederacion = r.Confederacion.Nombre_confederacion });
            return await respuesta.ToListAsync();
        }

        // GET: api/Ligas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Liga>> GetLiga(int id)
        {
          if (_context.Ligas == null)
          {
              return NotFound();
          }
            var liga = await _context.Ligas.FindAsync(id);

            if (liga == null)
            {
                return NotFound();
            }

            return liga;
        }

        // PUT: api/Ligas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiga(int id, Liga liga)
        {
            if (id != liga.Id)
            {
                return BadRequest();
            }

            _context.Entry(liga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigaExists(id))
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

        // POST: api/Ligas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Liga>> PostLiga(Liga liga)
        {
          if (_context.Ligas == null)
          {
              return Problem("Entity set 'DataFutbolDBContext.Ligas'  is null.");
          }
            _context.Ligas.Add(liga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiga", new { id = liga.Id }, liga);
        }

        // DELETE: api/Ligas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiga(int id)
        {
            if (_context.Ligas == null)
            {
                return NotFound();
            }
            var liga = await _context.Ligas.FindAsync(id);
            if (liga == null)
            {
                return NotFound();
            }

            _context.Ligas.Remove(liga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LigaExists(int id)
        {
            return (_context.Ligas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
