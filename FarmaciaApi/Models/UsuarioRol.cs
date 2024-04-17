using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class UsuarioRol
    {
        [Key]
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
    }
}
