using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoGrupal_Citas.Models;

namespace ProyectoGrupal_Citas.Controllers
{
    public class MedicoController : Controller
    {
        private Medico objmedico = new Medico();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objmedico.Listar());
            }
            else
            {
                return View(objmedico.Buscar(criterio));
            }
        }
        public ActionResult Ver(int id)
        {
            return View(objmedico.Obtener(id));

        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objmedico.Listar() : objmedico.Buscar(criterio));

        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Medico() //nuevo objeto
                : objmedico.Obtener(id)); //devuelve el objeto encontrado

        }
        public ActionResult Guardar(Medico objmedico)
        {
            if (ModelState.IsValid)
            {
                objmedico.Guardar();
                return Redirect("~/Medico");
            }
            else
            {
                return View("~/Views/Medico/AgregarEditar.cshtml");
            }

        }
        public ActionResult Eliminar(int id)
        {
            objmedico.idMedico = id;
            objmedico.Eliminar();
            return Redirect("~/Medico");


        }
    }
}