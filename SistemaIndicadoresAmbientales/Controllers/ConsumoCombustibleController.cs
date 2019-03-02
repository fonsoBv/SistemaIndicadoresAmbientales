using SistemaIndicadoresAmbientales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class ConsumoCombustibleController : Controller
    {
        public ActionResult ListarConsumoCombustible()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustible());
        }//Lista de consumos (TODOS LOS EQUIPOS)

        public ActionResult RegistrarConsumo()//este registrar es solo para vehiculos
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["vehiculos"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "nombre");
            return View();
        }//end Regisrar un consumo (vehiculos)

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

        }//registrar un consumo de combustible para vehiculos

        public ActionResult ListarConsumoCombustibleVehiculos()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustibleVehiculos());
        }//Lista de consumos (solo vehiculos)

        public ActionResult RegistrarConsumoEqMenor()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["eq_menores"] = new SelectList(equipoModel.obtenerEqMenores(), "id_activo_placa", "nombre");
            return View();
        }//end Regisrar un consumo (Eq Menor)

        [HttpPost]
        public ActionResult RegistrarConsumoEqMenor(Entity.ConsumoCombustible consumo, string eq_menores)
        {
            try
            {
                Models.EquipoModel equipoModel = new Models.EquipoModel();
                ViewData["eq_menores"] = new SelectList(equipoModel.obtenerVehiculos(), "id_activo_placa", "nombre");

                consumo.fecha_registro = System.DateTime.Now;

                if (ModelState.IsValid)
                {
                    Models.ConsumoCombustibleModel sdb = new Models.ConsumoCombustibleModel();
                    if (sdb.crearConsumoCombustibleEqMenor(consumo, eq_menores))
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

        }//registrar un consumo de combustible para equipo menor

        public ActionResult ListarConsumoCombustibleEqMenor()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustibleEqMenor());
        }//Lista de consumos (solo equipo menor)

        
        public ActionResult RegistrarConsumoMaquinaria()
        {
            Models.EquipoModel equipoModel = new Models.EquipoModel();
            ViewData["maquinarias"] = new SelectList(equipoModel.obtenerMaquinaria(), "id_activo_placa", "nombre");
            return View();
        }//end Regisrar un consumo (Maquinaria)

        [HttpPost]
        public ActionResult RegistrarConsumoMaquinaria(Entity.ConsumoCombustible consumo, string maquinarias)
        {
            try
            {
                Models.EquipoModel equipoModel = new Models.EquipoModel();
                ViewData["maquinarias"] = new SelectList(equipoModel.obtenerMaquinaria(), "id_activo_placa", "nombre");

                consumo.fecha_registro = System.DateTime.Now;

                if (ModelState.IsValid)
                {
                    Models.ConsumoCombustibleModel sdb = new Models.ConsumoCombustibleModel();
                    if (sdb.crearConsumoCombustibleMaquinaria(consumo, maquinarias))
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

        }//registrar un consumo de combustible para maquinaria

        public ActionResult ListarConsumoCombustibleMaquinaria()
        {
            ConsumoCombustibleModel consumoModel = new ConsumoCombustibleModel();
            ModelState.Clear();
            return View(consumoModel.obtenerConsumoCombustibleMaquinaria());
        }//Lista de consumos (solo maquinaria)

    }//fin de clase
}