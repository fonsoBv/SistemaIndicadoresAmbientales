using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Inspeccion
    {

        [Display(Name = "id_Inspeccion")]
        public int id_Inspeccion { get; set; }

        [Required(ErrorMessage = "Requiere el nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requiere la fecha de la Inspección.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Requiere la planta a la que se le realizo la inspección.")]
        public int id_Planta { get; set; }

    }//class
}//namespace