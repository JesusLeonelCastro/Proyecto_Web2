namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicoEspecialidad")]
    public partial class MedicoEspecialidad
    {
        [Key]
        public int idMedicoEspecialidad { get; set; }

        public int idMedico { get; set; }

        public int idEspecialidad { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
