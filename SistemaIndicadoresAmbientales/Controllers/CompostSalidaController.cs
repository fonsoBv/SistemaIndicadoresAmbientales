using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class CompostSalidaController : Controller
    {
        // GET: CompostEntrada
        public ActionResult RegistrarCompostSalidaView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCompostSalidaView(Entity.Salida salida)
        {
            Models.CompostSalidaModel db = new Models.CompostSalidaModel();
            salida.Fecha = System.DateTime.Now;
            salida.Medida = "g";
            if (db.crearCompostSalida(salida))
            {
                TempData["success"] = "true";
                return RedirectToAction("RegistrarCompostSalidaView");
            }
            else
            {
                TempData["error"] = "false";
            }
            return View();
        }//end CompostSalidaController


        public JsonResult ActualizarConsumoCompostSalida(List<ActualizarConsumo> consumos)
        {
            Models.CompostSalidaModel consumo = new Models.CompostSalidaModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos)
            {
                if (consumo.actualizarConsumoCompostSalida(item.Cantidad, item.Id_Consumo_Compost_Salida)) { } else { flag = false; }
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

        public JsonResult obtenerConsumoSalidaActualizar(int mes, int planta)
        {
            Models.CompostSalidaModel model = new Models.CompostSalidaModel();
            List<Entity.ConsumoSalidaActualizar> list = model.obtenerConsumosActualizarSalida(mes, planta);
            ViewData["cantidadConsumos"] = list.Count;

            return (Json(list, JsonRequestBehavior.AllowGet));
        }//end obtenerConsumoAguaActualizar

        public ActionResult ActualizarCompostSalidaView()
        {
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month) + 1;

            return View();
        }//end registrar

        public JsonResult ActualizarConsumoSalida(List<ActualizarConsumo> consumos)
        {
            Models.CompostSalidaModel bdconsumo = new Models.CompostSalidaModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos)
            {
                if (bdconsumo.actualizarConsumoCompostSalida(item.Cantidad, item.Id_Consumo_Compost_Salida)) { } else { flag = false; }
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
            public int Id_Consumo_Compost_Salida { get; set; }
            public int Cantidad { get; set; }

        }//end ActualizarConsumo
        public class ConsumoCompost
        {
            public int Id_Consumo_Compost_Salida { get; set; }
            public int Cantidad { get; set; }
            public DateTime Fecha { get; set; }

        }//end ConsumoAgua

    }//end class
}//end namespace