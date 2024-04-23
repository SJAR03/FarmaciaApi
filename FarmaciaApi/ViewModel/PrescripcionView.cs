namespace FarmaciaApi.ViewModel
{
    public class PrescripcionView
    {
        public int IdExpediente { get; set; }
        public int IdPrescripcion { get; set; }
        public string Notas { get; set; }
        public DateTime Fecha { get; set; }
        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public string Instrucciones { get; set; }
        
    }
}
