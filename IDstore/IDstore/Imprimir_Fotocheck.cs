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
    public partial class Imprimir_Fotocheck : Form
    {
        public Imprimir_Fotocheck(string tmpdni)
        {
            InitializeComponent();
            this.dni = tmpdni;
        }
        string dni;

        private void Imprimir_Fotocheck_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsColaborador.COLABORADORES' Puede moverla o quitarla según sea necesario.
            this.COLABORADORESTableAdapter.FillByDNI(this.dsColaborador.COLABORADORES,dni);

            this.reportViewer1.RefreshReport();
        }
    }
}
