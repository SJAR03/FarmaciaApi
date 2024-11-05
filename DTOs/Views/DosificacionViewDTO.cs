using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Views
{
    public class DosificacionViewDTO
    {
        public int IdDosificacion { get; set; }

        public required string Nombre { get; set; }

        public int Estado { get; set; }
    }
}
