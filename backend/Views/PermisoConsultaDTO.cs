using Challenge_n5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge_n5.Views
{
    public class PermisoConsultaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30)]
        public string NombreEmpleado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30)]
        public string ApellidoEmpleado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]        

        public TipoPermiso TipoPermiso { get; set; }

        public DateTime Fecha { get; set; }


    }
}
