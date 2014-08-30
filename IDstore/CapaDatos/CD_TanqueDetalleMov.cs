﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;


namespace CapaDatos
{
    public class CD_TanqueDetalleMov
    {
        public DataTable sp_Busqueda_Captura_X_DNI(string dni)
        {
            DataTable dt = new DataTable();
            try
            {

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();

                MySqlCommand cmd = new MySqlCommand("sp_Busqueda_Captura_X_DNI", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("dni", dni);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
        public DataTable sp_Busqueda_Captura_X_NombresyApellidos(string nombres, string apellidos)
        {
            DataTable dt = new DataTable();
            try
            {

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();

                MySqlCommand cmd = new MySqlCommand("sp_Busqueda_Captura_X_NombresyApellidos", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombres", nombres);
                cmd.Parameters.AddWithValue("apellidos", apellidos);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
        public DataTable sp_Busqueda_Captura_X_Codigo_Abastecimiento(string codigo_abastecimiento)
        {
            DataTable dt = new DataTable();
            try
            {

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();

                MySqlCommand cmd = new MySqlCommand("sp_Busqueda_Captura_X_Codigo_Abastecimiento", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_abastecimiento", codigo_abastecimiento);
               
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
        public DataTable sp_Busqueda_Captura_X_Nro_Tanque(string Nro_Tanque)
        {
            DataTable dt = new DataTable();
            try
            {

                MySqlConnection cnx = Conexion.ObtenerConexionMySql();

                MySqlCommand cmd = new MySqlCommand("sp_Busqueda_Captura_X_Nro_Tanque", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nro_Tanque", Nro_Tanque);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }
        public void NuevoTanqueDetalleMov(CE_TanqueDetalleMov objce_tanquedetallemov)
        {//el metodo me permite
            try
            {
              //  Imagenes newfoto = new Imagenes();
                //byte[] areglobytesnapshotpicture = newfoto.imageToByteArray(objce_tanquedetallemov.snapshotpicture);
             
                
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Nuevo_Tanque_Detalle_Mov";
                //asignar paramentros al procedimiento almacenado

                cmd.Parameters.AddWithValue("idtanque", objce_tanquedetallemov.idtanque);
                cmd.Parameters.AddWithValue("idregistro", objce_tanquedetallemov.idregistro);
                cmd.Parameters.AddWithValue("codigo_abastecimiento", objce_tanquedetallemov.codigo_abastecimiento);
                cmd.Parameters.AddWithValue("volumen_retirado", objce_tanquedetallemov.volumen_retirado);
                cmd.Parameters.AddWithValue("snapshotpicture", objce_tanquedetallemov.snapshotpicture);
                cmd.Parameters.AddWithValue("snapshotvideo", objce_tanquedetallemov.snapshotvideo);
                cmd.Parameters.AddWithValue("idtipooperacion", objce_tanquedetallemov.idtipooperacion);
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
        public CE_TanqueDetalleMov SumarVolumenRetirado(CE_TanqueDetalleMov objce_tanquedetallemov)
        {//la funcion me permite 
            try
            {


                CE_TanqueDetalleMov objce_tanquedetallemovtemp = new CE_TanqueDetalleMov();
                MySqlConnection cnx = Conexion.ObtenerConexionMySql();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.CommandText = "sp_Sumar_Volumen_Retirado";
                //asignar paramentros al procedimiento almacenado
                cmd.Parameters.AddWithValue("id_codigo_abastecimiento", objce_tanquedetallemov.codigo_abastecimiento);
                //abrir la conexion
                cnx.Open();
                //ejecutar el procedimiento almacenado
                reader = cmd.ExecuteReader();

                //verifico si hay filas devueltas
                Boolean hayfilas = reader.HasRows;
                if (hayfilas == true)
                {//si hay filas devuelvo el resultado de la consulta

                    while (reader.Read())
                    {
                        
                            objce_tanquedetallemovtemp.totalretirado = Convert.ToDouble(reader["totalretirado"]); 
                        
                        
                                              
                       
                    }
                }

                else
                {
                    //si no hay filas devuelvo la ce con 0
                    objce_tanquedetallemovtemp.totalretirado = 0;
                }
                //Cerrar conexion
                cnx.Close();
                return objce_tanquedetallemovtemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}