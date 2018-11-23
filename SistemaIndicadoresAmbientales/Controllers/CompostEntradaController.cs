using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class CompostEntradaController : Controller
    {
        // GET: CompostEntrada
        public ActionResult RegistrarCompostEntradaView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCompostEntradaView(Entity.Entrada entrada)
        {
            Models.CompostEntradaModel db = new Models.CompostEntradaModel();
            entrada.Fecha = System.DateTime.Now;
            entrada.Medida = "g";
            if (db.crearCompostEntrada(entrada))
            {
                TempData["success"] = "true";
                return RedirectToAction("RegistrarCompostEntradaView");
            }
            else
            {
                TempData["error"] = "false";
            }//end if-else
            return View();
        }//endo method

        public JsonResult ActualizarConsumoCompostEntrada(List<ActualizarConsumo> consumos)
        {
            Models.CompostEntradaModel consumo = new Models.CompostEntradaModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos)
            {
                if (consumo.actualizarConsumoCompostEntrada(item.Cantidad, item.Id_Consumo_Compost_Entrada)) { } else { flag = false; }
            }//foreach
            if (flag)
            {
                TempData["success"] = "true";
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["error"] = "false";
                return Json("false", JsonRequestBehavior.AllowGet);
            }//end validation
        }//end actualizarConsumo

        public JsonResult obtenerConsumoEntradaActualizar(int mes, int planta)
        {
            Models.CompostEntradaModel model = new Models.CompostEntradaModel();
            List<Entity.ConsumoEntradaActualizar> list = model.obtenerConsumosActualizarEntrada(mes, planta);
            ViewData["cantidadConsumos"] = list.Count;

            return (Json(list, JsonRequestBehavior.AllowGet));
        }//end obtenerConsumoAguaActualizar

        public ActionResult ActualizarCompostEntradaView()
        {
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month) + 1;

            return View();
        }//end registrar

        public JsonResult ActualizarConsumoEntrada(List<ActualizarConsumo> consumos)
        {
            Models.CompostEntradaModel bdconsumo = new Models.CompostEntradaModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos)
            {
                if (bdconsumo.actualizarConsumoCompostEntrada(item.Cantidad, item.Id_Consumo_Compost_Entrada)) { } else { flag = false; }
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
            }//end if-else
        }//end actualizarConsumoAgua

        public class ActualizarConsumo
        {
            public int Id_Consumo_Compost_Entrada { get; set; }
            public int Cantidad { get; set; }

        }//end ActualizarConsumo
        public class ConsumoAgua
        {
            public int Id_Consumo_Compost_Entrada { get; set; }
            public int Cantidad { get; set; }
            public DateTime Fecha { get; set; }

        }//end ConsumoAgua
    }//end class
}//end namespaced