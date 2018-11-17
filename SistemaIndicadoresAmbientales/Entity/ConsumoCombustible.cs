using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class ConsumoCombustible
    {

        [Display(Name = "Id Consumo")]
        public int id_consumo { get; set; }

        [Required]
        [Display(Name = "Cantidad (litros)")]
        public float cant_combustible { get; set; }

        [Required]
        [Display(Name = "No. Factura")]
        public string factura { get; set; }

        [Required]
        [Display(Name = "Fecha (factura)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_factura { get; set; }

        [Display(Name = "Fecha (registro)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_registro { get; set; }

        [Display(Name = "Tipo de Equipo")]
        public string tipo { get; set; }

        [Display(Name = "Equipo asociado")]
        public string id_activo_placa { get; set; }

    }//fin de clase
}//namespace