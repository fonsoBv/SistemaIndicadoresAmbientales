using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Models
{
    public class CompostSalidaModel
    {
        private SqlConnection connection;

        public CompostSalidaModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearCompostSalida(Entity.Salida consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crearCompostSalida", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Medida", consumo.Medida);
            cmd.Parameters.AddWithValue("@Cantidad", consumo.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", consumo.Fecha);
            cmd.Parameters.AddWithValue("@Id_Planta", consumo.Id_Planta);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo electrico en el sistema

        public List<Entity.Salida> obtenerCompostSalidas()
        {
            List<Entity.Salida> compostSalidas = new List<Entity.Salida>();

            SqlCommand cmd = new SqlCommand("sp_obtenerCompostSalidas", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                compostSalidas.Add(
                    new Entity.Salida
                    {
                        Id_Salida = Convert.ToInt32(dr["Id_Consumo_Compost_Salida"]),
                        Cantidad = Convert.ToInt64(dr["Cantidad"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Medida = Convert.ToString(dr["Medida"]),
                        Id_Planta = Convert.ToInt32(dr["Id_Planta"]),
                    });
            }
            return compostSalidas;
        }//obtener todas los consunos de agua del sistemas.


   
        public List<Entity.ConsumoSalidaActualizar> obtenerConsumosActualizarSalida(int mes, int planta)
        {
            List<Entity.ConsumoSalidaActualizar> consumoSalida = new List<Entity.ConsumoSalidaActualizar>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerActualizar_ConsumoSalida", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();
            DateTime dateTemp = new DateTime();
            foreach (DataRow dr in dt.Rows){
                dateTemp = Convert.ToDateTime(dr["Fecha"]).Date;
                if (dateTemp.Day < 10 && dateTemp.Month < 10){
                    consumoSalida.Add(new Entity.ConsumoSalidaActualizar{
                        Id_Consumo_Compost_Salida = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-0" + dateTemp.Month + "-0" + dateTemp.Day,
                    });
                }else if (dateTemp.Month < 10){
                    consumoSalida.Add(new Entity.ConsumoSalidaActualizar
                    {
                        Id_Consumo_Compost_Salida = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-0" + dateTemp.Month + "-" + dateTemp.Day,
                    });
                }
                else if (dateTemp.Day < 10){
                    consumoSalida.Add(new Entity.ConsumoSalidaActualizar
                    {
                        Id_Consumo_Compost_Salida = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-" + dateTemp.Month + "-0" + dateTemp.Day,
                    });
                }
                else{
                    consumoSalida.Add(new Entity.ConsumoSalidaActualizar
                    {
                        Id_Consumo_Compost_Salida = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-" + dateTemp.Month + "-" + dateTemp.Day,
                    });
                }//end if-else
            }//end foreach

            return consumoSalida;
        }//obtener un solo comsumo de agua específico

        public bool actualizarConsumoCompostSalida(int Cantidad, int Id_Consumo_Salida)
        {
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Compost_Salida", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Consumo_Compost_Salida", Id_Consumo_Salida);
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos de un consumo de agua

    }//end class
}//end namespace