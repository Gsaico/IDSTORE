using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace IDstore
{
    public partial class Area : Form
    {
        public Area()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            CE_Area objce_area = new CE_Area();
            CN_Area objcn_area = new CN_Area();

            objce_area.nombrearea = txtArea.Text;



            if (objcn_area.VerificarExisteArea(objce_area) == true)
            {

                MessageBox.Show("El area ya existe", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {

                int filasafectadas = objcn_area.NuevaArea(objce_area);

                if (filasafectadas > 0)
                {
                    MessageBox.Show("La actualizacion se realizo con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                this.dgvArea.DataSource = objcn_area.Listar_Areas();

            }
        }
    }
}
