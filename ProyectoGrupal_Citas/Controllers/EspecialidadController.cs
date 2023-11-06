using ProyectoGrupal_Citas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoGrupal_Citas.Models;

namespace ProyectoGrupal_Citas.Controllers
{
    public class EspecialidadController : Controller
    {
        private Especialidad objespecialidad = new Especialidad();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objespecialidad.Listar());
            }
            else
            {
                return View(objespecialidad.Buscar(criterio));
            }
        }
        public ActionResult Ver(int id)
        {
            return View(objespecialidad.Obtener(id));

        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objespecialidad.Listar() : objespecialidad.Buscar(criterio));

        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Especialidad() //nuevo objeto
                : objespecialidad.Obtener(id)); //devuelve el objeto encontrado

        }
        public ActionResult Guardar(Especialidad objespecialidad)
        {
            if (ModelState.IsValid)
            {
                objespecialidad.Guardar();
                return Redirect("~/Especialidad");
            }
            else
            {
                return View("~/Views/Especialidad/AgregarEditar.cshtml");
            }

        }
        public ActionResult Eliminar(int id)
        {
            objespecialidad.idEspecialidad = id;
            objespecialidad.Eliminar();
            return Redirect("~/Especialidad");
        }
    }
}