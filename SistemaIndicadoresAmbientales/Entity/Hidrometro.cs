using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Hidrometro
    {
        [Display(Name = "Id_Hidrometro")]
        public int Id_Hidrometro { get; set; }
        [Display(Name = "Id_Planta")]
        public int Id_Planta { get; set; }
        [Display(Name = "NISE")]
        public int NISE { get; set; }
        [Display(Name = "Numero_Hidrometro")]
        public int Numero_Hidrometro { get; set; }


    }
}