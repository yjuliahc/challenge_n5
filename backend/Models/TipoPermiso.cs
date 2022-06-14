using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge_n5.Models
{
    public class TipoPermiso:Entity
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }

        public List<Permiso> Permisos;
    }
}
