using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDstore
{
    public partial class IDstore : Form
    {
        public IDstore()//string dnitemp)
        {
            InitializeComponent();
            
            //this.dni = dnitemp;
        }
        string dni;
        private void actualizarColaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colaborador hijo = Colaborador.ObtenerInstancia();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void IDstore_Load(object sender, EventArgs e)
        {

        }

        private void autorizarAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutorizarAcceso hijo = new AutorizarAcceso();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrodeColaborador hijo = new RegistrodeColaborador();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void tanqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tanqueDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void codigoDeAbastecimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area hijo = new Area();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargo hijo = new Cargo();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void axisCamaraIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AxisCamaraIP hijo = new AxisCamaraIP();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void codigoDeAbastecimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CodigodeAbastecimiento hijo = new CodigodeAbastecimiento();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void capturaDeAbastecimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda_de_Captura_y_Video hijo = new Busqueda_de_Captura_y_Video();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void codigoDeAbastecimientoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CodigodeAbastecimiento hijo = new CodigodeAbastecimiento();
            hijo.MdiParent = this;
            hijo.Show(); 

        }

        private void tanqueDeCombustibleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tanque hijo = new Tanque();
            hijo.MdiParent = this;
            hijo.Show(); 
        }

        private void sensoresDeTemperaturaYHumedadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Sensor_Temperatura_y_Humedad hijo = new Sensor_Temperatura_y_Humedad();
            hijo.MdiParent = this;
            hijo.Show();
        }

       
    }
}
