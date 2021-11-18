using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            PacientesFacturables = new HashSet<PacientesFacturable>();
        }

        [Key]
        public int IdPaciente { get; set; }
        [Column("Fecha_Registro", TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }
        public short IdCliente { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Nombres { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Apellidos { get; set; } = null!;
        [StringLength(13)]
        [Unicode(false)]
        public string? Cedula { get; set; }
        [Column("Fecha_Nac", TypeName = "date")]
        public DateTime? FechaNac { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Pacientes))]
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        [InverseProperty(nameof(PacientesFacturable.IdPacienteNavigation))]
        public virtual ICollection<PacientesFacturable> PacientesFacturables { get; set; }
    }
}
