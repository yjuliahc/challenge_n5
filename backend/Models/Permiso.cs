using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge_n5.Models
{
    public class Permiso:Entity
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreEmpleado { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoEmpleado { get; set; }        
        public TipoPermiso TipoPermiso { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El tipo de permiso debe de ser un dato valido")]
        public int TipoPermisoId { get; set; }

        public DateTime Fecha { get; set; }



        public DateTime FechaPermiso { get; set; }

    }
}
