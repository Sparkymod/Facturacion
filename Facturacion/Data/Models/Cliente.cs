using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Index(nameof(RncCed), Name = "Idx_Clientes_CedRnc")]
    [Index(nameof(Nombre), Name = "Idx_Clientes_Nombres")]
    public partial class Cliente
    {
        public Cliente()
        {
            FacturasHes = new HashSet<FacturasH>();
            Pacientes = new HashSet<Paciente>();
        }

        [Key]
        public short IdCliente { get; set; }
        public byte IdTipoCliente { get; set; }
        [StringLength(80)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(80)]
        [Unicode(false)]
        public string? Contacto { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? Telefono { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? Celular { get; set; }
        [StringLength(80)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(90)]
        [Unicode(false)]
        public string? Email2 { get; set; }
        [StringLength(90)]
        [Unicode(false)]
        public string? Email3 { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? Direccion { get; set; }
        [Column("Rnc_Ced")]
        [StringLength(15)]
        [Unicode(false)]
        public string? RncCed { get; set; }
        [Required]
        public bool? Activo { get; set; }
        [Required]
        public bool? Fiscal { get; set; }
        [Column("Id_Moneda")]
        public byte IdMoneda { get; set; }
        public byte IdListaPrecio { get; set; }
        [Column("Id_DiasCredito")]
        public byte IdDiasCredito { get; set; }
        [Column(TypeName = "money")]
        public decimal LineaCredito { get; set; }

        [ForeignKey(nameof(IdDiasCredito))]
        [InverseProperty(nameof(DiasCredito.Clientes))]
        public virtual DiasCredito IdDiasCreditoNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdListaPrecio))]
        [InverseProperty(nameof(ListaPrecio.Clientes))]
        public virtual ListaPrecio IdListaPrecioNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdMoneda))]
        [InverseProperty(nameof(Moneda.Clientes))]
        public virtual Moneda IdMonedaNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdTipoCliente))]
        [InverseProperty(nameof(TiposCliente.Clientes))]
        public virtual TiposCliente IdTipoClienteNavigation { get; set; } = null!;
        [InverseProperty(nameof(FacturasH.IdClienteNavigation))]
        public virtual ICollection<FacturasH> FacturasHes { get; set; }
        [InverseProperty(nameof(Paciente.IdClienteNavigation))]
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
