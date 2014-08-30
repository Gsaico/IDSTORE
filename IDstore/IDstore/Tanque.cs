using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// referencias
using CapaNegocio;
using CapaEntidad;
 

namespace IDstore
{
    public partial class Tanque : Form
    {
        public Tanque()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CE_Tanque objce_tanque = new CE_Tanque();
            CN_Tanque objcn_tanque = new CN_Tanque();

            objce_tanque.idtanque = txtIdTanque.Text;
            objce_tanque.volumenactual = Convert.ToDouble( txtVolumenActual.Text);
            objce_tanque.volumenmaximo =Convert.ToDouble ( txtVolumenMaximo.Text);

            objcn_tanque.NuevoTanque(objce_tanque);
  

        }

        private void txtIdTanque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                CE_Tanque objce_tanque = new CE_Tanque();
                CN_Tanque objcn_tanque = new CN_Tanque();


                objce_tanque.idtanque = txtIdTanque.Text; 

                objce_tanque = objcn_tanque.BuscarTanqueXID(objce_tanque);

                this.txtIdTanque .Text = objce_tanque.idtanque;
                this.txtVolumenActual .Text = Convert.ToString ( objce_tanque.volumenactual);
                this.txtVolumenMaximo.Text = Convert.ToString(objce_tanque.volumenmaximo);
               
              
            }
        }
    }
}
