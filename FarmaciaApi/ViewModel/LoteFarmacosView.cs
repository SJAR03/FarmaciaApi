using System.ComponentModel.DataAnnotations;

namespace FarmaciaApi.ViewModel
{
    public class LoteFarmacosView
    {
        public int IdLoteFarmaco { get; set; }
        public string NombreLoteFarmaco { get; set; }
        public string DescripcionLoteFarmaco { get; set; }
        public int Concentracion { get; set; }
        public int Cantidad { get; set; }
        public int IdPresentacion { get; set; }
        public string NombrePresentacion { get; set; }
        public string DescripcionPresentacion { get; set; }
        public int IdMedidas { get; set; }
        public string NombreMedidas { get; set; }
        public int IdDosificacion { get; set; }
        public string NombreDosificacion { get; set; }
    }
}
