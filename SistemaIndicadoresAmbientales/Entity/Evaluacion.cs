using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Evaluacion
    {

        public string NombrePlanta { get; set; }

        public int id_Macrotema { get; set; }

        
        public string Macrotema { get; set; }

        
        public string Cumple { get; set; }

        
        public string Hallazgo { get; set; }

        public string Diapositiva { get; set; }
    }//class
}//namespace