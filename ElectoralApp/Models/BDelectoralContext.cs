using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElectoralApp.Models
{
    public partial class BDelectoralContext : DbContext
    {
        public BDelectoralContext()
        {
        }

        public BDelectoralContext(DbContextOptions<BDelectoralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Ciudadanos> Ciudadanos { get; set; }
        public virtual DbSet<Elecciones> Elecciones { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<PuestoElectivo> PuestoElectivo { get; set; }
        public virtual DbSet<Resultados> Resultados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-646P9691\\SQLEXPRESS01;Database=BDelectoral;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FotoDePerfil)
                    .IsRequired()
                    .HasColumnName("Foto_de_perfil")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PartidoFk).HasColumnName("Partido_FK");

                entity.Property(e => e.PuestoFk).HasColumnName("Puesto_FK");

                entity.HasOne(d => d.PartidoFkNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.PartidoFk)
                    .HasConstraintName("FK_Candidatos_Partidos");

                entity.HasOne(d => d.PuestoFkNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.PuestoFk)
                    .HasConstraintName("FK_Candidatos_PuestoElectivo");
            });

            modelBuilder.Entity<Ciudadanos>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoDeIdentidad)
                    .IsRequired()
                    .HasColumnName("Documento_de_identidad")
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Elecciones>(entity =>
            {
                entity.Property(e => e.FechaDeRealización)
                    .IsRequired()
                    .HasColumnName("Fecha_de_realización")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partidos>(entity =>
            {
                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LogoDelPartido)
                    .IsRequired()
                    .HasColumnName("Logo_del_partido")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PuestoElectivo>(entity =>
            {
                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resultados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CandidatosFk).HasColumnName("Candidatos_FK");

                entity.Property(e => e.CiudadanosFk).HasColumnName("Ciudadanos_FK");

                entity.Property(e => e.EleccionesFk).HasColumnName("Elecciones_FK");

                entity.HasOne(d => d.CandidatosFkNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.CandidatosFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resultados_Candidatos");

                entity.HasOne(d => d.CiudadanosFkNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.CiudadanosFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resultados_Ciudadanos");

                entity.HasOne(d => d.EleccionesFkNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.EleccionesFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resultados_Elecciones");
            });
        }
    }
}
