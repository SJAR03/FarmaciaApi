using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

    }
}
