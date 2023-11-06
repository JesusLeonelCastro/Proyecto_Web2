namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicoClinica")]
    public partial class MedicoClinica
    {
        [Key]
        public int idMedicoClinica { get; set; }

        public int idMedico { get; set; }

        public int idClinica { get; set; }

        public virtual Clinica Clinica { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
