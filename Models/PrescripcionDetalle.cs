using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FarmaciaApi.Models
{
    public class PrescripcionDetalle
    {
        [Key]
        public int IdPrescripcionDetalle { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdPrescripcion { get; set; } // llave foranea

        [ForeignKey("IdPrescripcion")]
        [JsonIgnore]
        public Prescripcion Prescripcion { get; set; } // propiedad de navegacion

        [Required]
        public int IdFarmacoPresentacion { get; set; } // llave foranea

        [ForeignKey("IdFarmacoPresentacion")]
        [JsonIgnore]
        public FarmacoPresentacion FarmacoPresentacion { get; set; } // propiedad de navegacion

        // llave foranea para el usuario que creo el registro
        [Required]
        public int IdUsuarioCreacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que creo el registro
        [ForeignKey("IdUsuarioCreacion")]
        [JsonIgnore]
        public Usuario UsuarioCreacion { get; set; } // propiedad de navegacion

        [Required]
        public DateTime FechaCreacion { get; set; }

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que modifico el registro
        [ForeignKey("IdUsuarioModificacion")]
        [JsonIgnore]
        public Usuario? UsuarioModificacion { get; set; } // propiedad de navegacion

        public DateTime? FechaModificacion { get; set; }

    }
}
