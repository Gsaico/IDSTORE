using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

using System.Data.OracleClient;
namespace CapaDatos
{
   public  class CD_Abastecimiento
    {
        public void NuevoAbastecimiento(CE_Abastecimiento objce_abastecimiento)
        {//el metodo me permite
            try
            {
                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand();
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
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {

                CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();
          
                OracleConnection cnx = Conexion.ObtenerConexionOracle();


                OracleCommand cmd = new OracleCommand(String.Format("select * from abastecimiento where codigo_abastecimiento='{0}'", objce_abastecimiento.codigo_abastecimiento), cnx);
                cnx.Open();
                OracleDataReader reader;

                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                if (hayfilas == true)
                {//si hay filas devuelvo el resultado de la consulta
                    while (reader.Read())
                    {
                        objce_abastecimientotemp.codigo_abastecimiento = Convert.ToString(reader["codigo_abastecimiento"]);
                        objce_abastecimientotemp.dni = Convert.ToString(reader["dni"]);
                        objce_abastecimientotemp.idtanque = Convert.ToString(reader["idtanque"]);
                        objce_abastecimientotemp.volumen_autorizado = Convert.ToDouble(reader["volumen_autorizado"]);
                        objce_abastecimientotemp.idplacavehiculo = Convert.ToString(reader["idplacavehiculo"]);
                        objce_abastecimientotemp.estado = Convert.ToString(reader["estado"]);
                    }

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
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {

                CE_Abastecimiento objce_abastecimientotemp = new CE_Abastecimiento();

                OracleConnection cnx = Conexion.ObtenerConexionOracle();


                OracleCommand cmd = new OracleCommand(String.Format("SELECT  volumen_autorizado FROM abastecimiento where codigo_abastecimiento= '{0}' and  estado= '{1}'", objce_abastecimiento.codigo_abastecimiento, objce_abastecimiento.estado), cnx);
                cnx.Open();
                OracleDataReader reader;

                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                if (hayfilas == true)
                {//si hay filas devuelvo el resultado de la consulta
                    while (reader.Read())
                    {
                        objce_abastecimientotemp.volumen_autorizado = Convert.ToDouble(reader["volumen_autorizado"]);
                    }

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
