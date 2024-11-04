namespace FarmaciaApi.DTOs.Update
{
    public class PrescripcionDetalleUpdateDTO
    {
        public int Cantidad { get; set; }

        public int Estado { get; set; }

        public int IdPrescripcion { get; set; } // llave foranea

        public int IdFarmacoPresentacion { get; set; } // llave foranea

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
