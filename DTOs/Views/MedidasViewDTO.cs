using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Views
{
    public class MedidasViewDTO
    {
        public int IdMedidas { get; set; }

        public string Nombre { get; set; }

        public int Estado { get; set; }
    }
}
