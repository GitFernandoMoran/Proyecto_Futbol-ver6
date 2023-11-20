using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Datos.Shared.Modelos.DTO
{
    public class LigaDTO
    {
        public int Id { get; set; }

        public string? Nombre_liga { get; set; }

        public string? Pais { get; set; }

        public string? Confederacion { get; set; }

        public string? Logo { get; set; }

        
    }
}
