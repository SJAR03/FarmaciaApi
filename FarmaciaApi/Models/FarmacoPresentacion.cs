using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.Models
{
    public class FarmacoPresentacion
    {
        [Key]
        public int IdLoteFarmacoDetalles { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public int IdLoteFarmaco { get; set; } // llave foranea

        [ForeignKey("IdLoteFarmaco")]
        public LoteFarmaco LoteFarmaco { get; set; } // propiedad de navegacion

        [Required]
        public int IdPresentacion { get; set; } // llave foranea

        [ForeignKey("IdPresentacion")]
        public Presentacion Presentacion { get; set; } // propiedad de navegacion

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
