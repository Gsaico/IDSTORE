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
    public class CD_Cargo
    {
     


        public DataTable ListarCargos()
        {
            DataTable dt = new DataTable();
            try
            {


                OracleConnection cnx = Conexion.ObtenerConexionOracle();

                OracleCommand cmd = new OracleCommand(String.Format("select * from cargo"), cnx);
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




       
        public int NuevoCargo(CE_Cargo objce_cargo)
        {//el metodo m
            try
            {
                int filasafectadas = 0;

                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nuevo_Cargo";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("nombrecargox", objce_cargo.nombrecargo);


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


             public bool VerificarExisteCargo(CE_Cargo objce_cargo)
        {//la funcion me permite recuperar los datos
            try
            {


                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand(String.Format("select * from cargo where nombrecargo ='{0}'", objce_cargo.nombrecargo), cnx);
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
