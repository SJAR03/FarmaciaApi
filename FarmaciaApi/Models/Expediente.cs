using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Expediente
    {
        [Key]
        public int IdExpediente { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Notas { get; set; }
        public int Estado { get; set; }
        //public int IdUsuario { get; set; }

        public Paciente Paciente { get; set; }
        //public Usuario Usuario { get; set; }

        //public ICollection<Prescripcion> Prescripciones { get; set; }
    }
}
