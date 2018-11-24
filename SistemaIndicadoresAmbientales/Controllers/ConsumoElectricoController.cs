using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoElectricoController : Controller
    {

        public ActionResult RegistrarConsumoElectricoView()
        {
            VatihorimetroModel vatiModel = new VatihorimetroModel();
            PlantaModel planta = new PlantaModel();

            String email = Session["email"].ToString();
            if (email != null)
            {
                int id_planta = planta.obtenerUsuarioPlanta(email);
                ViewData["Vatis"] = vatiModel.obtenerVatihorimetroPorPlanta(id_planta);
                return View();
            }else
            {
                return View();
            }
        }//

        public JsonResult ResgistrarConsumoElectricoView(List<ConsumoElectrico> consumo)
        {
            Models.ConsumoElectricoModel bdconsumo = new Models.ConsumoElectricoModel();
            bool flag = true;
            foreach (ConsumoElectrico item in consumo)
            {
                if(bdconsumo.crearConsumoElectrico(new Entity.ConsumoElectrico
                {
                    id_Vatihorimetro = item.Id_Vatihorimetro,
                    Cantidad = item.Cantidad,
                    Medida = "kilowatt",
                    fecha = System.DateTime.Now,
                    Mes = item.Mes,
                })) { }else { flag = false; }
            }//foreach
            if (flag)
            {
                TempData["success"] = "true";
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["error"] = "false";
                return Json("true", JsonRequestBehavior.AllowGet);
            }

        }//edn resgistrar


        public ActionResult ActualizarConsumoElectricoView()
        {
            Models.PlantaModel palnta = new Models.PlantaModel();
            PlantaModel planta = new PlantaModel();
            String email = Session["email"].ToString();
            int id_planta = planta.obtenerUsuarioPlanta(email);
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month) - 1;
            return View();
        }//end registrar

        public JsonResult obtenerConsumoElectricoActualizar(int mes, int planta)
        {
            Models.ConsumoElectricoModel model = new Models.ConsumoElectricoModel();
            List<Entity.ConsumoElectricoActualizar> list = model.obtenerConsumosActualizarElectrico(mes, planta);
            ViewData["cantidadConsumos"] = list.Count;
            return (Json(list, JsonRequestBehavior.AllowGet));
        }//end obtenerConsumoAguaActualizar



        public JsonResult ActualizarConsumoElectrico(List<ActualizarConsumo> consumos)
        {
            Models.ConsumoElectricoModel bdconsumo = new Models.ConsumoElectricoModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos){
                if (bdconsumo.actualizarConsumoElectrico(item.Cantidad, item.Id_Consumo_Electrico)) { } else { flag = false; };
            }//foreach
            if (flag){
                TempData["success"] = "true";
                return Json("true", JsonRequestBehavior.AllowGet);
            }else{
                TempData["error"] = "false";
                return Json("true", JsonRequestBehavior.AllowGet);
            }//end if-else
        }//end actualizar consumo



        public ActionResult MostrarHistoricoElectricoView()
        {
            ViewData["AnioAnterior"] = ((System.DateTime.Now.Year) - 1);
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month) + 1;


            return View();

        }//MostrarHistoricoAgua

        public JsonResult obtenerHistoricoElectrico(int planta, int mes, int anio)
        {
            Models.ConsumoElectricoModel model = new Models.ConsumoElectricoModel();
            List<Entity.HistoricoElectrico> consumo = model.obtenerHistoricoElectrico(planta, mes, anio);
            ViewData["cantidadConsumos"] = consumo.Count;
            return (Json(consumo, JsonRequestBehavior.AllowGet));
        }//obtenerHistoricoAgua

        public JsonResult obtenerHistoricoElectricoAnual(int planta, int anio)
        {
            Models.ConsumoElectricoModel model = new Models.ConsumoElectricoModel();
            List<Entity.HistoricoElectrico> consumo = model.obtenerHistoricoElectricoAnual(planta, anio);
            ViewData["cantidadConsumos"] = consumo.Count;
            return (Json(consumo, JsonRequestBehavior.AllowGet));
        }//obtenerHistoricoAgua

        public class ActualizarConsumo{
            public int Id_Consumo_Electrico { get; set; }
            public int Cantidad { get; set; }
        }//end class

        public class ConsumoElectrico{
            public int Id_Vatihorimetro { get; set; }
            public int Cantidad { get; set; }
            public int Mes { get; set; }
        }//end class
    }
}