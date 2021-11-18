using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("Configuracion")]
    public partial class Configuracion
    {
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Direccion { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string? Telefono { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column("RNC")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Rnc { get; set; }
        [StringLength(80)]
        [Unicode(false)]
        public string? Mensaje1 { get; set; }
        [StringLength(90)]
        [Unicode(false)]
        public string? Mensaje2 { get; set; }
        [StringLength(3)]
        [Unicode(false)]
        public string? Base { get; set; }
    }
}
