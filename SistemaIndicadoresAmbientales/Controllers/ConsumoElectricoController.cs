using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoElectricoController : Controller
    {

        public ActionResult RegistrarConsumoElectricoView()
        {
            Models.VatihorimetroModel vatiModel = new Models.VatihorimetroModel();
            ViewData["Vatis"] = vatiModel.obtenerVatihorimetroPorPlanta(1);
            return View();
        }//

        public JsonResult ResgistrarConsumoElectricoView(List<ConsumoElectrico> consumo)
        {
            Models.ConsumoElectricoModel bdconsumo = new Models.ConsumoElectricoModel();
            foreach (ConsumoElectrico item in consumo)
            {
                bdconsumo.crearConsumoElectrico(new Entity.ConsumoElectrico
                {
                    id_Vatihorimetro = item.Id_Vatihorimetro,
                    Cantidad = item.Cantidad,
                    Medida = "kilowatt",
                    fecha = System.DateTime.Now,
                    Mes = item.Mes,
                });
            }//foreach
            return Json("true", JsonRequestBehavior.AllowGet);

        }//edn resgistrar


        public ActionResult ActualizarConsumoElectricoView()
        {
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month)-1;

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

            foreach (ActualizarConsumo item in consumos)
            {
                bdconsumo.actualizarConsumoElectrico(item.Cantidad, item.Id_Consumo_Electrico);
            }//foreach
            return Json("exitoso", JsonRequestBehavior.AllowGet);
        }
        public class ActualizarConsumo
        {
            public int Id_Consumo_Electrico { get; set; }
            public int Cantidad { get; set; }

        }

        public class ConsumoElectrico
        {
            public int Id_Vatihorimetro { get; set; }
            public int Cantidad { get; set; }
            public int Mes { get; set; }
        }
    }
}