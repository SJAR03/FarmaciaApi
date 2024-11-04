using FarmaciaApi.Models.Security;
using FarmaciaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Create
{
    public class FarmacoPresentacionCreateDTO
    {
        public int Estado { get; set; }

        public int IdLoteFarmaco { get; set; } // llave foranea

        public int IdPresentacion { get; set; } // llave foranea

        // llave foranea para el usuario que creo el registro
        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
