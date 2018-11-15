using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Salida
    {
        [Display(Name = "Id_Salida")]
        public int Id_Salida { get; set; }

        [Required(ErrorMessage = "Requiere el nombre.")]
        [Display(Name = "Medida")]
        public String Medida { get; set; }

        [Display(Name = "Cantidad")]
        public float Cantidad { get; set; }

        [Display(Name = "Id_Planta")]
        public int Id_Planta { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
    }//end class
}//end Salida