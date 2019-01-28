namespace SistemaIndicadoresAmbientales.Entity
{
    public class HistoricoElectrico
    {
        public int Id_Consumo_Electrico { get; set; }
        public int Anio { get; set; }
        public int Numero_Vatihorimetro { get; set; }
        public decimal Cantidad { get; set; }
        public int Mes { get; set; }
    }//end class

}//end namespace