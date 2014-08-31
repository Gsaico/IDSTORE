using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

using System.Data.OracleClient;

namespace CapaDatos
{
    public class CD_Colaborador
    {
       
        public void NuevoColaboradorOracle(CE_Colaborador objce_colaborador)
        {//el metodo me permite almacenar los datos del nuevo colaborador.
            try
            {
                Imagenes newfoto = new Imagenes();
                byte[] areglobyte = newfoto.imageToByteArray(objce_colaborador.foto);
                //OracleParameter blobParameter = new OracleParameter();


                //blobParameter.OracleType = OracleType.Blob;
                //blobParameter.ParameterName = "foto";
                //blobParameter.Value = areglobyte;

                OracleConnection cnx = Conexion.ObtenerConexionOracle();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nuevo_Colaborador";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("dni", OracleType.VarChar).Value = objce_colaborador.dni;
                cmd.Parameters.AddWithValue("nombres", OracleType.VarChar).Value = objce_colaborador.nombres;
                cmd.Parameters.AddWithValue("apellidos", OracleType.VarChar).Value = objce_colaborador.apellidos;
                cmd.Parameters.AddWithValue("fechanac", OracleType.DateTime).Value = objce_colaborador.fechanac;
                cmd.Parameters.AddWithValue("email", OracleType.VarChar).Value = objce_colaborador.email;
                cmd.Parameters.AddWithValue("celular", OracleType.VarChar).Value = objce_colaborador.celular;
                cmd.Parameters.AddWithValue("fechacese", OracleType.DateTime).Value = objce_colaborador.fechacese;
                cmd.Parameters.AddWithValue("idarea", OracleType.Number).Value = objce_colaborador.idarea;
                cmd.Parameters.AddWithValue("idcargo", OracleType.Number).Value = objce_colaborador.idcargo;
                cmd.Parameters.AddWithValue("foto", OracleType.Blob).Value = areglobyte;
                cmd.Parameters.AddWithValue("estado", OracleType.VarChar).Value = objce_colaborador.estado;
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
        public CE_Colaborador BuscarColaboradorXdni(CE_Colaborador objce_colaborador)
        {//la funcion me permite recuperar los datos del colaborador en el objeto CE_Colaborador
            try
            {
                Imagenes newfoto = new Imagenes();

                CE_Colaborador objce_colaboradortemp = new CE_Colaborador();
                OracleConnection cnx = Conexion.ObtenerConexionOracle();

               
                OracleCommand cmd = new OracleCommand(String.Format( "select * from colaboradores where dni='{0}'", objce_colaborador.dni), cnx);
                cnx.Open();
                OracleDataReader reader;
        
                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                if (hayfilas == true)
                {//si hay filas devuelvo el resultado de la consulta
                    while (reader.Read())
                    {
                        objce_colaboradortemp.dni = Convert.ToString(reader["dni"]);
                        objce_colaboradortemp.nombres = Convert.ToString(reader["nombres"]);
                        objce_colaboradortemp.apellidos = Convert.ToString(reader["apellidos"]);
                        objce_colaboradortemp.fechanac = Convert.ToDateTime(reader["fechanac"]);
                        objce_colaboradortemp.email = Convert.ToString(reader["email"]);
                        objce_colaboradortemp.celular = Convert.ToString(reader["celular"]);
                        objce_colaboradortemp.fechacese = Convert.ToDateTime(reader["fechacese"]);
                        objce_colaboradortemp.idarea = Convert.ToString(reader["idarea"]);
                        objce_colaboradortemp.idcargo = Convert.ToString(reader["idcargo"]);
                        objce_colaboradortemp.foto = newfoto.byteArrayToImage((byte[])reader["foto"]);
                        objce_colaboradortemp.estado = Convert.ToString(reader["estado"]);
                    }

                }

                //Cerrar conexion
                cnx.Close();
                return objce_colaboradortemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       

    }
}
