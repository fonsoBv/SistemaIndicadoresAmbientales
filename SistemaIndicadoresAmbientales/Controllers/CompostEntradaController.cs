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
            {
                Models.CompostEntradaModel db = new Models.CompostEntradaModel();
                entrada.Fecha = System.DateTime.Now;
                entrada.Medida = "g";
                db.crearCompostEntrada(entrada);
                return View();
            }
        }

        public ActionResult ActualizarCompostEntradaView()
        {

            return View();
        }
    }
}