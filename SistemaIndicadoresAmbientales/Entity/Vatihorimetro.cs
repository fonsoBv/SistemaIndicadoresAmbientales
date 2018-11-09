using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Vatihorimetro
    {
        [Display(Name = "Id_Vatihorimetro")]
        public int Id_Vatihorimetro { get; set; }
        public int Numero_Vatihorimetro { get; set; }
        public int Id_Planta { get; set; }


    }//end class

}//namespace