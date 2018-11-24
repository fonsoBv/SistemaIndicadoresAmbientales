using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class VatihorimetroController : Controller{

        public ActionResult RegistrarVatihorimetroView()
        {
            Models.PlantaModel plantaModel = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
            return View();
        }//end Regisrar un vatihorimetro

        [HttpPost]
        public ActionResult RegistrarVatihorimetroView(Entity.Vatihorimetro vatihorimetro, int plantas)
        {
            try
            {
                Models.PlantaModel plantaModel = new Models.PlantaModel();
                ViewData["plantas"] = new SelectList(plantaModel.obtenerPlantas(), "id", "nombre");
                
                if (ModelState.IsValid)
                {
                    VatihorimetroModel sdb = new VatihorimetroModel();
                    if (sdb.crearVatihorimetro(vatihorimetro, plantas))
                        {
                            TempData["success"] = "true";
                            return View();
                        }
                        else
                        {
                            TempData["error"] = "false";
                            return View();
                        }
                }//end if
            }catch { };

                return View();

            }//insertar

        public ActionResult EliminarVatihorimetroView()
        {
            VatihorimetroModel variModel = new VatihorimetroModel();
            ModelState.Clear();
            return View(variModel.obtenerVatihorimetros());
        }//end eliminar varihorimetro

        public ActionResult EliminarVatihorimetro(int id)
        {
            
                if (ModelState.IsValid)
                {
                   VatihorimetroModel sdb = new VatihorimetroModel();
                    if (sdb.EliminarVatihorimetro(id)){
                        TempData["success"] = "true";
                        return RedirectToAction("EliminarVatihorimetroView");
                    }else{
                        TempData["error"] = "false";
                        return View();
                    }//end if-else
                }//end if
            return View();
        }//end eliminar varihorimetro

    }//end class

}//namespace