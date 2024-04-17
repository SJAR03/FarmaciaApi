namespace FarmaciaApi.Dto
{
    public class PresentacionDto
    {
        public int IdPresentacion { get; set; }
        public int IdMedidas { get; set; }
        public int IdDosificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? MedidaNombre { get; set; }
        public string? DosificacionNombre { get; set; }
    }
}
