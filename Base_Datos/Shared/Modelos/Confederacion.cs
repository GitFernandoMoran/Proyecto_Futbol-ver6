using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos
{
    public class Confederacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre de la confederacion")]
        [StringLength(50)]
        public string? Nombre_confederacion { get; set; }
        [Required(ErrorMessage = "Debe escribir el url del logo")]
        [StringLength(250)]
        public string? Logo { get; set; }

        virtual public ICollection<Liga>? Ligas { get; set; }
    }
}
