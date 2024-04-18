using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Prescripcion
    {
        [Key]
        public int IdPrescripcion { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Dosis { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Duracion { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Instrucciones { get; set; }

        [ForeignKey("IdExpediente")]
        //public Expediente Expediente { get; set; }
        public int IdExpediente { get; set; }

        //public ICollection<PrescripcionDetalle> PrescripcionDetalles { get; set; }
    }
}
