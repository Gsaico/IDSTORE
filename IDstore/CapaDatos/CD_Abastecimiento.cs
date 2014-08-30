using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;
namespace CapaDatos
{
   public  class CD_Abastecimiento
    {
        public void NuevoAbastecimiento(CE_Abastecimiento objce_abastecimiento)
        {//el metodo me permite
            try
            {
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nuevo_Abastecimiento";
                //asignar paramentros al procedimiento almacenado
              
                cmd.Parameters.AddWithValue("codigo_abastecimiento", objce_abastecimiento.codigo_abastecimiento);
                cmd.Parameters.AddWithValue("dni", objce_abastecimiento.dni);
                cmd.Parameters.AddWithValue("idtanque", objce_abastecimiento.idtanque);
                cmd.Parameters.AddWithValue("volumen_autorizado", objce_abastecimiento.volumen_autorizado);
                cmd.Parameters.AddWithValue("idplacavehiculo", objce_abastecimiento.idplacavehiculo);
                cmd.Parameters.AddWithValue("estado", objce_abastecimiento.estado);

                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();
                //Cerrar conexion
                cnx.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CE_Abastecimiento ListarAbastecimiento(CE_Abastecimiento objce_abastecimiento)
        {//la funcion me permite 
            try
            {
               

                CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_listar_Abastecimiento";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("codigo_abastecimiento", objce_abastecimiento.codigo_abastecimiento);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                
                    objce_abastecimientotemp.codigo_abastecimiento = Convert.ToString(reader["codigo_abastecimiento"]);
                    objce_abastecimientotemp.dni = Convert.ToString(reader["dni"]);
                    objce_abastecimientotemp.idtanque = Convert.ToString(reader["idtanque"]);
                    objce_abastecimientotemp.volumen_autorizado = Convert.ToDouble (reader["volumen_autorizado"]);
                    objce_abastecimientotemp.idplacavehiculo = Convert.ToString(reader["idplacavehiculo"]);
                    objce_abastecimientotemp.estado = Convert.ToString(reader["estado"]);
           
                }
                //Cerrar conexion
                cnx.Close();
                return objce_abastecimientotemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CE_Abastecimiento VolumenAutorizado(CE_Abastecimiento objce_abastecimiento)
        {//la funcion me permite 
            try
            {
               

                CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Volumen_Autorizado";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("codigo_abastecimiento", objce_abastecimiento.codigo_abastecimiento);
                cmd.Parameters.AddWithValue("estado", objce_abastecimiento.estado );
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    objce_abastecimientotemp.volumen_autorizado = Convert.ToDouble(reader["volumen_autorizado"]);
                    

                }
                //Cerrar conexion
                cnx.Close();
                return objce_abastecimientotemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
