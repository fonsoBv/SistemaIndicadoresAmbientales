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


        public Entity.Entrada obtenerCompostEntrada(DateTime fecha)
        {
            Entity.Entrada consumosEntradas = new Entity.Entrada();

            SqlCommand cmd = new SqlCommand("sp_obtenerCompostEntrada", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", fecha);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosEntradas = new Entity.Entrada
                {
                    Id_Entrada = Convert.ToInt32(dr["Id_Consumo_Compost_Entrada"]),
                    Cantidad = Convert.ToInt64(dr["Cantidad"]),
                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                    Medida = Convert.ToString(dr["Medida"]),
                    Id_Planta = Convert.ToInt32(dr["Id_Planta"]),
                };
            }
            return consumosEntradas;
        }//obtener un solo comsumo electrico específico

        public bool actualizarCompostEntrada(Entity.Entrada consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarCompostEntrada", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Consumo_Compost_Entrada", consumo.Id_Entrada);
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
