using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        //public ICollection<PermisosRol> PermisosRoles { get; set; }
        //public ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
