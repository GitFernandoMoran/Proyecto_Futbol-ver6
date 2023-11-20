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
    public class JugadoresController : ControllerBase
    {
        private readonly DataFutbolDBContext _context;

        public JugadoresController(DataFutbolDBContext context)
        {
            _context = context;
        }

        // GET: api/Jugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JugadorDTO>>> GetJugadores()
        {
            if (_context.Jugadores == null)
            {
                return NotFound();
            }
            var respuesta = _context.Jugadores.Include(c => c.Equipo).Select(r => new JugadorDTO() { Id = r.Id, Nombre_jugador = r.Nombre_jugador, Partidos_jugados = r.Partidos_jugados, Goles = r.Goles, Asistencias = r.Asistencias, Tarjetas_amarillas = r.Tarjetas_amarillas, Tarjetas_rojas = r.Tarjetas_rojas, Fotografia = r.Fotografia, Equipo = r.Equipo.Nombre_equipo });
            return await respuesta.ToListAsync();
        }

        // GET: api/Jugadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int id)
        {
          if (_context.Jugadores == null)
          {
              return NotFound();
          }
            var jugador = await _context.Jugadores.FindAsync(id);

            if (jugador == null)
            {
                return NotFound();
            }

            return jugador;
        }

        // PUT: api/Jugadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJugador(int id, Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return BadRequest();
            }

            _context.Entry(jugador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadorExists(id))
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

        // POST: api/Jugadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jugador>> PostJugador(Jugador jugador)
        {
          if (_context.Jugadores == null)
          {
              return Problem("Entity set 'DataFutbolDBContext.Jugadores'  is null.");
          }
            _context.Jugadores.Add(jugador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJugador", new { id = jugador.Id }, jugador);
        }

        // DELETE: api/Jugadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {
            if (_context.Jugadores == null)
            {
                return NotFound();
            }
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }

            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JugadorExists(int id)
        {
            return (_context.Jugadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
