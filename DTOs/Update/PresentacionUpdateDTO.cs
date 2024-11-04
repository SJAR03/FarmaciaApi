namespace FarmaciaApi.DTOs.Update
{
    public class PresentacionUpdateDTO
    {
        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int Estado { get; set; }

        public int IdMedidas { get; set; } // llave foranea

        public int IdDosificacion { get; set; } // llave foranea

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
