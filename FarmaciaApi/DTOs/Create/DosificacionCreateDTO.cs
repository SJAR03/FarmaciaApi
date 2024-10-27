using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Create
{
    public class DosificacionCreateDTO
    {
        public required string Nombre { get; set; }

        public int Estado { get; set; } = 1;

        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public int IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
