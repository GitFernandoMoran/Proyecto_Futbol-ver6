using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos
{
    public class Jugador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre del jugador")]
        [StringLength(100)]
        public string? Nombre_jugador { get; set; }
        [Required(ErrorMessage = "Debe escribir el numero de partidos jugados")]
        [Range(0, 2000, ErrorMessage = "Los partidos jugados deben de ser mayores a 0")]
        public int Partidos_jugados { get; set; }
        [Required(ErrorMessage = "Debe escribir el numero de goles")]
        [Range(0, 2000, ErrorMessage = "El numero de goles debe de ser mayor a 0")]
        public int Goles { get; set; }
        [Required(ErrorMessage = "Debe escribir el numero de asistencias")]
        [Range(0, 2000, ErrorMessage = "El numero de asistencias debe de ser mayor a 0")]
        public int Asistencias { get; set; }
        [Required(ErrorMessage = "Debe escribir el numero de tarjetas amarillas")]
        [Range(0, 2000, ErrorMessage = "El numero de tarjetas amarillas debe de ser mayor a 0")]
        public int Tarjetas_amarillas { get; set; }
        [Required(ErrorMessage = "Debe escribir el numero de tarjetas rojas")]
        [Range(0, 2000, ErrorMessage = "El numero de tarjetas rojas debe de ser mayor a 0")]
        public int Tarjetas_rojas { get; set; }
        [Required(ErrorMessage = "Debe escribir el URL de la imagen")]
        [StringLength(250)]
        public string? Fotografia { get; set; }

        public int EquipoId { get; set; }
        public Equipo? Equipo { get; set; }
    }
}
