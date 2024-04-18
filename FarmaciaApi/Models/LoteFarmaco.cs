using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class LoteFarmaco
    {
        [Key]
        public int IdLoteFarmaco { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Descripcion { get; set; }
        public int Concentracion { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("IdPresentacion")]
        //public Presentacion Presentacion { get; set; }
        public int IdPresentacion { get; set; }

        //public ICollection<PrescripcionDetalle> PrescripcionDetalles { get; set; }

    }
}