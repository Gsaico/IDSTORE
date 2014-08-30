using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Servidor
    {
        public CE_Servidor FechayHoradelServidor()
        {//la funcion me permite recuperar la fecha y hora en el servidor
            try
            {


                CE_Servidor objce_servidortemp = new CE_Servidor();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_FechayHoradelServidor";
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objce_servidortemp.datetimeservidor = Convert.ToDateTime(reader["Fechayhora"]);
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
