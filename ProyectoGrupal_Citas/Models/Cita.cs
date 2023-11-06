namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cita")]
    public partial class Cita
    {
        [Key]
        public int idCita { get; set; }

        public int idPaciente { get; set; }

        public int idHorario { get; set; }

        public int idMedico { get; set; }

        public int idEspecialidad { get; set; }

        public int idClinica { get; set; }

        public virtual Clinica Clinica { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
