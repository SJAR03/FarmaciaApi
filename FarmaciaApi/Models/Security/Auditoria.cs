using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class Auditoria
    {
        [Key]
        public Guid IdAuditoria { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Tabla { get; set; }

        [Required]
        [Column(TypeName = "int(8)")]
        public string IdRegistro { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Accion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public Guid IdUsuario { get; set; } // llave foranea de usuario

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } // propiedad de navegacion
    }
}
