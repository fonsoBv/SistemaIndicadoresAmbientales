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
        public double Localizacion { get; set; }
        public int NISE { get; set; }
        public int Id_Vatihorimetro { get; set; }
        public int Numero_Vatihorimetro { get; set; }
        public int Id_Planta { get; set; }


    }//end class

}//namespace