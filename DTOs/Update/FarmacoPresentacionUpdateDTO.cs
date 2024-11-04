namespace FarmaciaApi.DTOs.Update
{
    public class FarmacoPresentacionUpdateDTO
    {
        public int Estado { get; set; }

        public int IdLoteFarmaco { get; set; } // llave foranea

        public int IdPresentacion { get; set; } // llave foranea

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
