using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class ConsumoElectrico
    {
        public int id_Consumo_Electrico { get; set; }
        [Required(ErrorMessage = "Requiere la medida")]
        public String Medida { get; set; }
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Requiere la cantidad de kilowatts")]
        public decimal Cantidad { get; set; }
        public int id_Vatihorimetro { get; set; }
        public DateTime fecha { get; set; }
        public int Mes { get; set; }

    }
}