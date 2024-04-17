using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class PrescripcionDetalle
    {
        [Key]
        public int IdPrescripcionDetalle { get; set; }
        public int IdLoteFarmaco { get; set; }
        public int IdPresentacion { get; set; }
        public int IdMedidas { get; set; }
        public int IdDosificacion { get; set; }
        public int IdPrescripcion { get; set; }
        public int IdExpediente { get; set; }
        public int IdPaciente { get; set; }
        public int Cantidad { get; set; }

        public LoteFarmaco LoteFarmaco { get; set; }
        public Prescripcion Prescripcion { get; set; }
    }
}
