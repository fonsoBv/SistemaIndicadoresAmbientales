using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Hidrometro
    {
        [Display(Name = "Id Hidrometro")]
        public int Id_Hidrometro { get; set; }
        [Display(Name = "Id Planta")]
        public int Id_Planta { get; set; }
        [Display(Name = "Nombre Medidor")]
        public String Nombre_Hidrometro { get; set; }
        [Display(Name = "Numero Hidrometro")]
        public int Numero_Hidrometro { get; set; }


    }
}