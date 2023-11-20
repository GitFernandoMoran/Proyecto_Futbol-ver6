using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos
{
    public class Equipo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre del equipo")]
        [StringLength(100)]
        public string? Nombre_equipo { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre de la ciudad")]
        [StringLength(50)]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "Debe escribir el URL de la imagen")]
        [StringLength(250)]
        public string? Logo { get; set; }

        public int LigaId { get; set; }
        public Liga? Liga { get; set; }

        virtual public ICollection<Jugador>? Jugadores { get; set; }

    }
}
