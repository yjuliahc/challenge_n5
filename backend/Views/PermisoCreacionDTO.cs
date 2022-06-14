using Challenge_n5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge_n5.Views
{
    public class PermisoCreacionDTO
    {
        [Required(ErrorMessage = "El nombre del empleado es requerido")]
        [MaxLength(30)]
        public string NombreEmpleado { get; set; }
        [Required(ErrorMessage = "El apellido del empleado es requerido")]
        [MaxLength(30)]
        public string ApellidoEmpleado { get; set; }

        [Required(ErrorMessage = "El campo tipo de permiso es requerido")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El tipo de permiso debe de ser un dato valido")]

        public int TipoPermisoId { get; set; }

        public DateTime Fecha = DateTime.Now;




    }
}
