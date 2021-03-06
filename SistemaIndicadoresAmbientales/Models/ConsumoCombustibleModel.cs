﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace SistemaIndicadoresAmbientales.Models
{
    public class ConsumoCombustibleModel
    {
        private SqlConnection connection;

        public ConsumoCombustibleModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public List<Entity.ConsumoCombustible> obtenerConsumoCombustible()
        {
            List<Entity.ConsumoCombustible> consumos = new List<Entity.ConsumoCombustible>();

            SqlCommand cmd = new SqlCommand("sp_listar_consumo_combustible", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumos.Add(
                    new Entity.ConsumoCombustible
                    {
                        id_consumo = Convert.ToInt32(dr["id_consumo"]),
                        cant_combustible = Convert.ToInt32(dr["cant_combustible"]),
                        factura = Convert.ToString(dr["factura"]),
                        fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
                        fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        tipo = Convert.ToString(dr["tipo"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"])
                    });
            }
            return consumos;
        }//obtener todas los consunos de combustible (TODOS LOS EQUIPOS).

        public bool crearConsumoCombustible(Entity.ConsumoCombustible consumo, string vehiculo)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_consumo_combustible_vehiculos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cant_combustible", consumo.cant_combustible);
            cmd.Parameters.AddWithValue("@factura", consumo.factura);
            cmd.Parameters.AddWithValue("@fecha_factura", consumo.fecha_factura);
            cmd.Parameters.AddWithValue("@fecha_registro", consumo.fecha_registro);
            cmd.Parameters.AddWithValue("@id_activo_placa", vehiculo);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo de combustible al sistema (vehiculos)

        public List<Entity.ConsumoCombustible> obtenerConsumoCombustibleVehiculos()
        {
            List<Entity.ConsumoCombustible> consumos = new List<Entity.ConsumoCombustible>();

            SqlCommand cmd = new SqlCommand("sp_listar_consumo_combustible_vehiculos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumos.Add(
                    new Entity.ConsumoCombustible
                    {
                        id_consumo = Convert.ToInt32(dr["id_consumo"]),
                        cant_combustible = Convert.ToInt32(dr["cant_combustible"]),
                        factura = Convert.ToString(dr["factura"]),
                        fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
                        fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        tipo = Convert.ToString(dr["tipo"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"])
                    });
            }
            return consumos;
        }//obtener todas los consunos de combustible (vehiculos).


        public bool crearConsumoCombustibleEqMenor(Entity.ConsumoCombustible consumo, string eq_menor)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_consumo_combustible_eq_menor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cant_combustible", consumo.cant_combustible);
            cmd.Parameters.AddWithValue("@factura", consumo.factura);
            cmd.Parameters.AddWithValue("@fecha_factura", consumo.fecha_factura);
            cmd.Parameters.AddWithValue("@fecha_registro", consumo.fecha_registro);
            cmd.Parameters.AddWithValue("@id_activo_placa", eq_menor);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo de combustible al sistema (eqMenor)


        public List<Entity.ConsumoCombustible> obtenerConsumoCombustibleEqMenor()
        {
            List<Entity.ConsumoCombustible> consumos = new List<Entity.ConsumoCombustible>();

            SqlCommand cmd = new SqlCommand("sp_listar_consumo_combustible_eq_menor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumos.Add(
                    new Entity.ConsumoCombustible
                    {
                        id_consumo = Convert.ToInt32(dr["id_consumo"]),
                        cant_combustible = Convert.ToInt32(dr["cant_combustible"]),
                        factura = Convert.ToString(dr["factura"]),
                        fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
                        fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        tipo = Convert.ToString(dr["tipo"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"])
                    });
            }
            return consumos;
        }//obtener todas los consunos de combustible (Equipo menor).

                                                                                        ///aqui pa abajo
        public bool crearConsumoCombustibleMaquinaria(Entity.ConsumoCombustible consumo, string eq_menor)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_consumo_combustible_maquinaria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cant_combustible", consumo.cant_combustible);
            cmd.Parameters.AddWithValue("@factura", consumo.factura);
            cmd.Parameters.AddWithValue("@fecha_factura", consumo.fecha_factura);
            cmd.Parameters.AddWithValue("@fecha_registro", consumo.fecha_registro);
            cmd.Parameters.AddWithValue("@id_activo_placa", eq_menor);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo de combustible al sistema (Maquinaria)


        public List<Entity.ConsumoCombustible> obtenerConsumoCombustibleMaquinaria()
        {
            List<Entity.ConsumoCombustible> consumos = new List<Entity.ConsumoCombustible>();

            SqlCommand cmd = new SqlCommand("sp_listar_consumo_combustible_maquinaria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumos.Add(
                    new Entity.ConsumoCombustible
                    {
                        id_consumo = Convert.ToInt32(dr["id_consumo"]),
                        cant_combustible = Convert.ToInt32(dr["cant_combustible"]),
                        factura = Convert.ToString(dr["factura"]),
                        fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
                        fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        tipo = Convert.ToString(dr["tipo"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"])
                    });
            }
            return consumos;
        }//obtener todas los consunos de combustible (Maquinaria).

    }//class
}//namespacee