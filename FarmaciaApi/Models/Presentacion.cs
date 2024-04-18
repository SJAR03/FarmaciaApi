using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Presentacion
    {
        [Key]
        public int IdPresentacion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public required string Nombre { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Descripcion { get; set; }

        [ForeignKey("IdMedidas")]
        public int IdMedidas { get; set; }
        //public Medidas? Medidas { get; set; }

        [ForeignKey("IdDosificacion")]
        public int IdDosificacion { get; set; }
        //public Dosificacion? Dosificacion { get; set; }

        //public ICollection<LoteFarmaco>? LoteFarmacos { get; set; }
    }
}
