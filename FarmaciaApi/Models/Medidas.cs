using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Medidas
    {
        [Key]
        public int IdMedidas { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        //public ICollection<Presentacion> Presentaciones { get; set; }
    }
}
