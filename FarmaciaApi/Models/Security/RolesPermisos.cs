using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class RolesPermisos
    {
        [Key]
        public Guid IdRolesPermisos { get; set; }

        [Required]
        public Guid IdPermisos { get; set; } // llave foranea

        [ForeignKey("IdPermisos")]
        public Permisos Permisos { get; set; } // propiedad de navegacion

        [Required]
        public Guid IdRol { get; set; } // llave foranea

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; } // propiedad de navegacion
    }
}
