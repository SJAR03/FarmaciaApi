﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApi.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Pwd { get; set; }
        public int Estado { get; set; }

        //public ICollection<UsuarioRol> UsuarioRols { get; set; }

    }
}
