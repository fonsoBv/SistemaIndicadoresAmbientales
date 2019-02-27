using System;

namespace SistemaIndicadoresAmbientales.Entity
{
    public class HistoricoAgua
    {
        public int Id_Consumo_Agua { get; set; }
        public int Anio { get; set; }
        public int Numero_Hidrometro { get; set; }
        public decimal Cantidad { get; set; }
        public int Mes { get; set; }

    }//end class
}//end namespcae