using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Pwd { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }

    }
}
