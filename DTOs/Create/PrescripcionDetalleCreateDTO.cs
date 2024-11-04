namespace FarmaciaApi.DTOs.Create
{
    public class PrescripcionDetalleCreateDTO
    {
        public int Cantidad { get; set; }

        public int Estado { get; set; }

        public int IdPrescripcion { get; set; } // llave foranea

        public int IdFarmacoPresentacion { get; set; } // llave foranea

        public int IdUsuarioCreacion { get; set; } // llave foranea

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
    }
}
