using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Planta
    {
     
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Requiere el nombre.")]
        public string nombre { get; set; }
        
    }
}