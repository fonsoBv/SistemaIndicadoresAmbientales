using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndicadoresAmbientales.Models;
using Newtonsoft.Json;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class InspeccionController : Controller
    {

        public ActionResult RegistrarInspeccionView()
        {
            return View();
        }//RegistrarInspeccionView

        [HttpPost]
        public ActionResult RegistrarInspeccionView(Entity.Inspeccion inspeccion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InspeccionModel sdb = new InspeccionModel();
                    if (sdb.crearInspeccion(inspeccion))
                    {
                        TempData["success"] = "true";
                        return RedirectToAction("RegistrarInspeccionView");
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

        public ActionResult EliminarInspeccionView()
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            ModelState.Clear();
            return View(inspeccionModel.obtenerInspeccion());
        }//EliminarInspeccionView

        public ActionResult EliminarInspeccion(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InspeccionModel sdb = new InspeccionModel();
                    if (sdb.EliminarInspeccion(id))
                    {
                        TempData["success"] = "true";
                    }
                    else
                    {
                        TempData["error"] = "false";
                    }
                }
                return RedirectToAction("EliminarInspeccionView");
            }
            catch
            {
                return RedirectToAction("EliminarInspeccionView");
            }
        }//EliminarInspeccion

        public ActionResult LlenarInspeccionView()
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            ViewData["inspecciones"] = new SelectList(inspeccionModel.obtenerInspeccion(), "id_Inspeccion", "Nombre");
            PlantaModel plantaModel = new PlantaModel();
            ViewData["plantas"] = plantaModel.obtenerPlantas();
            return View();
        }//RegistrarInspeccionView

        [HttpPost]
        public ActionResult LlenarInspeccionView(int nose)
        {
            return RedirectToAction("LlenarInspeccionView");
        }//RegistrarInspeccionView

        public JsonResult obtenerCriterioInspeccion(int id)
        {
            CriterioModel criterioModel = new CriterioModel();
            return Json(new SelectList(criterioModel.obtenerCriterioInspeccion(id), "id_Criterio", "Nombre"));
        }//obtenerCriterioInspeccion

        public JsonResult guardarEvaluacion(List<MacroTema> MacroTemas, List<Hallazgo> Hallazgos, int Planta, int Evaluacion, string Fecha)
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            foreach (MacroTema macroTema in MacroTemas)
            {
                int Id_Evaluacion_MacroTema = 0;
                Id_Evaluacion_MacroTema = inspeccionModel.guardarEvaluacion(macroTema.Id, macroTema.Nombre, macroTema.Cumple, Planta, Evaluacion, Fecha);
                if (macroTema.Cumple == "N")
                {
                    foreach (Hallazgo hallazgo in Hallazgos)
                    {
                        inspeccionModel.guardarHallazgo(hallazgo.Descripcion, macroTema.Id, Id_Evaluacion_MacroTema);
                    }//foreach hallagoz
                }//if no cumple
            }//foreach MacroTemas
            TempData["success"] = "true";
            return Json("true", JsonRequestBehavior.AllowGet);
        }//guardarEvaluacion

        public ActionResult VerInspeccionView()
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            ViewData["inspecciones"] = new SelectList(inspeccionModel.obtenerInspeccion(), "id_Inspeccion", "Nombre");
            PlantaModel plantaModel = new PlantaModel();
            ViewData["plantas"] = plantaModel.obtenerPlantas();
            return View();
        }//VerInspeccionView

        public JsonResult obtenerEvaluacion(int id_inspeccion, int id_planta, string fecha)
        {
            InspeccionModel inspeccionModel = new InspeccionModel();
            return Json(inspeccionModel.obtenerEvaluacion(id_inspeccion, id_planta, fecha), JsonRequestBehavior.AllowGet);
        }//obtenerCriterioInspeccion

    }//class

    public class MacroTema
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cumple { get; set; }
    }//class

    public class Hallazgo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }//class

}//namespace