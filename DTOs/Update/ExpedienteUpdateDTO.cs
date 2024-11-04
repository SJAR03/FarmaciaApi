namespace FarmaciaApi.DTOs.Update
{
    public class ExpedienteUpdateDTO
    {
        public string Notas { get; set; }

        public int Estado { get; set; }

        public int IdPaciente { get; set; } // llave foranea

        public int? IdUsuarioModificacion { get; set; } // llave foranea

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
