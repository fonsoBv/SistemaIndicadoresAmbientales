using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Models
{
    public class ConsumodeAguaModel
    {
        private SqlConnection connection;

        public ConsumodeAguaModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearConsumoAgua(Entity.ConsumodeAgua consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crearConsumoAgua", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Hidrometro", consumo.Id_Hidrometro);
            cmd.Parameters.AddWithValue("@Medidad", consumo.Medida);
            cmd.Parameters.AddWithValue("@Cantidad", consumo.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", consumo.Fecha);
            cmd.Parameters.AddWithValue("@Mes", consumo.Mes);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un planta en el sistema

        public List<Entity.ConsumodeAgua> obtenerConsumosdeAgua()
        {
            List<Entity.ConsumodeAgua> consumosdeAgua = new List<Entity.ConsumodeAgua>();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumosdeAgua", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosdeAgua.Add(
                    new Entity.ConsumodeAgua
                    {
                        Id_Consumo_Agua = Convert.ToInt32(dr["id_Consumo_Agua"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Id_Hidrometro = Convert.ToInt32(dr["id_Hidrometro"]),
                        Medida = Convert.ToString(dr["Medida"])
                    });
            }
            return consumosdeAgua;
        }//obtener todas los consunos de agua del sistemas.


        public List<Entity.HistoricoAgua> obtenerHistoricoAgua(int planta,int Mes,int Anio)
        {
            List<Entity.HistoricoAgua> consumoshistorico = new List<Entity.HistoricoAgua>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerHistoricoAguaPorPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Planta", planta);
            cmd.Parameters.AddWithValue("@MesIN", Mes);
            cmd.Parameters.AddWithValue("@Anio", Anio);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumoshistorico.Add(new Entity.HistoricoAgua
                {
                    Id_Consumo_Agua = Convert.ToInt32(dr["Id_ConsumoAgua"]),
                    Cantidad = Convert.ToInt64(dr["Cantidad"]),
                    Fecha = new DateTime(Convert.ToDateTime(dr["Fecha"]).Year, Convert.ToDateTime(dr["Fecha"]).Month, Convert.ToDateTime(dr["Fecha"]).Day).ToString(),
                    Mes = Convert.ToInt32(dr["Mes"]),
                });
            }
            return consumoshistorico;

        }

        public Entity.ConsumodeAgua obtenerConsumodeAgua(DateTime fecha, int mes)
        {
            Entity.ConsumodeAgua consumosdeAgua = new Entity.ConsumodeAgua();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumodeAgua", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@mes", mes);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosdeAgua = new Entity.ConsumodeAgua
                {
                    Id_Consumo_Agua = Convert.ToInt32(dr["id_Consumo_Agua"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    Fecha = Convert.ToDateTime(dr["fecha"]),
                    Id_Hidrometro = Convert.ToInt32(dr["id_Hidrometro"]),
                    Medida = Convert.ToString(dr["Medida"])
                };
            }
            return consumosdeAgua;
        }//obtener un solo comsumo de agua específico



        public List<Entity.ConsumoAguaActualizar> obtenerConsumosActualizarAgua(int mes, int planta)
        {
            List<Entity.ConsumoAguaActualizar> consumosdeAgua = new List<Entity.ConsumoAguaActualizar>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerActualizar_ConsumoAgua", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosdeAgua.Add(new Entity.ConsumoAguaActualizar
                {
                    Id_Consumo_Agua = Convert.ToInt32(dr["id_Consumo_Agua"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    Numero_Hidrometro = Convert.ToInt32(dr["Numero_Hidrometro"]),
                });
            }
            return consumosdeAgua;
        }//obtener un solo comsumo de agua específico





        public bool actualizarConsumodeAgua(int Cantidad,int Id_Consumo_Agua)
        {
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Consumo_Agua", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Consumo_Agua", Id_Consumo_Agua);
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos de un consumo de agua

        public bool EliminarConsumodeAgua(int id, DateTime fecha)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarConsumodeAgua", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_Consumo_Agua", id);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//eliminar consumo de agua

    }//emnd class

}//end namespace
