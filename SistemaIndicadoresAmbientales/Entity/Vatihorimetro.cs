using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Vatihorimetro
    {
        [Display(Name = "Nombre_Medidor ")]
        public String Nombre_Medidor { get; set; }
        [Display(Name = "Ubicacion")]
        public String Ubicacion { get; set; }
        [Display(Name = "Localizacion ")]
        public Double Localizacion { get; set; }
        [Display(Name = "Id_Vatihorimetro")]
        public int Id_Vatihorimetro { get; set; }
        [Display(Name = "Numero_Vatihorimetro ")]
        public int Numero_Vatihorimetro { get; set; }
        [Display(Name = "Id_Planta")]
        public int Id_Planta { get; set; }


    }//end class

}//namespace