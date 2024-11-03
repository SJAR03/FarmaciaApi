using FarmaciaApi.Models.Security;
using FarmaciaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Create
{
    public class ExpedienteCreateDTO
    {
        public string Notas { get; set; }

        public int Estado { get; set; }

        public int IdPaciente { get; set; } // llave foranea

        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; }

        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime FechaModificacion { get; set; }
    }
}
