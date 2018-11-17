using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using SistemaIndicadoresAmbientales.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoAceiteController : Controller
    {
        //// GET: ConsumoAceite
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult RegistrarConsumo()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "nombre");
            return View();
        }//end Regisrar un vatihorimetro

        [HttpPost]
        public ActionResult RegistrarConsumoAceiteVehiculos(Entity.ConsumoCombustible consumo, string vehiculos)
        {
            try
            {
                Models.EquipoModel equipoModel = new Models.EquipoModel();
                ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "nombre");

                consumo.fecha_registro = System.DateTime.Now;

                if (ModelState.IsValid)
                {
                    Models.ConsumoCombustibleModel sdb = new Models.ConsumoCombustibleModel();
                    if (sdb.crearConsumoCombustible(consumo, vehiculos))
                    {
                        TempData["success"] = "true";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["error"] = "false";
                    }
                }
            }
            catch { };

            return View();

        }//RegistrarConsumoAceiteVehiculos

        public ActionResult ListarConsumoAceiteVehiculos()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustibleVehiculos());
        }//ListarConsumoAceiteVehiculos


    }//fin de clase
}