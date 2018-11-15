using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class Hallazgo
    {

        public int id_Hallazgo { get; set; }

        public string HallazgoD { get; set; }

        public string Referencia { get; set; }

        public string Estado { get; set; }

        public string Solucion { get; set; }

    }//class
}//namespace