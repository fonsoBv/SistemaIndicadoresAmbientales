using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaIndicadoresAmbientales.Models
{
    public class InspeccionModel
    {

        private SqlConnection connection;

        public InspeccionModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearInspeccion(Entity.Inspeccion inspeccion)
        {
            SqlCommand cmd = new SqlCommand("sp_crearInspeccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", inspeccion.Nombre);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Crear una nueva inspeccion

        public List<Entity.Inspeccion> obtenerInspeccion()
        {
            List<Entity.Inspeccion> inspecciones = new List<Entity.Inspeccion>();

            SqlCommand cmd = new SqlCommand("sp_obtenerInspeccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                inspecciones.Add(
                    new Entity.Inspeccion
                    {
                        id_Inspeccion = Convert.ToInt32(dr["Id_Evaluacion"]),
                        Nombre = Convert.ToString(dr["Nombre"]),
                    });
            }
            return inspecciones;
        }//obtener las inpecciones

        public bool actualizarInspeccion(Entity.Inspeccion inspeccion)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarInspeccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Inspeccion", inspeccion.id_Inspeccion);
            cmd.Parameters.AddWithValue("@Nombre", inspeccion.Nombre);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar la inspeccion

        public bool EliminarInspeccion(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarInspeccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//Eliminar Inspeccion

    }//class
}//namespace