using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Presentacion
    {
        [Key]
        public int IdPresentacion { get; set; }
        public int IdMedidas { get; set; }
        public int IdDosificacion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Descripcion { get; set; }

        public Medidas Medidas { get; set; }
        public Dosificacion Dosificacion { get; set; }
    }
}
