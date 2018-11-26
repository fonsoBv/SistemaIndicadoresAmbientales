using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Equipo
    {
        [Required]
        [Display(Name = "Identificador")]
        public string id_activo_placa { get; set; }

        [Display(Name = "Tipo Combustible")]
        public string tipo_combustible { get; set; }

        [Display(Name = "Medida")]
        public string medida_combustible { get; set; }

        [Display(Name = "Unidad de Medida para el Aceite")]
        public string medida_aceite { get; set; }

        [Display(Name = "Cant Combustible")]
        [DefaultValue(1)]
        public int combustible { get; set; }

        [Display(Name = "Aceite Motor")]
        public int aceite_motor { get; set; }

        [Display(Name = "Aceite Caja")]
        public int aceite_caja { get; set; }

        [Display(Name = "Aceite Traccion Delantera")]
        public int aceite_delantera { get; set; }

        [Display(Name = "Aceite Traccion Trasera")]
        public int aceite_trasera { get; set; }

        [Display(Name = "Aceite Hidraulico")]
        public int aceite_hidraulico { get; set; }

        [Display(Name = "Catalizador")]
        public string catalizador { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Tipo de Activo")]
        public string tipo { get; set; }

        [Display(Name = "Planta")]
        public int id_planta { get; set; }

        [Display(Name = "Estado Logico")]
        public string estadoBL { get; set; }

    }//fin de clase

    //public enum Identificador
    //{
    //    Activo,
    //    Placa
    //}
}//fin del namespace