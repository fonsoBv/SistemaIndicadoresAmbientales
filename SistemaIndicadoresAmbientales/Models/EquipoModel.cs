using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SistemaIndicadoresAmbientales.Models
{
    public class EquipoModel
    {
        private SqlConnection connection;

        public EquipoModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor

        public bool crearEquipo(Entity.Equipo equipo, int planta)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_equipo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_activo_placa", equipo.id_activo_placa);
            cmd.Parameters.AddWithValue("@tipo_combustible", equipo.tipo_combustible);
            cmd.Parameters.AddWithValue("@medida_combustible", equipo.medida_combustible);
            cmd.Parameters.AddWithValue("@medida_aceite", equipo.medida_aceite);
            cmd.Parameters.AddWithValue("@combustible", equipo.combustible);
            cmd.Parameters.AddWithValue("@aceite_motor", equipo.aceite_motor);
            cmd.Parameters.AddWithValue("@aceite_caja", equipo.aceite_caja);
            cmd.Parameters.AddWithValue("@aceite_delantera", equipo.aceite_delantera);
            cmd.Parameters.AddWithValue("@aceite_trasera", equipo.aceite_trasera);
            cmd.Parameters.AddWithValue("@aceite_hidraulico", equipo.aceite_hidraulico);
            cmd.Parameters.AddWithValue("@catalizador", equipo.catalizador);
            cmd.Parameters.AddWithValue("@nombre", equipo.nombre);
            cmd.Parameters.AddWithValue("@tipo", equipo.tipo);
            cmd.Parameters.AddWithValue("@id_planta", planta);
            cmd.Parameters.AddWithValue("@estadoBL", equipo.estadoBL);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un equipo (equipo menor o vehiculo) al sistema

        public enum Identificador
        {
            Activo,
            Placa
        }

        public List<Entity.Equipo> obtenerEquipos()
        {
            List<Entity.Equipo> equipos = new List<Entity.Equipo>();

            SqlCommand cmd = new SqlCommand("sp_obtener_equipos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                equipos.Add(
                    new Entity.Equipo
                    {
                        nombre = Convert.ToString(dr["nombre"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"]),
                        id_planta = Convert.ToInt32(dr["id_planta"])
                    });
            }
            return equipos;
        }//obtener todas los equipos menores del sistemas.

        public List<Entity.Equipo> obtenerVehiculos()
        {
            List<Entity.Equipo> vehiculos = new List<Entity.Equipo>();

            SqlCommand cmd = new SqlCommand("sp_obtener_vehiculos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                vehiculos.Add(
                    new Entity.Equipo
                    {
                        nombre = Convert.ToString(dr["nombre"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"]),
                        id_planta = Convert.ToInt32(dr["id_planta"])
                    });
            }
            return vehiculos;
        }//obtener todas los vehiculos del sistemas.

        public List<Entity.Equipo> obtenerEqMenores()
        {
            List<Entity.Equipo> equiposM = new List<Entity.Equipo>();

            SqlCommand cmd = new SqlCommand("sp_obtener_eq_menores", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                equiposM.Add(
                    new Entity.Equipo
                    {
                        nombre = Convert.ToString(dr["nombre"]),
                        id_activo_placa = Convert.ToString(dr["id_activo_placa"]),
                        id_planta = Convert.ToInt32(dr["id_planta"])
                    });
            }
            return equiposM;
        }//obtener todas los equipos menores del sistemas.



        //public Entity.Consumo_Combustible obtenerConsumoCombustible(DateTime fecha, int mes)
        //{
        //    Entity.Consumo_Combustible consumoCombustible = new Entity.Consumo_Combustible();

        //    SqlCommand cmd = new SqlCommand("sp_obtenerConsumoCombustible", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Fecha_Factura", fecha);

        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    connection.Open();
        //    sd.Fill(dt);
        //    connection.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        consumoCombustible = new Entity.Consumo_Combustible
        //        {
        //            Id_Consumo_Combustible = Convert.ToInt32(dr["Id_Consumo_Combustible"]),
        //            Cant_Aceite_Motor = Convert.ToInt32(dr["Cant_Aceite_Motor"]),
        //            Cant_Aceite_Caja = Convert.ToInt32(dr["Cant_Aceite_Caja"]),
        //            Cant_Aceite_Hidraulico = Convert.ToInt32(dr["Cant_Aceite_Hidraulico"]),
        //            Cant_Aceite_Delantera = Convert.ToInt32(dr["Cant_Aceite_Delantera"]),
        //            Cant_Aceite_Trasera = Convert.ToInt32(dr["Cant_Aceite_Trasera "]),
        //            Cant_Combustible = Convert.ToInt32(dr["Cant_Combustible"]),
        //            Fecha_Factura = Convert.ToDateTime(dr["Fecha_Factura"]),
        //            Tipo = Convert.ToString(dr["Tipo"]),
        //            Id_Activo_Placa = Convert.ToInt32(dr["Id_Planta"]),
        //        };
        //    }
        //    return consumoCombustible;
        //}//obtener un solo comsumo de agua específico

        //public bool actualizarConsumoCombustible(Entity.Consumo_Combustible consumo)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_actualizarConsumoCombustible", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@Id_Consumo_Combustible", consumo.Id_Consumo_Combustible);
        //    cmd.Parameters.AddWithValue("@Cant_Aceite_Motor", consumo.Cant_Aceite_Motor);
        //    cmd.Parameters.AddWithValue("@Cant_Aceite_Caja", consumo.Cant_Aceite_Caja);
        //    cmd.Parameters.AddWithValue("@Cant_Aceite_Delantera", consumo.Cant_Aceite_Delantera);
        //    cmd.Parameters.AddWithValue("@Cant_Aceite_Trasera", consumo.Cant_Aceite_Trasera);
        //    cmd.Parameters.AddWithValue("@Cant_Aceite_Hidraulico", consumo.Cant_Aceite_Hidraulico);
        //    cmd.Parameters.AddWithValue("@Cant_Combustible", consumo.Cant_Combustible);
        //    cmd.Parameters.AddWithValue("@Fecha_Factura", consumo.Fecha_Factura);
        //    cmd.Parameters.AddWithValue("@Tipo", consumo.Tipo);
        //    cmd.Parameters.AddWithValue("@Id_Activo_Placa", consumo.Id_Activo_Placa);

        //    connection.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    connection.Close();

        //    if (i >= 1)
        //        return true;
        //    else
        //        return false;
        //}//actualizar los datos de un consumo de combustible

        public bool EliminarVehiculo(string id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_vehiculo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_activo_placa", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//eliminar vehiculos de la tabla Equipo

        public bool EliminarEqMenor(string id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_eq_menor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_activo_placa", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//eliminar equipos menores de la tabla Equipo

    }
}