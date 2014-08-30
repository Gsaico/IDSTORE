using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//referencias
//using MySql.Data.MySqlClient;

using CapaEntidad;
using CapaNegocio;
//referencias internacionales
using System.Globalization;
using System.IO;

namespace IDstore
{
    public partial class AutorizarAcceso : Form
    {
        public AutorizarAcceso()
        {
            InitializeComponent();
        }

        private void AutorizarAcceso_Load(object sender, EventArgs e)
        {
            CE_Servidor objce_servidor = new CE_Servidor();
            CN_Servidor objcn_servidor = new CN_Servidor();



            objce_servidor = objcn_servidor.FechayHoradelServidor();
            var dt = objce_servidor.datetimeservidor;
            string output = dt.ToString(@"yyyy/MM/dd", CultureInfo.InvariantCulture);

            lblFecha.Text = output;
            txtDNI.Select();
            txtDNI.Focus();
        }
        private void LimpiarObjetos()
        {

            txtDNI.Text = null;
            dtpDesde.Text = null;
            dtpHasta.Text = null;
            picFoto.Image = null;
            rbActivo.Text = null;



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                CE_Colaborador objce_colaborador = new CE_Colaborador();
                CN_Colaborador objcn_usuario = new CN_Colaborador();

                //si existe el usuario  recupero los datos de este
                //  if (clspersonalbd.VerificarSiExistePersonal(txtDNI.Text))
                //   {

                objce_colaborador.dni = txtDNI.Text;

                objce_colaborador = objcn_usuario.BuscarColaboradorXdni(objce_colaborador);

                this.txtDNI.Text = objce_colaborador.dni;
                this.lbldatoscolaborador.Text = objce_colaborador.nombres + "  " + objce_colaborador.apellidos;
                this.picFoto.Image = objce_colaborador.foto;
                //  }

                //  else
                //   {

                //       MessageBox.Show(" El usuario no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //   }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {// guardar nuevo acceso
            CE_Acceso objce_acceso = new CE_Acceso();
            CN_Acceso objcn_acceso = new CN_Acceso();
            CE_Servidor objce_servidor = new CE_Servidor();
            CN_Servidor objcn_servidor = new CN_Servidor();
            objce_servidor = objcn_servidor.FechayHoradelServidor();
            objce_acceso.dni = txtDNI.Text;
            objce_acceso.fechaacceso = objce_servidor.datetimeservidor;
            objce_acceso.fechadesde = this.dtpDesde.Value;
            objce_acceso.fechahasta = this.dtpHasta.Value;
            objce_acceso.observaciones = txtObservaciones.Text;
            objce_acceso.estado = (rbActivo.Checked == true) ? "1" : "0";
            objcn_acceso.NuevoAcceso(objce_acceso);

            //guardar nuevo acceso detalle



        }
    }
}
