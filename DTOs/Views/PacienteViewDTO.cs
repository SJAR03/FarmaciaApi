namespace FarmaciaApi.DTOs.Views
{
    public class PacienteViewDTO
    {
        public int IdPaciente { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public int Estado { get; set; }
    }
}
