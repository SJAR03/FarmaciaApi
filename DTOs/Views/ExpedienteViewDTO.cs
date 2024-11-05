namespace FarmaciaApi.DTOs.Views
{
    public class ExpedienteViewDTO
    {
        public int IdExpediente { get; set; }

        public string Notas { get; set; }

        public int Estado { get; set; }

        public PacienteViewDTO Paciente { get; set; } // propiedad de navegacion
    }
}
