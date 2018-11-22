using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class ConsumoAceite
    {
        [Display(Name = "Id Consumo")]
        public int id_consumo { get; set; }

        [Display(Name = "Motor")]
        public float cant_motor { get; set; }

        [Display(Name = "Transmision")]
        public float cant_caja { get; set; }

        [Display(Name = "Traccion Delantera")]
        public float cant_delantera { get; set; }

        [Display(Name = "Traccion Trasera")]
        public float cant_trasera { get; set; }

        [Display(Name = "Componentes Hidraulicos")]
        public float cant_hidraulico { get; set; }

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
    }
}