using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class MinTic2021Context : DbContext
    {
        public MinTic2021Context()
        {
        }

        public MinTic2021Context(DbContextOptions<MinTic2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Asignacion> Asignacions { get; set; }
        public virtual DbSet<Enfermera> Enfermeras { get; set; }
        public virtual DbSet<Hisotiaclinica> Hisotiaclinicas { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DANIELVALENCIA\\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("administrador");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            });

            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.ToTable("asignacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duracion)
                    .HasColumnType("date")
                    .HasColumnName("duracion");

                entity.Property(e => e.Fechafinal)
                    .HasColumnType("date")
                    .HasColumnName("fechafinal");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("date")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.IdEnfermera).HasColumnName("id_enfermera");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            });

            modelBuilder.Entity<Enfermera>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Cedula })
                    .HasName("PK__enfermer__66065F81ACE6D76E");

                entity.ToTable("enfermera");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido1")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido2")
                    .IsFixedLength(true);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cargo")
                    .IsFixedLength(true);

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("especialidad")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre1")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre2")
                    .IsFixedLength(true);

                entity.Property(e => e.Pasaporte)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pasaporte");
            });

            modelBuilder.Entity<Hisotiaclinica>(entity =>
            {
                entity.ToTable("hisotiaclinica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comentarios)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comentarios");

                entity.Property(e => e.Fechavisita)
                    .HasColumnType("date")
                    .HasColumnName("fechavisita");

                entity.Property(e => e.IdEnfermera).HasColumnName("id_enfermera");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Cedula, e.Pasaporte })
                    .HasName("PK__medico__C917860847A67911");

                entity.ToTable("medico");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Pasaporte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pasaporte");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido1")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido2")
                    .IsFixedLength(true);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cargo")
                    .IsFixedLength(true);

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("especialidad")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre1")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre2")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Cedula, e.Pasaporte })
                    .HasName("PK__paciente__C91786086564F879");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.Pasaporte, "UQ__paciente__11D989AF95774AAC")
                    .IsUnique();

                entity.HasIndex(e => e.Cedula, "UQ__paciente__415B7BE5081BFC32")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Pasaporte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pasaporte");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido1")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("apellido2")
                    .IsFixedLength(true);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Eps)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("eps");

                entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");

                entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");

                entity.Property(e => e.IdHistoriaclinica).HasColumnName("id_historiaclinica");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre1")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombre2")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
