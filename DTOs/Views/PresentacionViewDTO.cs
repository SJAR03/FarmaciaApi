using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Views
{
    public class PresentacionViewDTO
    {
        public int IdPresentacion { get; set; }

        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int Estado { get; set; }

        public MedidasViewDTO Medidas { get; set; } // propiedad de navegacion

        public DosificacionViewDTO Dosificacion { get; set; } // propiedad de navegacion
    }
}
