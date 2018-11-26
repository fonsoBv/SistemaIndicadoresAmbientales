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
    public class UsuarioModel
    {
        private SqlConnection connection;

        public UsuarioModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool actualziarUsuario(string correo, string contrasena)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//UsuarioPlanta

        public List<Entity.Usuario> obtenerUsuario()
        {
            List<Entity.Usuario> usuarios = new List<Entity.Usuario>();

            SqlCommand cmd = new SqlCommand("sp_obtenerUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();
       
            foreach (DataRow dr in dt.Rows)
            {
                usuarios.Add(
                   new Entity.Usuario
                   {
                       Nombre = Convert.ToString(dr["Nombre"]),
                       Correo = Convert.ToString(dr["Correo"]),
                       Contrasena = Convert.ToString(dr["Contrasena"])
                   });
            }//foreach
            return usuarios;
        }//obtenerUsuarioPlanta

    }//emnd class

}//end namespace