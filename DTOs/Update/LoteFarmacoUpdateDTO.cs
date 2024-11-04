namespace FarmaciaApi.DTOs.Update
{
    public class LoteFarmacoUpdateDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public int Estado { get; set; }

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
