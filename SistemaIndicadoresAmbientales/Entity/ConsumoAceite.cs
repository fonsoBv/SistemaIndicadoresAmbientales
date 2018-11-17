using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class ConsumoAceite
    {
        public int id_consumo { get; set; }
        public float cant_motor { get; set; }
        public float cant_caja { get; set; }
        public float cant_delantera { get; set; }
        public float cant_trasera { get; set; }
        public float cant_hidraulico { get; set; }
        public string factura { get; set; }
        public DateTime fecha_factura { get; set; }
        public DateTime fecha_registro { get; set; }
        public string tipo { get; set; }
        public string id_activo_placa { get; set; }
    }
}