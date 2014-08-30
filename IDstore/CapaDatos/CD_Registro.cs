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
   public  class CD_Registro
    {
       public void NuevoRegistroES(CE_Registro objce_registro)
       {//el metodo me permite almacenar los datos del nuevo colaborador.
           try
           {
               OracleConnection cnx = Conexion.ObtenerConexionOracle();
               OracleCommand cmd = new OracleCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = cnx;
               cmd.CommandText = "sp_nuevo_registro_es";
               //asignar paramentros al procedimiento almacenado
               cmd.Parameters.AddWithValue("idregistro",OracleType.VarChar).Value = objce_registro.idregistro;
               cmd.Parameters.AddWithValue("dni",OracleType.VarChar).Value = objce_registro.dni;
               cmd.Parameters.AddWithValue("idestado_es", OracleType.VarChar).Value =objce_registro.idestado_es;
           
              
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
        //public bool UltimoRegistrodeIngresoSalida(string dni)
        //{//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
        //    try
        //    {
        //        int idestado_es = 999;

        //        MySqlConnection cnx = Conexion.ObtenerConexionMySql();
        //        MySqlCommand cmd = new MySqlCommand();
        //        MySqlDataReader reader;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = cnx;
        //        cmd.CommandText = "sp_Ultimo_Registro_de_Ingreso_Salida";
        //        //asignar paramentros al procedimiento almacenado
        //        cmd.Parameters.AddWithValue("dni", dni);
        //        //abrir la conexion
        //        cnx.Open();
        //        //ejecutar el procedimiento almacenado
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            idestado_es = Convert.ToInt16(reader["idestado_es"]);

        //        }
        //        //Cerrar conexion
        //        cnx.Close();
        //        if (idestado_es == 1)
        //        {

        //            return true;
        //        }

        //        else //if (idestado_es == 0)
        //        {

        //            return false;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
       public CE_Registro UltimoRegistroXYeardni(CE_Registro objce_registro)
       {//la funci
           try
           {
               CE_Registro objce_registrotemp = new CE_Registro();
              

               CE_Colaborador objce_colaboradortemp = new CE_Colaborador();
               OracleConnection cnx = Conexion.ObtenerConexionOracle();


               OracleCommand cmd = new OracleCommand(String.Format("SELECT * FROM (SELECT * FROM registroes WHERE  idregistro LIKE  '{0}' ORDER BY idregistro desc) WHERE  ROWNUM <= 1", objce_registro.idregistro), cnx);
               cnx.Open();
               

               OracleDataReader reader;

               reader = cmd.ExecuteReader();

               //verifico si hay filas devueltas
               Boolean hayfilas = reader.HasRows;
               if (hayfilas == true)
               {//si hay filas devuelvo el resultado de la consulta
                   while (reader.Read())
                   {
                       objce_registrotemp.idregistro = Convert.ToString(reader["idregistro"]);


                       objce_registrotemp.dni = Convert.ToString(reader["dni"]);
                       objce_registrotemp.timeentradasalida = Convert.ToDateTime(reader["timeentradasalida"]);
                       objce_registrotemp.idestado_es = Convert.ToString(reader["idestado_es"]);
                   }

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
