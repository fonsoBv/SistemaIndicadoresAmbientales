using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Rol
    {

        [Display(Name = "id")]
        public int Id_Rol { get; set; }

        [Required(ErrorMessage = "Requiere el nombre.")]
        public string Nombre { get; set; }

    }//class
}//namespce