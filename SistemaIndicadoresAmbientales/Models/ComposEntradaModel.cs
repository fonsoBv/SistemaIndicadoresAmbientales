using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Models
{
    public class CompostEntradaModel
    {
        private SqlConnection connection;

        public CompostEntradaModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearCompostEntrada(Entity.Entrada consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crearCompostEntrada", connection);
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

        public List<Entity.HistoricoCompost> obtenerHistoricoCompostAnual(int Anio1, int Anio2)
        {
            List<Entity.HistoricoCompost> consumoshistorico = new List<Entity.HistoricoCompost>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerHistoricoCompostAnual", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Anio1", Anio1);
            cmd.Parameters.AddWithValue("@Anio2", Anio2);



            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumoshistorico.Add(new Entity.HistoricoCompost
                {
                    Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                    Anio = Convert.ToInt32(dr["Anio"]),
                    Mes = Convert.ToInt32(dr["Mes"]),
                });
            }
            return consumoshistorico;

        }//end historico Agua Anual
        public List<Entity.Entrada> obtenerCompostEntradas()
        {
            List<Entity.Entrada> compostEntradas = new List<Entity.Entrada>();

            SqlCommand cmd = new SqlCommand("sp_obtenerCompostEntradas", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                compostEntradas.Add(
                    new Entity.Entrada
                    {
                        Id_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost_Entrada"]),
                        Cantidad = Convert.ToInt64(dr["Cantidad"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Medida = Convert.ToString(dr["Medida"]),
                        Id_Planta = Convert.ToInt32(dr["Id_Planta"]),
                    });
            }
            return compostEntradas;
        }//obtener todas los consunos de agua del sistemas.


        public List<Entity.ConsumoEntradaActualizar> obtenerConsumosActualizarEntrada(int mes, int planta)
        {
            List<Entity.ConsumoEntradaActualizar> consumosEntrada = new List<Entity.ConsumoEntradaActualizar>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerActualizar_ConsumoEntrada", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();
            DateTime dateTemp = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {

                dateTemp = Convert.ToDateTime(dr["Fecha"]).Date;
                if (dateTemp.Day < 10 && dateTemp.Month < 10)
                {

                    consumosEntrada.Add(new Entity.ConsumoEntradaActualizar
                    {
                        Id_Consumo_Compost_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-0" + dateTemp.Month + "-0" + dateTemp.Day,
                    });

                }
                else if (dateTemp.Month < 10)
                {

                    consumosEntrada.Add(new Entity.ConsumoEntradaActualizar
                    {
                        Id_Consumo_Compost_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-0" + dateTemp.Month + "-" + dateTemp.Day,
                    });

                }
                else if (dateTemp.Day < 10)
                {
                    consumosEntrada.Add(new Entity.ConsumoEntradaActualizar
                    {
                        Id_Consumo_Compost_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-" + dateTemp.Month + "-0" + dateTemp.Day,
                    });

                }
                else
                {
                    consumosEntrada.Add(new Entity.ConsumoEntradaActualizar
                    {
                        Id_Consumo_Compost_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = dateTemp.Year + "-" + dateTemp.Month + "-" + dateTemp.Day,
                    });

                }//end if-else
            }//end foreach

            return consumosEntrada;
        }//obtener un solo comsumo de agua específico

        public bool actualizarConsumoCompostEntrada(int Cantidad, int Id_Consumo_Agua)
        {
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Compost_Entrada", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Consumo_Compost_Entrada", Id_Consumo_Agua);
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
