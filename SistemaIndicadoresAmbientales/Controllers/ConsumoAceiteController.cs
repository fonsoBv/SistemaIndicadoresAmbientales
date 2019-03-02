using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoAceiteController : Controller
    {
        //// GET: ConsumoAceite
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarConsumoVehiculo()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "id_activo_placa");
            return View();
        }//Registrar consumo aceite vehiculo

        [HttpPost]
        public ActionResult RegistrarConsumoVehiculo(Entity.ConsumoAceite consumo, string vehiculos, bool cant_motorCBx, bool cant_cajaCBx, bool cant_delanteraCBx, bool cant_traseraCBx, bool cant_hidraulicoCBx)
        {
            try
            {
                Models.EquipoModel equipoModel = new Models.EquipoModel();
                ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "id_activo_placa");
                consumo.id_activo_placa = vehiculos;

                //Integro los Boolean al modelo, true = 1 false = 0
                if (cant_motorCBx == true) { consumo.cant_motor = 1; } else { consumo.cant_motor = 0; }
                if (cant_cajaCBx == true) { consumo.cant_caja = 1; } else { consumo.cant_caja = 0; }
                if (cant_delanteraCBx == true) { consumo.cant_delantera = 1; } else { consumo.cant_delantera = 0; }
                if (cant_traseraCBx == true) { consumo.cant_trasera = 1; } else { consumo.cant_trasera = 0; }
                if (cant_hidraulicoCBx == true) { consumo.cant_hidraulico = 1; } else { consumo.cant_hidraulico = 0; }

                consumo.fecha_registro = System.DateTime.Now;
                if (ModelState.IsValid)
                {
                    Models.ConsumoAceiteModel sdb = new Models.ConsumoAceiteModel();
                    if (sdb.crearConsumoAceiteVehiculo(consumo))
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
            ConsumoAceiteModel consumoModel = new ConsumoAceiteModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoAceiteVehiculos());
        }//ListarConsumoAceiteVehiculos

        public ActionResult RegistrarConsumoExtraVehiculo()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "id_activo_placa");
            return View();
        }//Registrar consumo aceite vehiculo

        [HttpPost]
        public ActionResult RegistrarConsumoExtraVehiculo(Entity.ConsumoAceite consumo, string vehiculos, string cant_motorCBx, string cant_cajaCBx, string cant_delanteraCBx, string cant_traseraCBx, string cant_hidraulicoCBx)
        {
            try
            {
                Models.EquipoModel equipoModel = new Models.EquipoModel();
                ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "id_activo_placa");
                consumo.id_activo_placa = vehiculos;
                float constante = 0.946353F;

                //Integro los select list al objeto
                consumo.cant_motor = float.Parse(cant_motorCBx) * constante;
                consumo.cant_caja = float.Parse(cant_cajaCBx) * constante;
                consumo.cant_delantera = float.Parse(cant_delanteraCBx) * constante;
                consumo.cant_trasera = float.Parse(cant_traseraCBx) * constante;
                consumo.cant_hidraulico = float.Parse(cant_hidraulicoCBx) * constante;

                consumo.fecha_registro = System.DateTime.Now;
                if (ModelState.IsValid)
                {
                    Models.ConsumoAceiteModel sdb = new Models.ConsumoAceiteModel();
                    if (sdb.crearConsumoAceiteExtraVehiculo(consumo))
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


    }//fin de clase
}