﻿using FarmaciaApi.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Dosificacion
    {
        [Key]
        public int IdDosificacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }

        // llave foranea para el usuario que creo el registro
        [Required]
        public int IdUsuarioCreacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que creo el registro
        //[ForeignKey("IdUsuarioCreacion")]
        //public Usuario UsuarioCreacion { get; set; } // propiedad de navegacion

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        // llave foranea para el usuario que modifico el registro (puede ser null)
        public int? IdUsuarioModificacion { get; set; } // llave foranea

        // propiedad de navegacion para el usuario que modifico el registro
        //[ForeignKey("IdUsuarioModificacion")]
        //public Usuario? UsuarioModificacion { get; set; } // propiedad de navegacion

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;

    }
}