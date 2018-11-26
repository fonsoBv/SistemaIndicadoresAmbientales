using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Usuario
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Contrasena")]
        public string Contrasena { get; set; }

    }//class
}//namespace