using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        public string Nombres { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Sexo { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Direccion { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Correo { get; set; }
        public int Estado { get; set; }

        //public Expediente Expediente { get; set; }
    }
}
