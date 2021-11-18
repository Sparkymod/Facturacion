﻿using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class TipoFactura
    {
        [Required]
        public byte Rno { get; set; }
        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; } = "";
    }
}
