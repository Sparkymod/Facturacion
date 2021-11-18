using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("Pacientes_Facturables")]
    public partial class PacientesFacturable
    {
        [Key]
        public int Rno { get; set; }
        [Column("Fecha_Registro", TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }
        [Column("Id_Paciente")]
        public int IdPaciente { get; set; }
        [Column("Id_Facturable")]
        public short IdFacturable { get; set; }
        [Column("Precio_RD", TypeName = "money")]
        public decimal PrecioRd { get; set; }
        [Column("Precio_US", TypeName = "money")]
        public decimal PrecioUs { get; set; }
        public int NoFact { get; set; }

        [ForeignKey(nameof(IdFacturable))]
        [InverseProperty(nameof(Facturable.PacientesFacturables))]
        public virtual Facturable IdFacturableNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdPaciente))]
        [InverseProperty(nameof(Paciente.PacientesFacturables))]
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    }
}
