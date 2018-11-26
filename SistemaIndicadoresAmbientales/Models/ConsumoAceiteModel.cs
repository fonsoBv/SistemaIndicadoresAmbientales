using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace SistemaIndicadoresAmbientales.Models
{
    public class ConsumoAceiteModel
    {
        private SqlConnection connection;

        public ConsumoAceiteModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearConsumoAceiteVehiculo(Entity.ConsumoAceite consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_consumo_aceite_vehiculos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cant_motor", consumo.cant_motor);
            cmd.Parameters.AddWithValue("@cant_caja", consumo.cant_caja);
            cmd.Parameters.AddWithValue("@cant_delantera", consumo.cant_delantera);
            cmd.Parameters.AddWithValue("@cant_trasera", consumo.cant_trasera);
            cmd.Parameters.AddWithValue("@cant_hidraulico", consumo.cant_hidraulico);
            cmd.Parameters.AddWithValue("@factura", consumo.factura);
            cmd.Parameters.AddWithValue("@fecha_factura", consumo.fecha_factura);
            cmd.Parameters.AddWithValue("@fecha_registro", consumo.fecha_registro);
            cmd.Parameters.AddWithValue("@id_activo_placa", consumo.id_activo_placa);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo de aceite al sistema

        public List<Entity.ConsumoAceite> obtenerConsumoAceiteVehiculos()
        {
            List<Entity.ConsumoAceite> consumos = new List<Entity.ConsumoAceite>();

            SqlCommand cmd = new SqlCommand("sp_listar_consumo_aceite_vehiculos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumos.Add(
                    new Entity.ConsumoAceite
                    {
                        id_consumo = Convert.ToInt32(dr["id_consumo"]),
                        cant_motor = Convert.ToInt32(dr["cant_motor"]),
                        cant_caja = Convert.ToInt32(dr["cant_caja"]),
                        cant_delantera = Convert.ToInt32(dr["cant_delantera"]),
                        cant_trasera = Convert.ToInt32(dr["cant_trasera"]),
                        cant_hidraulico = Convert.ToInt32(dr["cant_hidraulico"]),
                        factura = Convert.ToString(dr["factura"]),
                        fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
                        fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        tipo = Convert.ToString(dr["tipo"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"])
                    });
            }
            return consumos;
        }//obtener los consumos de aceite de los vehiculos del sistemas.
    }
}