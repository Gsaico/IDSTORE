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
    public partial class Colaborador : Form
    {
        //PATRON SINGLETON
        private static Colaborador _instancia;
        public static Colaborador ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new Colaborador();
            }
            _instancia.BringToFront();
            return _instancia;

        }
        private Colaborador()
        {
            InitializeComponent();
        }
        //FIN PATRON SINGLETON
        private void Colaborador_Load(object sender, EventArgs e)
        {
            cargarelementosbasicos();
        }

        private void cargarelementosbasicos()
        {
            CN_Area objcn_area = new CN_Area();

            cbArea.DataSource = objcn_area.Listar_Areas();
            cbArea.ValueMember = "idarea";
            cbArea.DisplayMember = "nombrearea";

            CN_Cargo objcn_cargo = new CN_Cargo();

            cbCargo.DataSource = objcn_cargo.Listar_Cargos();
            cbCargo.ValueMember = "idcargo";
            cbCargo.DisplayMember = "nombrecargo";
            txtDNI.Select();
            txtDNI.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CE_Colaborador objce_colaborador = new CE_Colaborador();
            CN_Colaborador objcn_colaborador = new CN_Colaborador();

            objce_colaborador.dni = txtDNI.Text;
            objce_colaborador.nombres = txtNombres.Text;
            objce_colaborador.apellidos = txtApellidos.Text;
            objce_colaborador.fechanac = dtpFechaNacimiento.Value;
            objce_colaborador.email = txtEmail.Text;
            objce_colaborador.celular = txtCelular.Text;
            objce_colaborador.fechacese = dtpFechaCese.Value;
            //recupero el valor de value menber es decir paso el id
            objce_colaborador.idarea = Convert.ToString(this.cbArea.SelectedValue);
            objce_colaborador.idcargo = Convert.ToString(this.cbCargo.SelectedValue);

            objce_colaborador.foto = picFoto.Image;

            objce_colaborador.estado = (rbActivo.Checked == true) ? "1" : "0";
            objcn_colaborador.NuevoColaboradorOracle(objce_colaborador);

            //objcn_colaborador.NuevoColaborador(objce_colaborador);

            limpiarControles();
            cargarelementosbasicos();
           // objcn_colaborador.NuevoColaboradorOracle(objce_colaborador);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                CE_Colaborador objce_colaborador = new CE_Colaborador();
                CN_Colaborador objcn_usuario = new CN_Colaborador();

             

                objce_colaborador.dni = txtDNI.Text;

                objce_colaborador = objcn_usuario.BuscarColaboradorXdni(objce_colaborador);

                this.txtDNI.Text = objce_colaborador.dni;
                this.txtNombres.Text = objce_colaborador.nombres;
                this.txtApellidos.Text = objce_colaborador.apellidos;



                if (objce_colaborador.fechanac > DateTime.MinValue && objce_colaborador.fechanac < DateTime.MaxValue)
                {
                    this.dtpFechaNacimiento.Value = objce_colaborador.fechanac;
                }

                               
                this.txtEmail.Text = objce_colaborador.email;
                this.txtCelular.Text = objce_colaborador.celular;

               

                if (objce_colaborador.fechacese > DateTime.MinValue && objce_colaborador.fechacese < DateTime.MaxValue )
                {
                    this.dtpFechaCese.Value = objce_colaborador.fechacese;
                }


                if (objce_colaborador.idarea != null)
                {
                    this.cbArea.SelectedValue = objce_colaborador.idarea;
                }

                if (objce_colaborador.idcargo != null)
                {
                    this.cbCargo.SelectedValue = objce_colaborador.idcargo;
                }


                this.picFoto.Image = (objce_colaborador.foto == null ? null : objce_colaborador.foto);
                this.rbActivo.Checked = (objce_colaborador.estado == "1" ? true : false);
                this.rbActivo.Text = (this.rbActivo.Checked == true ? "Habilitado" : "Deshabilitado");
              
            }
        }

        private void btnInsertarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult resultado = ofd.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(ofd.FileName);
            }
            else
            {
            }
        }
        private void limpiarControles()
        {
            txtDNI.Text = null;
            txtNombres.Text = null;
            txtApellidos.Text = null;
            dtpFechaNacimiento.Text = null;
            txtEmail.Text = null;
            txtCelular.Text = null;
            dtpFechaCese.Text = null;
            rbActivo.Checked = false;
            picFoto.Image = null;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Fotocheck imprimirfotocheck = new Fotocheck(txtDNI.Text);
            imprimirfotocheck.Show();


        }
    }
}
