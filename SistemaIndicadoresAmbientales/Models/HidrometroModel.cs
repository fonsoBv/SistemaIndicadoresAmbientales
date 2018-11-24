using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Models
{
    public class HidrometroModel
    {
        private SqlConnection connection;

        public HidrometroModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearHidrometro(Entity.Hidrometro hidrometro, int planta)
        {
            SqlCommand cmd = new SqlCommand("sp_crearHidrometro", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Numero_Hidrometro", hidrometro.Numero_Hidrometro);
            cmd.Parameters.AddWithValue("@NISE", hidrometro.NISE);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);
            cmd.Parameters.AddWithValue("@EstadoBl", "A");


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un vatihorimetro en el sistema

        public List<Entity.Hidrometro> obtenerHidrometrosPorPlanta(int id_planta)
        {
            List<Entity.Hidrometro> hidrometro = new List<Entity.Hidrometro>();

            SqlCommand cmd = new SqlCommand("sp_obtenerHidrometroPorPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("@Id_planta", id_planta);
            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                hidrometro.Add(
                     new Entity.Hidrometro
                     {
                         Id_Hidrometro = Convert.ToInt32(dr["Id_Hidrometro"]),
                         Numero_Hidrometro = Convert.ToInt32(dr["Numero_Hidrometro"]),
                         NISE = Convert.ToInt32(dr["NISE"]),
                         Id_Planta = Convert.ToInt32(dr["Id_Planta"])
                     });
            }//end foreach
            return hidrometro;
        }//obtener todas los vatihorimetros del sistemas.



        public List<Entity.Hidrometro> obtenerHidrometros()
        {
            List<Entity.Hidrometro> hidrometro = new List<Entity.Hidrometro>();

            SqlCommand cmd = new SqlCommand("sp_obtenerHidrometros", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                hidrometro.Add(
                     new Entity.Hidrometro
                     {
                         Id_Hidrometro = Convert.ToInt32(dr["Id_Hidrometro"]),
                         Numero_Hidrometro = Convert.ToInt32(dr["Numero_Hidrometro"]),
                         Id_Planta = Convert.ToInt32(dr["Id_Planta"])
                     });
            }//end foreach
            return hidrometro;
        }//obtener todas los vatihorimetros del sistemas.



        public bool actualizarHidrometro(Entity.Hidrometro hidrometro)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarHidrometro", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Numero_Hidrometro", hidrometro.Numero_Hidrometro);
            cmd.Parameters.AddWithValue("@NISE", hidrometro.NISE);
            cmd.Parameters.AddWithValue("@Id_Planta", hidrometro.Id_Planta);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos un planta

        public bool EliminarHidrometro(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarHidrometro", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//EliminarVatihorimetro

    }//end class
}//end namespace