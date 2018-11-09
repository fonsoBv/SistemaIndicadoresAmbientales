using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Consumo_Combustible
    {
        public int Id_Consumo_Combustible { get; set; }
        public float Cant_Aceite_Motor { get; set; }
        public float Cant_Aceite_Caja { get; set; }
        public float Cant_Aceite_Delantera { get; set; }
        public float Cant_Aceite_Trasera { get; set; }
        public float Cant_Aceite_Hidraulico { get; set; }
        public float Cant_Combustible { get; set; }
        public DateTime Fecha_Factura { get; set; }
        public String Tipo { get; set; }
        public int Id_Activo_Placa { get; set; }
        
    }//end class
}// end namesapce