using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models.Security
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Pwd { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}
