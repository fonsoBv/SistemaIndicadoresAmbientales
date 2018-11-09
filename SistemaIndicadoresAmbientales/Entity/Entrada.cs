using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Entrada
    {

        [Display(Name = "Id_Entrada")]
        public int Id_Entrada { get; set; }
        [Required(ErrorMessage = "Requiere el la Medida")]
        [Display(Name = "Medida")]
        public String Medida { get; set; }
        [Required(ErrorMessage = "Requiere los gramos")]
        [Display(Name = "Cantidad")]
        public float Cantidad { get; set; }
        [Display(Name = "Id_Planta")]
        public int Id_Planta { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
    }//end class
}//end namespace