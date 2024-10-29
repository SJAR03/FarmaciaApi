using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Medidas
    {
        [Key]
        public int IdMedidas { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }

        // llave foranea para el usuario que creo el registro
        [Required]
        public int IdUsuarioCreacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que creo el registro
        //[ForeignKey("IdUsuarioCreacion")]
        [NotMapped]
        public Usuario UsuarioCreacion { get; set; } // propiedad de navegacion

        [Required]
        public DateTime FechaCreacion { get; set; }

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que modifico el registro
        //[ForeignKey("IdUsuarioModificacion")]
        [NotMapped]
        public Usuario? UsuarioModificacion { get; set; } // propiedad de navegacion

        public DateTime? FechaModificacion { get; set; }
    }
}
