using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Prescripcion
    {
        [Key]
        public int IdPrescripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Dosis { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Duracion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Instrucciones { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdExpediente { get; set; } // llave foranea

        [ForeignKey("IdExpediente")]
        public Expediente Expediente { get; set; } // propiedad de navegacion

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
