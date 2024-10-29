using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Expediente
    {
        [Key]
        public int IdExpediente { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Notas { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdPaciente { get; set; } // llave foranea

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; } // propiedad de navegacion

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
        public Usuario UsuarioModificacion { get; set; } // propiedad de navegacion

        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}
