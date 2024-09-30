using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class RolesPermisos
    {
        [Key]
        public int IdRolesPermisos { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdPermisos { get; set; } // llave foranea

        [ForeignKey("IdPermisos")]
        public Permisos Permisos { get; set; } // propiedad de navegacion

        [Required]
        public int IdRol { get; set; } // llave foranea

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; } // propiedad de navegacion
    }
}
