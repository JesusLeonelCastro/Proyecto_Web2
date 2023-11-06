namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Medico")]
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            Cita = new HashSet<Cita>();
            MedicoClinica = new HashSet<MedicoClinica>();
            MedicoEspecialidad = new HashSet<MedicoEspecialidad>();
            MedicoHorario = new HashSet<MedicoHorario>();
        }

        [Key]
        public int idMedico { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        [StringLength(9)]
        public string dni { get; set; }

        [Required]
        [StringLength(15)]
        public string cmp { get; set; }

        [StringLength(50)]
        public string perfil_img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicoClinica> MedicoClinica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicoHorario> MedicoHorario { get; set; }


        //Listar
        public List<Medico> Listar()
        {
            var objMedico = new List<Medico>();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objMedico = db.Medico.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Listar(): " + ex.Message);
                throw;
            }
            return objMedico;
        }

        // Obtener
        public Medico Obtener(int id)
        {

            var objMedico = new Medico();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objMedico = db.Medico.
                        Where(x => x.idMedico == id).SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return objMedico;

        }

        //Buscar
        public List<Medico> Buscar(string criterio)
        {
            var objMedico = new List<Medico>();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objMedico = db.Medico.
                        Where(x => x.nombre.Contains(criterio) ||
                        x.apellido.Contains(criterio)).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return objMedico;

        }

        //Guardar
        public void Guardar()
        {

            try
            {
                using (var db = new db_citas_Medicas())
                {
                    if (this.idMedico > 0) 
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else 
                    {
                        db.Entry(this).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;

            }
        }

        //Eliminar
        public void Eliminar()
        {

            try
            {
                using (var db = new db_citas_Medicas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }

            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}
