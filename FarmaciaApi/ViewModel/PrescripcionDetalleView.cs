namespace FarmaciaApi.ViewModel
{
    public class PrescripcionDetalleView
    {
        public int IdPrescripcionDetalle { get; set; }
        public int IdLoteFarmaco { get; set; }
        public int IdPrescripcion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Concentracion { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public string Instrucciones { get; set; }

    }
}
