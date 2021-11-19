using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Serilog;

namespace Facturacion.Data.Database
{
    public partial class FacturaDbContext : DbContext
    {
        public FacturaDbContext()
        {
        }

        public FacturaDbContext(DbContextOptions<FacturaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Configuracion> Configuracions { get; set; } = null!;
        public virtual DbSet<DiasCredito> DiasCreditos { get; set; } = null!;
        public virtual DbSet<Facturable> Facturables { get; set; } = null!;
        public virtual DbSet<FacturasD> FacturasDs { get; set; } = null!;
        public virtual DbSet<FacturasH> FacturasHes { get; set; } = null!;
        public virtual DbSet<ListaPrecio> ListaPrecios { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<PacientesFacturable> PacientesFacturables { get; set; } = null!;
        public virtual DbSet<SecFiscal> SecFiscals { get; set; } = null!;
        public virtual DbSet<TiposCliente> TiposClientes { get; set; } = null!;
        public virtual DbSet<TiposFacturable> TiposFacturables { get; set; } = null!;
        public virtual DbSet<TiposFiscal> TiposFiscals { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;
        public virtual DbSet<VwClientesActivo> VwClientesActivos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_UserId");

                            j.IndexerProperty<string>("UserId").HasMaxLength(128);

                            j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Fiscal).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdListaPrecio).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdDiasCreditoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDiasCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_DiasCredito");

                entity.HasOne(d => d.IdListaPrecioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdListaPrecio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Lista_Precios");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Monedas");

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Tipos_Clientes");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.Property(e => e.Base).IsFixedLength();
            });

            modelBuilder.Entity<Facturable>(entity =>
            {
                entity.HasKey(e => e.IdFacturable)
                    .HasName("PK_EstudiosMedicos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoFactuable).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdTipoFactuableNavigation)
                    .WithMany(p => p.Facturables)
                    .HasForeignKey(d => d.IdTipoFactuable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facturables_TiposFacturables");
            });

            modelBuilder.Entity<FacturasD>(entity =>
            {
                entity.HasOne(d => d.IdFacturableNavigation)
                    .WithMany(p => p.FacturasDs)
                    .HasForeignKey(d => d.IdFacturable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasD_Facturables");

                entity.HasOne(d => d.IdTipoFacturableNavigation)
                    .WithMany(p => p.FacturasDs)
                    .HasForeignKey(d => d.IdTipoFacturable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasD_TipoFacturables");

                entity.HasOne(d => d.NoFactNavigation)
                    .WithMany(p => p.FacturasDs)
                    .HasForeignKey(d => d.NoFact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasD_FacturasH");
            });

            modelBuilder.Entity<FacturasH>(entity =>
            {
                entity.Property(e => e.NoFact).ValueGeneratedNever();

                entity.Property(e => e.FechaGen).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTipoFiscal).HasComment("");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.FacturasHes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasH_Clientes");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacientes_Clientes");
            });

            modelBuilder.Entity<PacientesFacturable>(entity =>
            {
                entity.HasKey(e => e.Rno)
                    .HasName("PK_Pacientes_Estudios");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdFacturableNavigation)
                    .WithMany(p => p.PacientesFacturables)
                    .HasForeignKey(d => d.IdFacturable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacientes_Facturables_Facturables");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.PacientesFacturables)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacientes_Facturables_Pacientes");
            });

            modelBuilder.Entity<SecFiscal>(entity =>
            {
                entity.Property(e => e.Valor).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.ToView("View_1");
            });

            modelBuilder.Entity<VwClientesActivo>(entity =>
            {
                entity.ToView("vwClientesActivos");

                entity.Property(e => e.IdCliente).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
