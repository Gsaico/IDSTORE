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
   public  class CD_Registro
    {
       public void NuevoRegistroES(CE_Registro objce_registro)
       {//el metodo me permite almacenar los datos del nuevo colaborador.
           try
           {
               MySqlConnection cnx = Conexion.ObtenerConexionMySql();
               MySqlCommand cmd = new MySqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = cnx;
               cmd.CommandText = "sp_Nuevo_Registro_ES";
               //asignar paramentros al procedimiento almacenado
               cmd.Parameters.AddWithValue("idregistro", objce_registro.idregistro);
               cmd.Parameters.AddWithValue("dni", objce_registro.dni);
               cmd.Parameters.AddWithValue("timeentradasalida", objce_registro.timeentradasalida);
               cmd.Parameters.AddWithValue("idestado_es", objce_registro.idestado_es);
           
              
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
        public bool UltimoRegistrodeIngresoSalida(string dni)
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {
                int idestado_es = 999;

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Ultimo_Registro_de_Ingreso_Salida";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("dni", dni);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idestado_es = Convert.ToInt16(reader["idestado_es"]);

                }
                //Cerrar conexion
                cnx.Close();
                if (idestado_es == 1)
                {

                    return true;
                }

                else //if (idestado_es == 0)
                {

                    return false;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CE_Registro UltimoRegistroXYeardni(CE_Registro objce_registro)
        {//la funcion me 
            try
            {
                Imagenes newfoto = new Imagenes();

                CE_Registro objce_registrotemp = new CE_Registro();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_UltimoRegistro_X_Year_dni";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("cadena", objce_registro.idregistro);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objce_registrotemp.idregistro = Convert.ToString(reader["idregistro"]);
                    objce_registrotemp.dni = Convert.ToString(reader["dni"]);
                    objce_registrotemp.timeentradasalida = Convert.ToDateTime(reader["timeentradasalida"]);
                    objce_registrotemp.idestado_es = Convert.ToString(reader["idestado_es"]);
                }
                //Cerrar conexion
                cnx.Close();
                return objce_registrotemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
