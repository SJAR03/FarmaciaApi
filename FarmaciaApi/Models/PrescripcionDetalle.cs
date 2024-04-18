using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class PrescripcionDetalle
    {
        [Key]
        public int IdPrescripcionDetalle { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("IdLoteFarmaco")]
        public LoteFarmaco LoteFarmaco { get; set; }
        public int IdLoteFarmaco { get; set; }

        [ForeignKey("IdPrescripcion")]
        public Prescripcion Prescripcion { get; set; }
        public int IdPrescripcion { get; set; }

    }
}
