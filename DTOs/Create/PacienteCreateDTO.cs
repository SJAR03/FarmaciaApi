using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.DTOs.Create
{
    public class PacienteCreateDTO
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public int Estado { get; set; }

        // llave foranea para el usuario que creo el registro
        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
