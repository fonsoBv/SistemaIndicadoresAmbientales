using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using SistemaIndicadoresAmbientales.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoCombustibleController : Controller
    {
        // GET: ConsumoCombustible
        //public ActionResult Index()
        //{
        //    ConsumoCombustibleModel inspeccionModel = new ConsumoCombustibleModel();
        //    ModelState.Clear();
        //    return View(inspeccionModel.obtenerInspeccion());
        //}

        public ActionResult RegistrarConsumo()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "nombre");
            return View();
        }//end Regisrar un vatihorimetro

        [HttpPost]
        public ActionResult RegistrarConsumo(Entity.ConsumoCombustible consumo, string vehiculos)
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

        }//insertar

        public ActionResult ListarConsumoCombustibleVehiculos()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustibleVehiculos());
        }

    }//fin de clase
}