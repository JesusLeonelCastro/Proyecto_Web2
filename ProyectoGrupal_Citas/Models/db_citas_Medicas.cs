using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProyectoGrupal_Citas.Models
{
    public partial class db_citas_Medicas : DbContext
    {
        public db_citas_Medicas()
            : base("name=db_citas_Medicas")
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<MedicoClinica> MedicoClinica { get; set; }
        public virtual DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public virtual DbSet<MedicoHorario> MedicoHorario { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clinica>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clinica>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Clinica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clinica>()
                .HasMany(e => e.MedicoClinica)
                .WithRequired(e => e.Clinica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.MedicoEspecialidad)
                .WithRequired(e => e.Especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.rango)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Horario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.MedicoHorario)
                .WithRequired(e => e.Horario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.cmp)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.perfil_img)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.MedicoClinica)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.MedicoEspecialidad)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.MedicoHorario)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);
        }
    }
}
