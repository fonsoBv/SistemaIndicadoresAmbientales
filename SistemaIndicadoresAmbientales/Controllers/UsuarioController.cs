using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaIndicadoresAmbientales.Models;

namespace SistemaIndicadoresAmbientales.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult verUsuarios()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            ModelState.Clear();
            return View(usuarioModel.obtenerUsuario());
        }//verUsuarios

    }//class
}//namespace