using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class Permisos
    {
        [Key]
        public Guid IdPermisos { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

    }
}
