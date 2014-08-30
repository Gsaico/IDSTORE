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
    public class CD_Tanque
    {
        public void NuevoTanque(CE_Tanque objce_tanque)
        {//el metodo me permite almacenar los datos del nuevo tanque.
            try
            {
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nuevo_Tanque";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("idtanque", objce_tanque.idtanque );
                cmd.Parameters.AddWithValue("volumenactual", objce_tanque.volumenactual);
                cmd.Parameters.AddWithValue("volumenmaximo", objce_tanque.volumenmaximo);
             
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

        public CE_Tanque BuscarTanqueXID(CE_Tanque objce_tanque)
        {//la funcion me permite recuperar los datos del tanque
            try
            {


                CE_Tanque objce_tanquetemp = new CE_Tanque();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_BuscarTanqueXID";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("idtanque", objce_tanque.idtanque);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objce_tanquetemp.idtanque = Convert.ToString(reader["idtanque"]);
                    objce_tanquetemp.volumenactual = Convert.ToDouble(reader["volumenactual"]);
                    objce_tanquetemp.volumenmaximo = Convert.ToDouble(reader["volumenmaximo"]);
                  
                }
                //Cerrar conexion
                cnx.Close();
                return objce_tanquetemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
