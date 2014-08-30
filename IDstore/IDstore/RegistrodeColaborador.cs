using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;
//referencias internacionales
using System.Globalization;
using System.IO;
namespace IDstore
{
    public partial class RegistrodeColaborador : Form
    {
        private static String Verde_OFF = "0";
        private static String Verde_ON = "1";
        private static String Rojo_OFF = "2";
        private static String Rojo_ON = "3";
        public RegistrodeColaborador()
        {
            InitializeComponent();
            serialPort1.PortName = "COM4";//puerto serial
            serialPort1.BaudRate = 9600;//potencial en batios

            try
            {
                serialPort1.Open();


            }
            catch (Exception err)
            {
                MessageBox.Show("No se pudo conectar a el puerto especificado\n" + err, "Error");
            }
           
        }
        int contadorgrid;
        String idregistro;
        
        private void AccesoPermitido()
        {
            txtDNI.Text = null;
            txtDNI.Select();
            txtDNI.Focus();

            serialPort1.Write(Verde_ON);
            lblAcceso.Text = "Acceso Permitido";
            lblAcceso.ForeColor = Color.Green;
            btnAbastecerCombustible.Enabled = true;
        }

        private void AccesoDenegado()
        {
            txtDNI.Text = null;
            txtDNI.Select();
            txtDNI.Focus();
            serialPort1.Write(Rojo_ON);  //prender 3segundos
            lblAcceso.Text = "ACCESO DENEGADO";
            lblAcceso.ForeColor = Color.Red;
            btnAbastecerCombustible.Enabled = false;

        }
        private void NoExisteColaborador()
        {
            txtDNI.Text = null;
            txtDNI.Select();
            txtDNI.Focus();
            picFoto.Image = null;
            this.lblDNI.Visible = false;
            this.lblNombres.Visible = false;
            this.lblApellidos.Visible = false;
            lblAcceso.Text = "Personal no registrado.";
            lblAcceso.ForeColor = Color.Black;
            btnAbastecerCombustible.Enabled = false;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {// open if
                CE_Colaborador objce_colaborador = new CE_Colaborador();
                CN_Colaborador objcn_usuario = new CN_Colaborador();
                objce_colaborador.dni = txtDNI.Text;
                objce_colaborador = objcn_usuario.BuscarColaboradorXdni(objce_colaborador);


                if (objce_colaborador.dni != null)
                {
                    
                    //si existe el colaborador en la base de datos lo muestro pero no se si esta autorizado a ingresar
                    this.txtDNI.Text = objce_colaborador.dni;
                    this.lblDNI.Visible = true;
                    this.lblNombres.Visible = true;
                    this.lblApellidos.Visible = true;
                    lblAcceso.Visible = true;
                    this.lblDNI.Text = objce_colaborador.dni;
                    this.lblNombres.Text = objce_colaborador.nombres;
                    this.lblApellidos.Text = objce_colaborador.apellidos;
                    this.picFoto.Image = objce_colaborador.foto;
                    //inicio verificar acceso: el colaborador existe en la BD, entonces verifico si el acceso esta permitido
                    CN_Acceso objcn_acceso = new CN_Acceso();
                    CE_Acceso objce_acceso = new CE_Acceso();
                    objce_acceso.dni = objce_colaborador.dni;
                    bool EstadoAutorizacion;
                    EstadoAutorizacion = objcn_acceso.VerificarAutorizaciondeAcceso(objce_acceso);
                    if (EstadoAutorizacion == true)//acceso permitido
                    {
                        DateTime dt;
                        AccesoPermitido();

                        //inicio log ES: me permitetener un log de los ingresos y salidas del personal en pantalla
                        contadorgrid++;
                        dataGridView1.Rows.Add(contadorgrid, objce_colaborador.foto, objce_colaborador.apellidos + " " + objce_colaborador.nombres, objce_colaborador.dni);
                        dataGridView1.Sort(this.dataGridView1.Columns["Column4"], ListSortDirection.Descending);
                        //fin log ES:

                       dt = horaservidor();
                       String year = dt.ToString(@"yyyy", CultureInfo.InvariantCulture);
                        String ultimoidregistro;
                        String Nuevoidregistro;
                        //QUERY 1 = PREGUNTO A LA BD, PARAQUE ME DEVUELVA EL ID DEL ULTIMO REGISTRO POR AÑO Y DNI
                        CN_Registro objcn_registro = new CN_Registro();
                        CE_Registro objce_registro = new CE_Registro();
                        
                        objce_registro.idregistro = "%" + year + lblDNI.Text + "%";
                        objce_registro = objcn_registro.UltimoRegistroXYeardni(objce_registro);//RECUPERO EL ULTIMO REGISTRO
                        ultimoidregistro = objce_registro.idregistro;
                        // FIN QUERY 1

                        if (ultimoidregistro == null)
                        {
                            Nuevoidregistro = year + lblDNI.Text + "_0001";
                        }
                        else
                        {
                            Nuevoidregistro = IncrementarIdreregistro(ultimoidregistro, year, lblDNI.Text);
                        }
                        idregistro = Nuevoidregistro;
                        //inicio registro el ingreso del personal
                        objce_registro.idregistro = Nuevoidregistro;
                        objce_registro.dni = objce_colaborador.dni;
                     //   objce_registro.timeentradasalida = dt;
                        objce_registro.idestado_es = "1";//1= ingreso 0: salida
                        objcn_registro.NuevoRegistroES(objce_registro);
                        //fin registro el ingreso del personal



                    }
                    else if (EstadoAutorizacion == false)//acceso denegado
                    {
                        AccesoDenegado();
                    }
                    // fin verificar acceso

                }
                else
                {
                    //no existe el colaborador en la base de datos
                    NoExisteColaborador();

                }

            }//end if

        }//endkeypress

