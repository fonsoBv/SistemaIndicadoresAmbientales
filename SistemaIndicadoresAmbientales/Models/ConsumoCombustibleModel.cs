using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

        public bool crearConsumoCombustible(Entity.Consumo_Combustible consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crearConsumoCombustible", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Consumo_Combustible", consumo.Id_Consumo_Combustible);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Motor", consumo.Cant_Aceite_Motor);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Caja", consumo.Cant_Aceite_Caja);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Delantera", consumo.Cant_Aceite_Delantera);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Trasera", consumo.Cant_Aceite_Trasera);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Hidraulico", consumo.Cant_Aceite_Hidraulico);
            cmd.Parameters.AddWithValue("@Cant_Combustible", consumo.Cant_Combustible);

            cmd.Parameters.AddWithValue("@Fecha_Factura", consumo.Fecha_Factura);
            cmd.Parameters.AddWithValue("@Tipo", consumo.Tipo);
            cmd.Parameters.AddWithValue("@Id_Activo_Placa", consumo.Id_Activo_Placa);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un planta en el sistema

        public List<Entity.Consumo_Combustible> obtenerConsumosCombustible()
        {
            List<Entity.Consumo_Combustible> consumosCombustible = new List<Entity.Consumo_Combustible>();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumosCombustibles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosCombustible.Add(
                    new Entity.Consumo_Combustible
                    {
                        Id_Consumo_Combustible = Convert.ToInt32(dr["Id_Consumo_Combustible"]),
                        Cant_Aceite_Motor = Convert.ToInt32(dr["Cant_Aceite_Motor"]),
                        Cant_Aceite_Caja = Convert.ToInt32(dr["Cant_Aceite_Caja"]),
                        Cant_Aceite_Hidraulico = Convert.ToInt32(dr["Cant_Aceite_Hidraulico"]),
                        Cant_Aceite_Delantera= Convert.ToInt32(dr["Cant_Aceite_Delantera"]),
                        Cant_Aceite_Trasera = Convert.ToInt32(dr["Cant_Aceite_Trasera "]),
                        Cant_Combustible = Convert.ToInt32(dr["Cant_Combustible"]),
                        Fecha_Factura = Convert.ToDateTime(dr["Fecha_Factura"]),
                        Tipo = Convert.ToString(dr["Tipo"]),
                        Id_Activo_Placa = Convert.ToInt32(dr["id_Activo_Placa "]),
                    });
            }
            return consumosCombustible;
        }//obtener todas los consunos de combustible del sistemas.


        public Entity.Consumo_Combustible obtenerConsumoCombustible(DateTime fecha, int mes)
        {
            Entity.Consumo_Combustible consumoCombustible = new Entity.Consumo_Combustible();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumoCombustible", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha_Factura", fecha);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumoCombustible = new Entity.Consumo_Combustible
                {
                    Id_Consumo_Combustible = Convert.ToInt32(dr["Id_Consumo_Combustible"]),
                    Cant_Aceite_Motor = Convert.ToInt32(dr["Cant_Aceite_Motor"]),
                    Cant_Aceite_Caja = Convert.ToInt32(dr["Cant_Aceite_Caja"]),
                    Cant_Aceite_Hidraulico = Convert.ToInt32(dr["Cant_Aceite_Hidraulico"]),
                    Cant_Aceite_Delantera = Convert.ToInt32(dr["Cant_Aceite_Delantera"]),
                    Cant_Aceite_Trasera = Convert.ToInt32(dr["Cant_Aceite_Trasera "]),
                    Cant_Combustible = Convert.ToInt32(dr["Cant_Combustible"]),
                    Fecha_Factura = Convert.ToDateTime(dr["Fecha_Factura"]),
                    Tipo = Convert.ToString(dr["Tipo"]),
                    Id_Activo_Placa = Convert.ToInt32(dr["Id_Planta"]),
                };
            }
            return consumoCombustible;
        }//obtener un solo comsumo de agua específico

        public bool actualizarConsumoCombustible(Entity.Consumo_Combustible consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizarConsumoCombustible", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Consumo_Combustible", consumo.Id_Consumo_Combustible);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Motor", consumo.Cant_Aceite_Motor);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Caja", consumo.Cant_Aceite_Caja);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Delantera", consumo.Cant_Aceite_Delantera);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Trasera", consumo.Cant_Aceite_Trasera);
            cmd.Parameters.AddWithValue("@Cant_Aceite_Hidraulico", consumo.Cant_Aceite_Hidraulico);
            cmd.Parameters.AddWithValue("@Cant_Combustible", consumo.Cant_Combustible);
            cmd.Parameters.AddWithValue("@Fecha_Factura", consumo.Fecha_Factura);
            cmd.Parameters.AddWithValue("@Tipo", consumo.Tipo);
            cmd.Parameters.AddWithValue("@Id_Activo_Placa", consumo.Id_Activo_Placa);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos de un consumo de combustible

        public bool EliminarConsumoCombustible(int id, DateTime fechaFactura)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarConsumoCombustible", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Consumo_Combustible", id);
            cmd.Parameters.AddWithValue("@Fecha_Factura", fechaFactura);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//eliminar cconsumo combustible

    }//end class

}//end namespace