using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Permisos
    {
        [Key]
        public int IdPermisos { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        //public ICollection<PermisosRol> PermisosRoles { get; set; }
    }
}
