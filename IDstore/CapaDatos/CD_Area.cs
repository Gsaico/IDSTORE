using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias agregadas para mysql y capa entidad
using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

using System.Data.OracleClient;
namespace CapaDatos
{
    public class CD_Area
    {
        public DataTable ListarAreas()
        {
            DataTable dt = new DataTable();
            try
            {
                

                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                
                OracleCommand cmd = new OracleCommand(String.Format("select * from area"), cnx);
                cnx.Open();
                              
                OracleDataReader reader;

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
               // lleno el DataTable con el datareader
                dt.Load(reader);
                                       
                                
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }





        public int NuevaArea(CE_Area objce_area)
        {//el metodo m
            try
            {
                int filasafectadas = 0;

                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nueva_Area";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("nombreareaX", objce_area.nombrearea);


                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                filasafectadas = cmd.ExecuteNonQuery();
                //Cerrar conexion
                cnx.Close();
                return filasafectadas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool VerificarExisteArea(CE_Area objce_area)
        {//la funcion me permite recuperar los datos
            try
            {


                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand(String.Format("select * from area where nombrearea ='{0}'", objce_area.nombrearea), cnx);
                cnx.Open();
                OracleDataReader reader;

                reader = cmd.ExecuteReader();


                Boolean existearea = reader.HasRows;
              

                cnx.Close();

                return existearea;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
