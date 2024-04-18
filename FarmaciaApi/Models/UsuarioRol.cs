using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class UsuarioRol
    {
        [Key]
        public int IdUsuarioRol { get; set; }

        [ForeignKey("IdUsuario")]
        //public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdRol")]
        //public Rol Rol { get; set; }
        public int IdRol { get; set; }
    }
}
