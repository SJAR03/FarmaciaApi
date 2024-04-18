using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class PermisosRol
    {
        [Key]
        public int IdPermisosRol { get; set; }

        [ForeignKey("IdPermisos")]
        public Permisos Permisos { get; set; }
        public int IdPermisos { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
        public int IdRol { get; set; }
    }
}
