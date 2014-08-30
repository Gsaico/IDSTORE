using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agregando para automatizar conexion
using System.Configuration;
using MySql.Data.MySqlClient;

using System.Data.OracleClient;
using System.Data;


namespace CapaDatos
{
    class Conexion
    {
        public static MySqlConnection ObtenerConexionMySql()
        {
            MySqlConnection conexion;

            //@"Server=PERVAC-PC\MSSQLSERVERX;database=id_check_db;integrated security=true"

            conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["IDstorecnnMySql"].ToString());

            return conexion;
        }
        public static OracleConnection ObtenerConexionOracle()
        {
            OracleConnection conexion;

            //@"Server=PERVAC-PC\MSSQLSERVERX;database=id_check_db;integrated security=true"

            conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["IDstorecnnOracle"].ToString());

            return conexion;
        }
    }
}
