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
    public class CD_Acceso
    {
        public void NuevoAcceso(CE_Acceso objce_acceso)
        {//el metodo me permite almacenar los datos del nuevo acceso.
            try
            {


                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand();
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
               

                CE_Colaborador objce_colaboradortemp = new CE_Colaborador();
                OracleConnection cnx = Conexion.ObtenerConexionOracle();


                OracleCommand cmd = new OracleCommand(String.Format("SELECT * FROM ACCESO WHERE DNI='{0}' AND (TO_DATE(SYSDATE) BETWEEN TO_DATE(FECHADESDE) AND TO_DATE(FECHAHASTA))", objce_acceso.dni), cnx);

               
                cnx.Open();
                OracleDataReader reader;

                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                

                //Cerrar conexion
                cnx.Close();
                return hayfilas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
