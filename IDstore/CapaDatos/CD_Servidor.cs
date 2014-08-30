using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;
using System.Data.OracleClient;
namespace CapaDatos
{
    public class CD_Servidor
    {
        public CE_Servidor FechayHoradelServidor()
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {


                CE_Servidor objce_servidortemp = new CE_Servidor();
                OracleConnection cnx = Conexion.ObtenerConexionOracle();


                OracleCommand cmd = new OracleCommand("select current_timestamp from dual", cnx);
                cnx.Open();
                OracleDataReader reader;

                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                if (hayfilas == true)
                {//si hay filas devuelvo el resultado de la consulta
                    while (reader.Read())
                    {
                        objce_servidortemp.datetimeservidor = Convert.ToDateTime(reader["current_timestamp"]);
                    }

                }

                //Cerrar conexion
                cnx.Close();
                return objce_servidortemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
