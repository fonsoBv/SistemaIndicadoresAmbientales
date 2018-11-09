using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoAguaController : Controller
    {
        // GET: ConsumoAgua
        public ActionResult RegistrarConsumoAguaView()
        {
            Models.HidrometroModel hidroModel = new Models.HidrometroModel();
            ViewData["Hidros"] = hidroModel.obtenerHidrometrosPorPlanta(1);
            return View();
        }//end mostrar vista

        public JsonResult ResgistrarConsumoAguaView(List<ConsumoAgua> consumo)
        {
            Models.ConsumodeAguaModel bdconsumo = new Models.ConsumodeAguaModel();
            foreach (ConsumoAgua item in consumo)
            {
                bdconsumo.crearConsumoAgua(new Entity.ConsumodeAgua
                {
                    Id_Hidrometro = item.Id_Hidrometro,
                    Cantidad = item.Cantidad,
                    Medida = "m3",
                    Fecha = System.DateTime.Now,
                    Mes = item.Mes,
                });
            }//foreach
            return Json("true", JsonRequestBehavior.AllowGet);
        }//end registrar

        public class ConsumoAgua
        {
            public int Id_Hidrometro { get; set; }
            public int Cantidad { get; set; }
            public int Mes { get; set; }

        }
    }//end class
}//end namespace