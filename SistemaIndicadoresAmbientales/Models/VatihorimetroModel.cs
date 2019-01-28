using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SistemaIndicadoresAmbientales.Models
{

    public class VatihorimetroModel
    {

        private SqlConnection connection;

        public VatihorimetroModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearVatihorimetro(Entity.Vatihorimetro vatihorimetro,int planta)
        {
            SqlCommand cmd = new SqlCommand("sp_crearVatihorimetro", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Numero_Vatihorimetro", vatihorimetro.Numero_Vatihorimetro);
            cmd.Parameters.AddWithValue("@Nombre_Medidor", vatihorimetro.Nombre_Medidor);
            cmd.Parameters.AddWithValue("@NISE", vatihorimetro.NISE);
            cmd.Parameters.AddWithValue("@Localizacion", vatihorimetro.Localizacion);
            cmd.Parameters.AddWithValue("@Id_planta", planta);
            cmd.Parameters.AddWithValue("@EstadoBL", "A");


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un vatihorimetro en el sistema

        public List<Entity.Vatihorimetro> obtenerVatihorimetroPorPlanta(int id_planta)
        {
            List<Entity.Vatihorimetro> vatihorimetro = new List<Entity.Vatihorimetro>();

            SqlCommand cmd = new SqlCommand("sp_obtenerVatihorimetroPorPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            cmd.Parameters.AddWithValue("@Id_planta",id_planta);
            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                vatihorimetro.Add(
                    new Entity.Vatihorimetro
                    {
                        Id_Vatihorimetro = Convert.ToInt32(dr["Id_Vatihorimetro"]),
                        Numero_Vatihorimetro = Convert.ToInt32(dr["Numero_Vatihorimetro"]),
                        Nombre_Medidor = Convert.ToString(dr["Nombre_Medidor"]),
                        NISE = Convert.ToInt32(dr["NISE"]),
                        Localizacion = Convert.ToInt64(dr["Localizacion"]),
                        Id_Planta = Convert.ToInt32(dr["Id_Planta"])
                    });
            }//end foreach
            return vatihorimetro;
        }//obtener todas los vatihorimetros del sistemas.


        public List<Entity.Vatihorimetro> obtenerVatihorimetros()
        {
            List<Entity.Vatihorimetro> vatihorimetro = new List<Entity.Vatihorimetro>();

            SqlCommand cmd = new SqlCommand("sp_obtenerVatihorimetros", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                vatihorimetro.Add(
                    new Entity.Vatihorimetro
                    {
                        Id_Vatihorimetro = Convert.ToInt32(dr["Id_Vatihorimetro"]),
                        Numero_Vatihorimetro = Convert.ToInt32(dr["Numero_Vatihorimetro"]),
                        Id_Planta = Convert.ToInt32(dr["Id_Planta"])
                    });
            }//end foreach
            return vatihorimetro;
        }//obtener todas los vatihorimetros del sistemas.


        public bool actualizarVatihorimetro(Entity.Vatihorimetro vatihorimetro)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarVatihorimetro", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Planta", vatihorimetro.Id_Planta);
            cmd.Parameters.AddWithValue("@Id_Vatihorimetro", vatihorimetro.Id_Vatihorimetro);
            cmd.Parameters.AddWithValue("@Numero_Vatihorimetro", vatihorimetro.Numero_Vatihorimetro);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos un planta

        public bool EliminarVatihorimetro(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarVatihorimetro", connection);
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