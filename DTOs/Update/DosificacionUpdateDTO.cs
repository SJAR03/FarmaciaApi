namespace FarmaciaApi.DTOs.Update
{
    public class DosificacionUpdateDTO
    {
        public required string Nombre { get; set; }

        public int Estado { get; set; }

        public int IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
