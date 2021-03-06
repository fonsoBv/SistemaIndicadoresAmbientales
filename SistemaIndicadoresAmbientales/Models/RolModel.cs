﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaIndicadoresAmbientales.Models
{
    public class RolModel
    {

        private SqlConnection connection;

        public RolModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public List<Entity.Rol> obtenerRol()
        {
            List<Entity.Rol> roles = new List<Entity.Rol>();

            SqlCommand cmd = new SqlCommand("sp_obtenerRol", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                roles.Add(
                    new Entity.Rol
                    {
                        Id_Rol = Convert.ToInt32(dr["Id_Rol"]),
                        Nombre = Convert.ToString(dr["Nombre"]),
                    });
            }
            return roles;
        }//obtenerRol.

        public string obtenerRolUsuario(string email)
        {
            SqlCommand cmd = new SqlCommand("sp_obtenerRolUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            string rol = "";
            foreach (DataRow dr in dt.Rows)
            {
                rol = Convert.ToString(dr["Nombre"]);
            }//foreach

            return rol;
        }//obtenerRolUsuario.

    }//class
}//namespace