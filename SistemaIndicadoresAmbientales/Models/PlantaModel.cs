using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SistemaIndicadoresAmbientales.Models
{

    public class PlantaModel
    {

        private SqlConnection connection;

        public PlantaModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearPlanta(Entity.Planta planta)
        {
            SqlCommand cmd = new SqlCommand("sp_crearPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", planta.nombre);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un planta en el sistema

        public List<Entity.Planta> obtenerPlantas()
        {
            List<Entity.Planta> plantas = new List<Entity.Planta>();

            SqlCommand cmd = new SqlCommand("sp_obtenerPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                plantas.Add(
                    new Entity.Planta
                    {
                        id = Convert.ToInt32(dr["Id_Planta"]),
                        nombre = Convert.ToString(dr["Nombre"]),
                    });
            }
            return plantas;
        }//obtener todas las plantas del sistemas.

        public bool actualizarPlanta(Entity.Planta planta)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", planta.id);
            cmd.Parameters.AddWithValue("@Nombre", planta.nombre);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos un planta

        public bool EliminarPlanta(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//EliminarPlanta

        public bool UsuarioPlanta(string correo, int planta)
        {
            SqlCommand cmd = new SqlCommand("sp_usuarioPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//UsuarioPlanta

        public int obtenerUsuarioPlanta(string email)
        {
            SqlCommand cmd = new SqlCommand("sp_obtenerUsuarioPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            int Id_Planta = -1;
            foreach (DataRow dr in dt.Rows)
            {
                Id_Planta = Convert.ToInt32(dr["Id_Planta"]);
            }//foreach
            return Id_Planta;
        }//obtenerUsuarioPlanta

    }//emnd class


}//end namespace