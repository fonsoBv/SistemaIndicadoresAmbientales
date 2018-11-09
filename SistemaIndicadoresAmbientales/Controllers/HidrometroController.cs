using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class HidrometroController : Controller
    {
        public ActionResult RegistrarHidrometroView()
        {
            Models.PlantaModel plantaModel = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
            return View();
        }//end Regisrar un vatihorimetro

        [HttpPost]
        public ActionResult RegistrarHidrometroView(Entity.Hidrometro hidrometro, int plantas)
        {
            try
            {
                Models.PlantaModel plantaModel = new Models.PlantaModel();
                ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
                if (ModelState.IsValid)
                {
                    Models.HidrometroModel sdb = new Models.HidrometroModel();
                    if (sdb.crearHidrometro(hidrometro, plantas))
                    {
                        ModelState.Clear();
                    }
                }
            }
            catch { };

            return View();

        }//insertar

        public ActionResult EliminarHidrometroView()
        {
            HidrometroModel variModel = new HidrometroModel();
            ModelState.Clear();
            return View(variModel.obtenerHidrometros());
        }//end eliminar varihorimetro

        public ActionResult EliminarHidrometro(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HidrometroModel sdb = new HidrometroModel();
                    if (sdb.EliminarHidrometro(id))
                    {
                        ViewBag.AlertMsg = "Eliminada";
                    }
                }
                return RedirectToAction("EliminarHidrometroView");
            }//end try
            catch
            {
                return RedirectToAction("EliminarVatihorimetroView");
            }//catch

        }//end eliminar varihorimetro

    }//end class
}//end namespace