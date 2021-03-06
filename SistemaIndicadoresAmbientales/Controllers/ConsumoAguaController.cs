﻿using Microsoft.AspNet.Identity;
using SistemaIndicadoresAmbientales.Models;
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
            PlantaModel planta = new PlantaModel();
            String email = Session["email"].ToString();
            if (email != null)
            {
                int id_planta = planta.obtenerUsuarioPlanta(email);
                ViewData["Hidros"] = hidroModel.obtenerHidrometrosPorPlanta(id_planta);
                return View();
            }else{
                return View();
            }
        }//end mostrar vista

        public ActionResult ObtenerHidros(int id_planta)
        {
            Models.HidrometroModel hidroModel = new Models.HidrometroModel();
            PlantaModel planta = new PlantaModel();
            return Json(hidroModel.obtenerHidrometrosPorPlanta(id_planta),JsonRequestBehavior.AllowGet);
        }//end mostrar vista

        public ActionResult RegistrarConsumoAguaAntiguoView()
        {
            Models.HidrometroModel hidroModel = new Models.HidrometroModel();
            PlantaModel planta = new PlantaModel();
            String email = Session["email"].ToString();
            if (email != null)
            {
                int id_planta = planta.obtenerUsuarioPlanta(email);
                ViewData["Hidros"] = hidroModel.obtenerHidrometrosPorPlanta(id_planta);
                return View();
            }else{
                return View();
            }
       } 

        public JsonResult ResgistrarConsumoAguaView(List<ConsumoAgua> consumo)
        {
            Models.ConsumodeAguaModel bdconsumo = new Models.ConsumodeAguaModel();
            var flag = true;
            foreach (ConsumoAgua item in consumo)
            {
                if (bdconsumo.crearConsumoAgua(new Entity.ConsumodeAgua
                {
                    Id_Hidrometro = item.Id_Hidrometro,
                    LecturaActual = item.LecturaActual,
                    Medida = "m3",
                    Fecha = System.DateTime.Now,
                    Mes = item.Mes,
                })){ }else{flag = false;}
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
            }
        }//end registrar

        public JsonResult ResgistrarConsumoAguaAntiguoView(List<ConsumoAguaAntiguo> consumo)
        {
            Models.ConsumodeAguaModel bdconsumo = new Models.ConsumodeAguaModel();
            var flag = true;
            foreach (ConsumoAguaAntiguo item in consumo)
            {
                if (bdconsumo.crearConsumoAgua(new Entity.ConsumodeAgua
                {
                    Id_Hidrometro = item.Id_Hidrometro,
                    Cantidad = item.Cantidad,
                    Medida = "m3",
                    Fecha = item.Fecha,
                    Mes = item.Mes,
                })) { }
                else { flag = false; }
            }//foreach
            if (flag){
                TempData["success"] = "true";
                return Json("true", JsonRequestBehavior.AllowGet);
            }else{
                TempData["error"] = "false";
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }//end registrar


        public ActionResult ActualizarConsumoAguaView()
        {
            Models.PlantaModel planta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(planta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month)+1;

            return View();
        }//end registrar

        public JsonResult obtenerConsumoAguaActualizar(int mes, int planta)
        {
            Models.ConsumodeAguaModel model = new Models.ConsumodeAguaModel();
            List<Entity.ConsumoAguaActualizar> list = model.obtenerConsumosActualizarAgua(mes, planta);
            ViewData["cantidadConsumos"] = list.Count;
            return (Json(list, JsonRequestBehavior.AllowGet));
        }//end obtenerConsumoAguaActualizar

        public JsonResult ActualizarConsumoAgua(List<ActualizarConsumo> consumos)
        {
            Models.ConsumodeAguaModel bdconsumo = new Models.ConsumodeAguaModel();
            bool flag = true;
            foreach (ActualizarConsumo item in consumos)
            {
                if (bdconsumo.actualizarConsumodeAgua(item.Cantidad, item.Id_Consumo_Agua)){ }else{ flag = false; }
            }//foreach
            if(flag){
                TempData["success"] = "true";
                return Json("true", JsonRequestBehavior.AllowGet);
            }else{
                TempData["error"] = "false";
                return Json("false", JsonRequestBehavior.AllowGet);
            }//end validation
        }//end actualizarConsumo

        public ActionResult MostrarHistoricoAguaView()
        {
            ViewData["AnioAnterior"] = ((System.DateTime.Now.Year)-1);
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            ViewData["MesAnterior"] = (System.DateTime.Now.Month) + 1;


            return View();

        }//MostrarHistoricoAgua

        public JsonResult obtenerHistoricoAguaAnual(int planta,int mes,int anio)
       {
            Models.ConsumodeAguaModel model = new Models.ConsumodeAguaModel();
            List<Entity.HistoricoAgua> consumo = model.obtenerHistoricoAgua(planta,mes,anio);
            ViewData["cantidadConsumos"] = consumo.Count;
            return (Json(consumo,JsonRequestBehavior.AllowGet));
        }//obtenerHistoricoAgua

        public ActionResult HistoricoPorHidrometroView()
        {
            Models.PlantaModel palnta = new Models.PlantaModel();
            ViewData["plantas"] = new SelectList(palnta.obtenerPlantas(), "id", "nombre");
            return View();
        }

        public JsonResult obtenerHistoricoAguaAnualporHidrometro(int hidro,int anio1,int anio2)
        {
            Models.ConsumodeAguaModel model = new Models.ConsumodeAguaModel();
            List<Entity.HistoricoAgua> consumo = model.obtenerHistoricoAguaAnualporHidrometro(hidro,anio1,anio2);
            ViewData["cantidadConsumos"] = consumo.Count;
            return (Json(consumo, JsonRequestBehavior.AllowGet));
        }//obtenerHistoricoAgua


        public class ActualizarConsumo
        {
            public int Id_Consumo_Agua { get; set; }
            public decimal Cantidad { get; set; }

        }//end ActualizarConsumo
        public class ConsumoAgua
        {
            public int Id_Hidrometro { get; set; }
            public decimal LecturaActual { get; set; }
            public int Mes { get; set; }

        }//end ConsumoAgua

        public class ConsumoAguaAntiguo
        {
            public int Id_Hidrometro { get; set; }
            public decimal Cantidad { get; set; }
            public decimal LecturaActual { get; set; }
            public int Mes { get; set; }
            public DateTime Fecha { get; set; }


        }//end ConsumoAgua

    }//end class
}//end namespace