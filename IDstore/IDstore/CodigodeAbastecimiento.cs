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


using CapaEntidad;
using CapaNegocio;
namespace IDstore
{
    public partial class CodigodeAbastecimiento : Form
    {
        public CodigodeAbastecimiento()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // guardar nuevo acceso detalle
            CE_Abastecimiento objce_abastecimiento = new CE_Abastecimiento();
            CN_Abastecimiento objcn_abastecimiento = new CN_Abastecimiento();
            objce_abastecimiento.dni = txtDNI.Text;
            objce_abastecimiento.codigo_abastecimiento = txtCodigodeAbastecimiento.Text;
            objce_abastecimiento.idtanque = txtIdtanque.Text;
            objce_abastecimiento.volumen_autorizado = Convert.ToDouble(txtVolumenAutorizado.Text);
            objce_abastecimiento.idplacavehiculo = txtIdplacavehiculo.Text;
            objce_abastecimiento.estado = (rbActivo.Checked == true) ? "1" : "0";
            objcn_abastecimiento.NuevoAbastecimiento(objce_abastecimiento);

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CE_Acceso objce_acceso = new CE_Acceso();
                CN_Acceso objcn_acceso = new CN_Acceso();
                objce_acceso.dni = txtDNI.Text;

                bool EstadoAutorizacion;
                EstadoAutorizacion = objcn_acceso.VerificarAutorizaciondeAcceso(objce_acceso);
                if (EstadoAutorizacion == true)//acceso permitido
                {

                    btnGuardar.Enabled = true;
                    
                }
                else if (EstadoAutorizacion == false)//acceso denegado
                {
                    MessageBox.Show("El numero de DNI no tiene permiso de acceso", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGuardar.Enabled = false;
                }

            }
        }
        private void LimpiarControles()
        {
            txtCodigodeAbastecimiento.Text = null;
            txtDNI.Text = null;
            txtIdtanque.Text=null;
        txtVolumenAutorizado.Text=null;

        txtIdplacavehiculo.Text =null;
        rbActivo.Checked = false;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void CodigodeAbastecimiento_Load(object sender, EventArgs e)
        {
            txtDNI.Select();
            txtDNI.Focus();
        }
    }
}
