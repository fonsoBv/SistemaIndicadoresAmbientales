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
            db.crearCompostSalida(salida);
            return View();
        }
    }//end CompostSalidaController
}//end namespace