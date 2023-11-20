using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base_Datos.Server.Data;
using Base_Datos.Shared.Modelos;

namespace Base_Datos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfederacionesController : ControllerBase
    {
        private readonly DataFutbolDBContext _context;

        public ConfederacionesController(DataFutbolDBContext context)
        {
            _context = context;
        }

        // GET: api/Confederaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Confederacion>>> GetConfederaciones()
        {
          if (_context.Confederaciones == null)
          {
              return NotFound();
          }
            return await _context.Confederaciones.ToListAsync();
        }

        // GET: api/Confederaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Confederacion>> GetConfederacion(int id)
        {
          if (_context.Confederaciones == null)
          {
              return NotFound();
          }
            var confederacion = await _context.Confederaciones.FindAsync(id);

            if (confederacion == null)
            {
                return NotFound();
            }

            return confederacion;
        }

        // PUT: api/Confederaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfederacion(int id, Confederacion confederacion)
        {
            if (id != confederacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(confederacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfederacionExists(id))
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

        // POST: api/Confederaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Confederacion>> PostConfederacion(Confederacion confederacion)
        {
          if (_context.Confederaciones == null)
          {
              return Problem("Entity set 'DataFutbolDBContext.Confederaciones'  is null.");
          }
            _context.Confederaciones.Add(confederacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfederacion", new { id = confederacion.Id }, confederacion);
        }

        // DELETE: api/Confederaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfederacion(int id)
        {
            if (_context.Confederaciones == null)
            {
                return NotFound();
            }
            var confederacion = await _context.Confederaciones.FindAsync(id);
            if (confederacion == null)
            {
                return NotFound();
            }

            _context.Confederaciones.Remove(confederacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfederacionExists(int id)
        {
            return (_context.Confederaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
