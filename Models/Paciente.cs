using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Nombres { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Sexo { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Direccion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Telefono { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Correo { get; set; }

        [Required]
        public int Estado { get; set; }

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
