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


namespace IDstore
{
    public partial class Cargo : Form
    {
        public Cargo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            CE_Cargo objce_cargo = new CE_Cargo();
            CN_Cargo objcn_cargo = new CN_Cargo();

            objce_cargo.nombrecargo  = txtCargo.Text;



            if (objcn_cargo.VerificarExisteCargo(objce_cargo) == true)
            {

                MessageBox.Show("El cargo ya existe", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {

                int filasafectadas = objcn_cargo.NuevoCargo(objce_cargo);

                if (filasafectadas > 0)
                {
                    MessageBox.Show("La actualizacion se realizo con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                this.dgvCargo.DataSource = objcn_cargo.Listar_Cargos();

            }
        }
    }
}
