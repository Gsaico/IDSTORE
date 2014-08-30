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
    public class CD_Acceso
    {
        public void NuevoAcceso(CE_Acceso objce_acceso)
        {//el metodo me permite almacenar los datos del nuevo acceso.
            try
            {
               

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_NuevoAcceso";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("dni", objce_acceso.dni);
                cmd.Parameters.AddWithValue("fechaacceso", objce_acceso.fechaacceso );
                cmd.Parameters.AddWithValue("fechadesde", objce_acceso.fechadesde );
                cmd.Parameters.AddWithValue("fechahasta", objce_acceso.fechahasta );
                cmd.Parameters.AddWithValue("observaciones", objce_acceso.observaciones );
                cmd.Parameters.AddWithValue("estado", objce_acceso.estado );
              
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

        public bool VerificarAutorizaciondeAcceso(CE_Acceso objce_acceso)
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {
                int EstadoAutorizacion=666;
                         
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_VerificarAutorizaciondeAcceso";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("dni", objce_acceso.dni);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstadoAutorizacion = Convert.ToInt16(reader["EstadoAutorizacion"]);
                   
                }
                //Cerrar conexion
                cnx.Close();
                if (EstadoAutorizacion == 1)
                {

                    return true;
                }

                else //(EstadoAutorizacion == 0)
                {

                    return false;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
