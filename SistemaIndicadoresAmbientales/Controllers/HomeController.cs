using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }//Index

        // GET: AcercaDe
        public ActionResult AcercaDe()
        {
            return View();
        }//AcercaDe

        // GET: Error
        public ActionResult Error()
        {
            return View();
        }//Error
    }//class
}//namespace