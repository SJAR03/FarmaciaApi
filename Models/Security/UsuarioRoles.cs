using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class UsuarioRoles
    {
        [Key]
        public int IdUsuarioRoles { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdUsuario { get; set; } // llave foranea

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } // propiedad de navegacion

        [Required]
        public int IdRol { get; set; } // llave foranea

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; } // propiedad de navegacion
    }
}
