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
        public virtual DbSet<Familiar> Familiars { get; set; }
        public virtual DbSet<HistoriaClinica> HistoriaClinicas { get; set; }
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
                entity.ToTable("Administrador");

                entity.HasIndex(e => e.Cedula, "UQ__Administ__B4ADFE38F4A1801B")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Asignacion");

                entity.Property(e => e.Fechafinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fechafinal");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.IdEnfermera).HasColumnName("Id_enfermera");

                entity.Property(e => e.IdHistoriaClinica).HasColumnName("Id_historiaClinica");

                entity.Property(e => e.IdMedico).HasColumnName("Id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");

                entity.HasOne(d => d.IdEnfermeraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEnfermera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_Enfermera");

                entity.HasOne(d => d.IdHistoriaClinicaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHistoriaClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_HistoriaClinica");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacion_Paciente");
            });

            modelBuilder.Entity<Enfermera>(entity =>
            {
                entity.ToTable("Enfermera");

                entity.HasIndex(e => e.Cedula, "UQ__Enfermer__B4ADFE384A47B81E")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdministrador).HasColumnName("Id_administrador");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Enfermeras)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("FK_Enfermera_Administrador");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.ToTable("Familiar");

                entity.HasIndex(e => e.Cedula, "UQ__Familiar__B4ADFE38A386272F")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoriaClinica>(entity =>
            {
                entity.ToTable("HistoriaClinica");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comentarios)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Fechavisita).HasColumnType("datetime");

                entity.Property(e => e.FrecuenciaCardiaca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrecuenciaRespitario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Glicemia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEnfermera).HasColumnName("Id_enfermera");

                entity.Property(e => e.IdMedico).HasColumnName("Id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("Id_paciente");

                entity.Property(e => e.Oximetria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecionArterial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Temperatura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnfermeraNavigation)
                    .WithMany(p => p.HistoriaClinicas)
                    .HasForeignKey(d => d.IdEnfermera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaClinica_Enfermera");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.HistoriaClinicas)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaClinica_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.HistoriaClinicas)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaClinica_Paciente");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("Medico");

                entity.HasIndex(e => e.Cedula, "UQ__Medico__B4ADFE38FC4BD82C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdministrador).HasColumnName("Id_administrador");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("FK_Medico_Administrador");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Cedula, "UQ__Paciente__B4ADFE38EC3F4F9D")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdministrador).HasColumnName("Id_administrador");

                entity.Property(e => e.IdFamiliar).HasColumnName("Id_familiar");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("FK_Paciente_Administrador");

                entity.HasOne(d => d.IdFamiliarNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdFamiliar)
                    .HasConstraintName("FK_Paciente_Familiar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
