namespace ProyectoGrupal_Citas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Especialidad")]
    public partial class Especialidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidad()
        {
            Cita = new HashSet<Cita>();
            MedicoEspecialidad = new HashSet<MedicoEspecialidad>();
        }

        [Key]
        public int idEspecialidad { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicoEspecialidad> MedicoEspecialidad { get; set; }


        //Listar
        public List<Especialidad> Listar()
        {
            var objespecialidad = new List<Especialidad>();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objespecialidad = db.Especialidad.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Listar(): " + ex.Message);
                throw;
            }
            return objespecialidad;
        }

        // Obtener
        public Especialidad Obtener(int id)
        {

            var objespecialidad = new Especialidad();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objespecialidad = db.Especialidad.
                        Where(x => x.idEspecialidad == id).SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return objespecialidad;

        }

        //Buscar
        public List<Especialidad> Buscar(string criterio)
        {
            var objespecialidad = new List<Especialidad>();
            try
            {
                using (var db = new db_citas_Medicas())
                {
                    objespecialidad = db.Especialidad.
                        Where(x => x.nombre.Contains(criterio)).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;

            }
            return objespecialidad;

        }

        //Guardar
        public void Guardar()
        {

            try
            {
                using (var db = new db_citas_Medicas())
                {
                    if (this.idEspecialidad > 0)
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
