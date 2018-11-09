using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Criterio
    {

        [Display(Name = "id_Criterio")]
        public int id_Criterio { get; set; }

        [Required(ErrorMessage = "Requiere el criterio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requiere que el criterio se relacione con una inspección.")]
        public int id_Inspeccion { get; set; }

    }//class
}//namespace