using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class HistoricoCompost
    {

        public int Id_Compost { get; set; }
        public int Anio { get; set; }
        public decimal Cantidad { get; set; }
        public int Mes { get; set; }

    }
}