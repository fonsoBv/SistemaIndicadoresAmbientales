using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

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

        public int guardarEvaluacion(int IdMacroTema, string NombreMacroTema, string CumpleMacroTema, int Planta, int Evaluacion, string Fecha)
        {
            SqlCommand cmd = new SqlCommand("sp_guardarEvaluacion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_MacroTema", IdMacroTema);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);
            cmd.Parameters.AddWithValue("@Id_Planta", Planta);
            cmd.Parameters.AddWithValue("@Cumple", CumpleMacroTema);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();
            int Id_Evaluacion_MacroTema = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Id_Evaluacion_MacroTema = Convert.ToInt32(dr["Id_Evaluacion_MacroTema"]);
            }//foreach
            return Id_Evaluacion_MacroTema;
        }//guardarEvaluacion

        public bool guardarHallazgo(string Hallazgo, int IdMacroTema, int IdEvaluacionMacrotema)
        {
            SqlCommand cmd = new SqlCommand("sp_guardarHallazgo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Hallazgo", Hallazgo);
            cmd.Parameters.AddWithValue("@Id_MacroTema", IdMacroTema);
            cmd.Parameters.AddWithValue("@Id_Evaluacion_MacroTema", IdEvaluacionMacrotema);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//guardarHallazgo

        public List<Entity.Evaluacion> obtenerEvaluacion(int id_inspeccion, int id_planta, string fecha)
        {
            List<Entity.Evaluacion> evaluacionMacrotemas = new List<Entity.Evaluacion>();

            SqlCommand cmd = new SqlCommand("sp_obtenerEvaluacion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_inspeccion", id_inspeccion);
            cmd.Parameters.AddWithValue("@id_planta", id_planta);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                evaluacionMacrotemas.Add(
                    new Entity.Evaluacion
                    {
                        id_Macrotema = Convert.ToInt32(dr["Id_MacroTema"]),
                        Macrotema = Convert.ToString(dr["MacroTema"]),
                        Cumple = Convert.ToString(dr["Cumple"]),
                        hallazgo = Convert.ToString(dr["Hallazgo"])
                    });
            }
            return evaluacionMacrotemas;
        }//obtenerEvaluacion

    }//class
}//namespace