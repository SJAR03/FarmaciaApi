using FarmaciaApi.Models.Security;
using FarmaciaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Create
{
    public class PrescripcionCreateDTO
    {
        public DateTime Fecha { get; set; }

        public string Dosis { get; set; }

        public string Duracion { get; set; }

        public string Instrucciones { get; set; }

        public int Estado { get; set; }

        public int IdExpediente { get; set; } // llave foranea

        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
