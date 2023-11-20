using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos.DTO
{
    public class JugadorDTO
    {
        public int Id { get; set; }
        public string? Nombre_jugador { get; set; }
        public int Partidos_jugados { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int Tarjetas_amarillas { get; set; }
        public int Tarjetas_rojas { get; set; }
        public string? Fotografia { get; set; }
        public string? Equipo { get; set; }
    }
}
