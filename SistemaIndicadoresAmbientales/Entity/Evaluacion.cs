using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Evaluacion
    {
        
        public int id_Macrotema { get; set; }

        
        public string Macrotema { get; set; }

        
        public string Cumple { get; set; }

        
        public string hallazgo { get; set; }

    }//class
}//namespace