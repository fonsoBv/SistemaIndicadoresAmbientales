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


        public Entity.Salida obtenerCompostSalida(DateTime fecha)
        {
            Entity.Salida consumoSalidas = new Entity.Salida();

            SqlCommand cmd = new SqlCommand("sp_obtenerCompostSalida", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", fecha);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumoSalidas = new Entity.Salida
                {
                    Id_Salida = Convert.ToInt32(dr["Id_Consumo_Compost_Salida"]),
                    Cantidad = Convert.ToInt64(dr["Cantidad"]),
                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                    Medida = Convert.ToString(dr["Medida"]),
                    Id_Planta = Convert.ToInt32(dr["Id_Planta"]),
                };
            }
            return consumoSalidas;
        }//obtener un solo comsumo electrico específico

        public bool actualizarCompostSalida(Entity.Salida consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarCompostSalida", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Consumo_Compost_Salida", consumo.Id_Salida);
            cmd.Parameters.AddWithValue("@Cantidad", consumo.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", consumo.Fecha);
            cmd.Parameters.AddWithValue("@Medida", consumo.Medida);
            cmd.Parameters.AddWithValue("@Id_Planta", consumo.Id_Planta);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos de un consumo electrico
    }//end class
}//end namespace