        private void RegistrodeColaborador_Load(object sender, EventArgs e)
        {
            txtDNI.Select();
            txtDNI.Focus();




            

        }

        private String IncrementarIdreregistro(String Ultimo_Idregistro, String year, String dni)
        {
            int numero;
            String cadnro;
            String Nuevo_Idregistro = "";

            int ubicacion,tamano;
            ubicacion = Ultimo_Idregistro.IndexOf("_");
            tamano = Ultimo_Idregistro.Length;


            numero = Convert.ToInt32(Ultimo_Idregistro.Substring(ubicacion + 1, (tamano - ubicacion)-1)) + 1;
            //cadnro=idregistrobd.Substring(idregistrobd.IndexOf("-")+1, idregistrobd.Length  - idregistrobd.IndexOf("-"));

            cadnro = Convert.ToString(numero);
            if (cadnro.Length == 1)
            {
                Nuevo_Idregistro = year + dni + "_000" + numero;
            }
            else if (cadnro.Length == 2)
            {
                Nuevo_Idregistro = year + dni + "_00" + numero;
            }
            else if (cadnro.Length == 3)
            {
                Nuevo_Idregistro = year + dni + "_0" + numero;
            }
            else if (cadnro.Length == 4)
            {
                Nuevo_Idregistro = year + dni + "_" + numero;
            }
            return Nuevo_Idregistro;

        }
        private DateTime horaservidor()
        {
            CE_Servidor objce_servidor = new CE_Servidor();
            CN_Servidor objcn_servidor = new CN_Servidor();
            objce_servidor = objcn_servidor.FechayHoradelServidor();
            return objce_servidor.datetimeservidor;

        }
        private void RegistrodeColaborador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(Rojo_OFF);
                serialPort1.Write(Verde_OFF);
                serialPort1.Close();  //cierro el puerto

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblApellidos_Click(object sender, EventArgs e)
        {

        }

        private void lblDNI_Click(object sender, EventArgs e)
        {

        }

        private void lblNombres_Click(object sender, EventArgs e)
        {

        }

        private void lblAcceso_Click(object sender, EventArgs e)
        {

        }

        private void btnAbastecerCombustible_Click(object sender, EventArgs e)
        {


            AbastecerCombustible AbastecerCombustiblex = new AbastecerCombustible(idregistro);
            AbastecerCombustiblex.ShowDialog();
        }
    }
}
