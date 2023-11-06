namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicoHorario")]
    public partial class MedicoHorario
    {
        [Key]
        public int idMedicoHorario { get; set; }

        public int idMedico { get; set; }

        public int idHorario { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
