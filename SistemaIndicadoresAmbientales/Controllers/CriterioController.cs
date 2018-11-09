using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndicadoresAmbientales.Models;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class CriterioController : Controller
    {
        public ActionResult RegistrarCriterioView()
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            ViewData["inspecciones"] = new SelectList(inspeccionModel.obtenerInspeccion(), "id_Inspeccion", "Nombre");
            return View();
        }//RegistrarCriterioView

        [HttpPost]
        public ActionResult RegistrarCriterioView(Entity.Criterio criterio, int inspecciones)
        {
            try
            {
                InspeccionModel inspeccionModel = new InspeccionModel();
                ViewData["inspecciones"] = new SelectList(inspeccionModel.obtenerInspeccion(), "id_Inspeccion", "Nombre");

                if (ModelState.IsValid)
                {
                    CriterioModel sdb = new CriterioModel();
                    if (sdb.crearCriterio(criterio, inspecciones))
                    {
                        TempData["success"] = "true";
                        return RedirectToAction("RegistrarCriterioView");
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
        }//RegistrarCriterioView

        public ActionResult EliminarCriterioView()
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            ViewData["inspecciones"] = new SelectList(inspeccionModel.obtenerInspeccion(), "id_Inspeccion", "Nombre");
            return View();
        }//EliminarCriterioView

        public ActionResult EliminarCriterio(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CriterioModel sdb = new CriterioModel();
                    if (sdb.EliminarCriterio(id))
                    {
                        TempData["success"] = "true";
                    }
                    else
                    {
                        TempData["error"] = "false";
                    }
                }
                return RedirectToAction("EliminarCriterioView");
            }
            catch
            {
                return RedirectToAction("EliminarCriterioView");
            }
        }//Registrar Planta

        public JsonResult obtenerCriterioInspeccion(int id)
        {
            CriterioModel criterioModel = new CriterioModel();
            return Json(new SelectList(criterioModel.obtenerCriterioInspeccion(id), "id_Criterio", "Nombre"));
        }//obtenerCriterioInspeccion

    }//class
}//namespace