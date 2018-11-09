using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class ConsumodeAgua

    {

        [Display(Name = "Id_Consumo_Agua")]
        public int Id_Consumo_Agua { get; set; }
        [Required(ErrorMessage = "Requiere la medida")]
        [Display(Name = "Medida")]
        public String Medida { get; set; }
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Requiere la cantidad de m3.")]
        public float Cantidad { get; set; }
        [Display(Name = "Id_Hidrometro")]
        public int Id_Hidrometro { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Mes")]
        [Required(ErrorMessage = "Seleccione el mes correspondiente a este consumo")]
        public int Mes { get; set; }


    }
}