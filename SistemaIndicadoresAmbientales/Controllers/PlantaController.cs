using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndicadoresAmbientales.Models;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class PlantaController : Controller{

        public ActionResult RegistrarPlantaView()
        {
            return View();
        }//index

        public ActionResult EliminarPlantaView()
        {
            PlantaModel plantaModel = new PlantaModel();
            ModelState.Clear();
            return View(plantaModel.obtenerPlantas());
        }

        [HttpPost]
        public ActionResult RegistrarPlantaView(Entity.Planta planta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlantaModel sdb = new PlantaModel();
                    if (sdb.crearPlanta(planta))
                    {
                        ViewBag.Message = "Planta R";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }//Registrar Planta

        public ActionResult EliminarPlanta(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlantaModel sdb = new PlantaModel();
                    if (sdb.EliminarPlanta(id))
                    {
                        ViewBag.AlertMsg = "Eliminada";
                    }
                }
                return RedirectToAction("EliminarPlantaView");
            }//end try
            catch
            {
                return RedirectToAction("EliminarPlantaView");
            }//catch

        }//Registrar Planta

    }//end class

}//end namespaced