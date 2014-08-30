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
    public partial class Fotocheck : Form
    {
        public Fotocheck (string tmpdni)
        {   InitializeComponent();
            this.dni = tmpdni;
        }
        string dni;

        private void colaboradoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.colaboradoresBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_Colaboradores);

        }

        private void Fotocheck_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dS_Colaboradores.colaboradores' Puede moverla o quitarla según sea necesario.
            this.colaboradoresTableAdapter.FillBydni(this.dS_Colaboradores.colaboradores,dni);

            this.reportViewer1.RefreshReport();
        }

         
      

         
    }
}
