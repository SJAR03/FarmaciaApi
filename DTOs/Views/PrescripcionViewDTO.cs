using FarmaciaApi.Models.Security;
using FarmaciaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Views
{
    public class PrescripcionViewDTO
    {
        public int IdPrescripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Dosis { get; set; }

        public string Duracion { get; set; }

        public string Instrucciones { get; set; }

        public int Estado { get; set; }

        public ExpedienteViewDTO Expediente { get; set; } // propiedad de navegacion
    }
}
