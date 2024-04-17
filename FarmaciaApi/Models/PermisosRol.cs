using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class PermisosRol
    {
        [Key]
        public int IdPermisosRol { get; set; }
        public int IdPermisos { get; set; }
        public int IdRol { get; set; }

        public Permisos Permisos { get; set; }
        public Rol Rol { get; set; }
    }
}
