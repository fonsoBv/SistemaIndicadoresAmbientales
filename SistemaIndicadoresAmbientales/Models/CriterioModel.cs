using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaIndicadoresAmbientales.Models
{
    public class CriterioModel
    {
        private SqlConnection connection;

        public CriterioModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearCriterio(Entity.Criterio criterio, int inspeccion)
        {
            SqlCommand cmd = new SqlCommand("sp_crearCriterio", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", criterio.Nombre);
            cmd.Parameters.AddWithValue("@Id_Evaluacion", inspeccion);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Crear un nuevo Criterio

        public List<Entity.Criterio> obtenerCriterio()
        {
            List<Entity.Criterio> criterios = new List<Entity.Criterio>();

            SqlCommand cmd = new SqlCommand("sp_obtenerCriterio", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                criterios.Add(
                    new Entity.Criterio
                    {
                        id_Criterio = Convert.ToInt32(dr["Id_MacroTema"]),
                        Nombre = Convert.ToString(dr["MacroTema"]),
                        id_Inspeccion = Convert.ToInt32(dr["Id_Evaluacion"]),
                    });
            }
            return criterios;
        }//obtener los Criterio

        public bool actualizarCriterio(Entity.Criterio criterio)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarCriterio", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Criterio", criterio.id_Criterio);
            cmd.Parameters.AddWithValue("@Nombre", criterio.Nombre);
            cmd.Parameters.AddWithValue("@Id_inspeccion", criterio.id_Inspeccion);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar el criterio

        public bool EliminarCriterio(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarCriterio", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//Eliminar Criterio

        public List<Entity.Criterio> obtenerCriterioInspeccion(int id_inspeccion)
        {
            List<Entity.Criterio> criterios = new List<Entity.Criterio>();

            SqlCommand cmd = new SqlCommand("sp_obtenerCriterioInspeccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Inspeccion", id_inspeccion);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                criterios.Add(
                    new Entity.Criterio
                    {
                        id_Criterio = Convert.ToInt32(dr["Id_MacroTema"]),
                        Nombre = Convert.ToString(dr["MacroTema"]),
                        id_Inspeccion = Convert.ToInt32(dr["Id_Evaluacion"]),
                    });
            }
            return criterios;
        }//obtenerCriterioInspeccion

    }//class
}//namespace