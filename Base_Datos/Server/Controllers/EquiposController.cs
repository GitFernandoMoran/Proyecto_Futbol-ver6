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
    public class EquiposController : ControllerBase
    {
        private readonly DataFutbolDBContext _context;

        public EquiposController(DataFutbolDBContext context)
        {
            _context = context;
        }

        // GET: api/Equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoDTO>>> GetEquipos()
        {
            if (_context.Equipos == null)
            {
                return NotFound();
            }
            var respuesta = _context.Equipos.Include(c => c.Liga).Select(r => new EquipoDTO() { Id = r.Id, Nombre_equipo = r.Nombre_equipo, Ciudad = r.Ciudad, Logo = r.Logo, Liga = r.Liga.Nombre_liga });
            return await respuesta.ToListAsync();
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetEquipo(int id)
        {
          if (_context.Equipos == null)
          {
              return NotFound();
          }
            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        // PUT: api/Equipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(int id, Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
          if (_context.Equipos == null)
          {
              return Problem("Entity set 'DataFutbolDBContext.Equipos'  is null.");
          }
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.Id }, equipo);
        }

        // DELETE: api/Equipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            if (_context.Equipos == null)
            {
                return NotFound();
            }
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipoExists(int id)
        {
            return (_context.Equipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
