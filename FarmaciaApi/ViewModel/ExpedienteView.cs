namespace FarmaciaApi.ViewModel
{
    public class ExpedienteView
    {
        public int IdExpediente { get; set; }
        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Notas { get; set; }
    }
}
