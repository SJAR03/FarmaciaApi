using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Presentacion
    {
        [Key]
        public int IdPresentacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string? Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdMedidas { get; set; } // llave foranea

        [ForeignKey("IdMedidas")]
        public Medidas Medidas { get; set; } // propiedad de navegacion

        [Required]
        public int IdDosificacion { get; set; } // llave foranea

        [ForeignKey("IdDosificacion")]
        public Dosificacion Dosificacion { get; set; } // propiedad de navegacion

        // llave foranea para el usuario que creo el registro
        [Required]
        public int IdUsuarioCreacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que creo el registro
        [ForeignKey("IdUsuarioCreacion")]
        public Usuario UsuarioCreacion { get; set; } // propiedad de navegacion

        [Required]
        public DateTime FechaCreacion { get; set; }

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que modifico el registro
        [ForeignKey("IdUsuarioModificacion")]
        public Usuario? UsuarioModificacion { get; set; } // propiedad de navegacion

        public DateTime? FechaModificacion { get; set; }
    }
}
