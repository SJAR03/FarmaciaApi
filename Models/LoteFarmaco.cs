using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class LoteFarmaco
    {
        [Key]
        public int IdLoteFarmaco { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Descripcion { get; set; }

        [Required]
        public int Cantidad { get; set; }

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