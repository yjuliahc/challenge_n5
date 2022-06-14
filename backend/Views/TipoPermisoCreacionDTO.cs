using System.ComponentModel.DataAnnotations;

namespace Challenge_n5.Views
{
    public class TipoPermisoCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }
    }
}
