using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaIndicadoresAmbientales.Models
{
    public class ConsumoElectricoModel
    {
        private SqlConnection connection;

        public ConsumoElectricoModel()
        {
            String constring = ConfigurationManager.ConnectionStrings["indicadoresAmbientales"].ToString();
            connection = new SqlConnection(constring);
        }//constructor


        public List<Entity.HistoricoElectrico> obtenerHistoricoElectrico(int planta, int Mes, int Anio)
        {
            List<Entity.HistoricoElectrico> consumoshistorico = new List<Entity.HistoricoElectrico>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerHistoricoElectricoPorPlanta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Planta", planta);
            cmd.Parameters.AddWithValue("@MesIN", Mes);
            cmd.Parameters.AddWithValue("@Anio", Anio);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
             {
                consumoshistorico.Add(new Entity.HistoricoElectrico
                {
                    Cantidad = Convert.ToInt64(dr["Cantidad"]),
                    Anio = Convert.ToInt32(dr["Anio"]),
                    Mes = Convert.ToInt32(dr["Mes"]),
                });
            }
            return consumoshistorico;

        }//end HistoricoAgua


        public List<Entity.HistoricoElectrico> obtenerHistoricoElectricoAnual(int Anio1,int Anio2)
        {
            List<Entity.HistoricoElectrico> consumoshistorico = new List<Entity.HistoricoElectrico>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerHistoricoElectricoAnual", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Anio1", Anio1);
            cmd.Parameters.AddWithValue("@Anio2", Anio2);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumoshistorico.Add(new Entity.HistoricoElectrico
                {
                    Cantidad = Convert.ToInt64(dr["Cantidad"]),
                    Anio = Convert.ToInt32(dr["Anio"]),
                    Mes = Convert.ToInt32(dr["Mes"]),
                });
            }
            return consumoshistorico;

        }//end historico Agua Anual

        public bool crearConsumoElectrico(Entity.ConsumoElectrico consumo)
        {
            SqlCommand cmd = new SqlCommand("sp_crearConsumoElectrico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Vatihorimetro", consumo.id_Vatihorimetro);
            cmd.Parameters.AddWithValue("@Medidad", consumo.Medida);
            cmd.Parameters.AddWithValue("@Cantidad", consumo.Cantidad);
            cmd.Parameters.AddWithValue("@fecha", consumo.fecha);
            cmd.Parameters.AddWithValue("@Mes", consumo.Mes);


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }//Añadir un consumo electrico en el sistema

        public List<Entity.ConsumoElectrico> obtenerConsumosElectricos()
        {
            List<Entity.ConsumoElectrico> consumosElectricos = new List<Entity.ConsumoElectrico>();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumosElectricos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosElectricos.Add(
                    new Entity.ConsumoElectrico
                    {
                        id_Consumo_Electrico = Convert.ToInt32(dr["Id_Consumo_Electrico"]),
                        Cantidad = Convert.ToInt64(dr["Cantidad"]),
                        fecha = Convert.ToDateTime(dr["Fecha"]),
                        id_Vatihorimetro = Convert.ToInt32(dr["id_Vatihorimetro"]),
                        Medida = Convert.ToString(dr["Medida"]),
                        Mes = Convert.ToInt32(dr["Mes"]),
                    });
            }
            return consumosElectricos;
        }//obtener todas los consunos de agua del sistemas.



        public List<Entity.ConsumoElectricoActualizar> obtenerConsumosActualizarElectrico(int mes, int planta)
        {
            List<Entity.ConsumoElectricoActualizar> consumosElectrico = new List<Entity.ConsumoElectricoActualizar>();

            SqlCommand cmd = new SqlCommand("sp_ObtenerActualizar_ConsumoElectrico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Id_Planta", planta);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosElectrico.Add(new Entity.ConsumoElectricoActualizar
                {
                    Id_Consumo_Electrico = Convert.ToInt32(dr["Id_Consumo_Electrico"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    Numero_Vatihorimetro = Convert.ToInt32(dr["Numero_Vatihorimetro"]),
                });
            }
            return consumosElectrico;
        }//obtener un solo comsumo de agua específico



        public bool actualizarConsumoElectrico(int Cantidad, int Id_Consumo_Electrico)
        {
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Consumo_Electrico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Consumo_Electrico", Id_Consumo_Electrico);
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//actualizar los datos

        public Entity.ConsumoElectrico obtenerConsumoElectrico(DateTime fecha, int mes)
        {
            Entity.ConsumoElectrico consumosElectrico = new Entity.ConsumoElectrico();

            SqlCommand cmd = new SqlCommand("sp_obtenerConsumoElectrico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", fecha);
            cmd.Parameters.AddWithValue("@Mes", mes);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                consumosElectrico = new Entity.ConsumoElectrico
                {
                    id_Consumo_Electrico = Convert.ToInt32(dr["Id_Consumo_Agua"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    fecha = Convert.ToDateTime(dr["Fecha"]),
                    id_Vatihorimetro = Convert.ToInt32(dr["Id_Vatihorimetro"]),
                    Medida = Convert.ToString(dr["Medida"]),
                    Mes = Convert.ToInt32(dr["Mes"])

                };
            }
            return consumosElectrico;
        }//obtener un solo comsumo electrico específico


        public bool EliminarConsumoElectrico(int id, DateTime fecha)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarConsumoElectrico", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Consumo_Electrico", id);
            cmd.Parameters.AddWithValue("@Fecha", fecha);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }//eliminar consumo electrico

    }//end class

}//end namespace