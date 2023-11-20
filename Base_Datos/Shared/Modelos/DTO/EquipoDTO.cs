using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos.DTO
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string? Nombre_equipo { get; set; }
        public string? Ciudad { get; set; }
        public string? Liga { get; set; }
        public string? Logo { get; set; }

    }
}
