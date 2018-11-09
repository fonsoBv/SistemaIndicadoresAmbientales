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

        }

        public class ConsumoElectrico
        {
            public int Id_Vatihorimetro { get; set; }
            public int Cantidad { get; set; }
            public int Mes { get; set; }
        }
    }
}