using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndicadoresAmbientales.Models;
using Newtonsoft.Json;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult ListarEquipos()
        {
            EquipoModel variModel = new EquipoModel();
            ModelState.Clear();

            return View(variModel.obtenerEquipos());
        }

        public ActionResult ListarVehiculo()
        {
            EquipoModel variModel = new EquipoModel();
            ModelState.Clear();

            return View(variModel.obtenerVehiculos());
        }

        public ActionResult ListarEqMenor()
        {
            EquipoModel variModel = new EquipoModel();
            ModelState.Clear();

            return View(variModel.obtenerEqMenores());
        }

        public ActionResult ListarMaquinaria()
        {
            EquipoModel variModel = new EquipoModel();
            ModelState.Clear();

            return View(variModel.obtenerMaquinaria());
        }

        public ActionResult RegistrarEquipoView()
        {
            Models.PlantaModel plantaModel = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
            return View();
        }//registrar equipo

        [HttpPost]
        public ActionResult RegistrarEquipoView(Entity.Equipo equipo, int plantas)
        {
            try
            {
                Models.PlantaModel plantaModel = new Models.PlantaModel();
                ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
                equipo.estadoBL = "0";
                if (ModelState.IsValid)
                {
                    EquipoModel sdb = new EquipoModel();
                    if (sdb.crearEquipo(equipo, plantas))
                    {
                        TempData["success"] = "true";
                        return RedirectToAction("RegistrarEquipoView");
                    }
                    else
                    {
                        TempData["error"] = "false";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }//RegistrarInspeccionView

        public ActionResult EliminarVehiculo(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EquipoModel sdb = new EquipoModel();
                    if (sdb.EliminarVehiculo(id))
                    {
                        ViewBag.AlertMsg = "Vehiculo Eliminado";
                    }
                }
                return RedirectToAction("ListarVehiculo");
            }//end try
            catch
            {
                return RedirectToAction("ListarVehiculo");
            }//catch

        }//end eliminar vehiculo

        public ActionResult EliminarEqMenor(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EquipoModel sdb = new EquipoModel();
                    if (sdb.EliminarEqMenor(id))
                    {
                        ViewBag.AlertMsg = "Equipo Eliminado";
                    }
                }
                return RedirectToAction("ListarEqMenor");
            }//end try
            catch
            {
                return RedirectToAction("ListarEqMenor");
            }//catch

        }//end eliminar equipo menor

        public ActionResult EliminarMaquinaria(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EquipoModel sdb = new EquipoModel();
                    if (sdb.EliminarMaquinaria(id))
                    {
                        ViewBag.AlertMsg = "Equipo Eliminado";
                    }
                }
                return RedirectToAction("ListarMaquinaria");
            }//end try
            catch
            {
                return RedirectToAction("ListarMaquinaria");
            }//catch

        }//end eliminar maquinaria

    }//fin de clase
}//fin del namespace