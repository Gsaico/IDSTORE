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
//referencias agregadas

using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using AXISMEDIACONTROLLib;
namespace IDstore
{
   
    public partial class Busqueda_de_Captura_y_Video : Form
    {
        enum State
        {
            Stopped,
            Paused,
            Playing
        }
        State state = State.Stopped;

        private bool compatibilityMode;
        private bool isSeeking = false;

        private ulong duration = 0;
        public Busqueda_de_Captura_y_Video()
        {
            InitializeComponent();
        }
        public uint BackStepLengthMilliSec { get; set; }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CN_TanqueDetalleMov objcd_tanquedetallemov = new CN_TanqueDetalleMov();
            dataGridView1.DataSource = null;

            switch (cbxElegir.Text)
            {
                case "Codigo de Abastecimiento":
                    dataGridView1.DataSource = objcd_tanquedetallemov.sp_Busqueda_Captura_X_Codigo_Abastecimiento(txtBusqueda.Text);
                    
                    break;
                case "Numero de Tanque":
                    dataGridView1.DataSource = objcd_tanquedetallemov.sp_Busqueda_Captura_X_Nro_Tanque(txtBusqueda.Text);
                    break;
                case "DNI":
                    dataGridView1.DataSource = objcd_tanquedetallemov.sp_Busqueda_Captura_X_DNI(txtBusqueda.Text);
                    break;
                case "Apellidos y Nombres":

                    dataGridView1.DataSource = objcd_tanquedetallemov.sp_Busqueda_Captura_X_NombresyApellidos(txtBusqueda.Text, txtBusqueda.Text);
                    break;

                default:
                    MessageBox.Show("Error en la seleccion");
                    break;
            }



        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            

           // MessageBox.Show("columna: " + e.ColumnIndex + "  fila: " + e.RowIndex + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;


            

            if (e.ColumnIndex ==4)// columna seleccionda de picture
            { //  pictureBox1.Image = byteArrayToImage((byte[])dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);//convertir celda de datagridview en image
                pictureBox1.Image = Image.FromFile(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
            }
            else if (e.ColumnIndex == 5)// columna seleccionda de video
            {
                amc.Stop();

                amc.MediaFile = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                amc.Play();

            }


           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("Has pulsado xx la columna: " + e.ColumnIndex);
        }

        private void Busqueda_de_Captura_y_Video_Load(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            amc.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            amc.Stop();
        }

        private void backStepButton_Click(object sender, EventArgs e)
        {
            // Accurate backward frame stepping is not supported but we could step back
            // to the previous sync-point
            if ((amc.Status & (int)AMC_STATUS.AMC_STATUS_PAUSED) == 0) // not paused
            {
                amc.TogglePause();
            }

            ulong newPosition = amc.CurrentPosition64;
            if (newPosition > BackStepLengthMilliSec)
            {
                newPosition -= BackStepLengthMilliSec;
            }
            else
            {
                newPosition = 0;
            }
            SetMediaPosition(newPosition, true);
        }
        private void SetMediaPosition(ulong newPosMilliSec, bool forceSeek)
        {
            if (MediaDuration <= 0)
            {
                return;
            }

            if (compatibilityMode)
            {
                // To change the current media position in compatibility mode we first stop AMC,
                // then set the new position and start streaming again by calling the Play method
                // Note that the Stop/Play methods are asynchronous.
                if (!isSeeking || forceSeek)
                {
                    if (newPosMilliSec >= MediaDuration && MediaDuration > 0)
                    {
                        newPosMilliSec = MediaDuration - 1;
                    }

                    if (state == State.Stopped)
                    {
                        amc.CurrentPosition64 = newPosMilliSec;
                        return;
                    }

                    isSeeking = true; // Performing an asynchronous seeking operation

                    amc.Stop();
                    amc.CurrentPosition64 = newPosMilliSec;
                    if (state == State.Paused)
                    {
                        amc.TogglePause();
                    }
                    else
                    {
                        amc.Play();
                    }

                    // The asynchronous seeking operation will be complete when the status
                    // of AMC is playing again, see amc_OnStatusChange.
                }
            }
            else
            {
                amc.CurrentPosition64 = newPosMilliSec;
            }
        }
        public ulong MediaDuration
        {
            get
            {
                if (duration > 0)
                {
                    return duration;
                }
                else
                {
                    return amc.Duration64;
                }
            }

            set
            {
                duration = value;
            }
        }
        private void SetState(State state)
        {
            this.state = state;

            switch (state)
            {
                case State.Stopped:
                    playButton.Enabled = true;
                    pauseButton.Enabled = true;
                    stopButton.Enabled = false;
                    trackBar1.Value = 0;
                    progressBar1.Value = 0;
                    break;
                case State.Paused:
                    playButton.Enabled = true;
                    pauseButton.Enabled = false;
                    stopButton.Enabled = true;
                    break;
                case State.Playing:
                    playButton.Enabled = false;
                    pauseButton.Enabled = true;
                    stopButton.Enabled = true;
                    break;
            }
        }

        private void UpdateMediaPositionFromSlider(bool forceSeek)
        {
            ulong scale = (ulong)(trackBar1.Maximum - trackBar1.Minimum);
            ulong newPosMilliSec = ((ulong)trackBar1.Value * MediaDuration) / scale;
            SetMediaPosition(newPosMilliSec, forceSeek);
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            amc.TogglePause();
        }

        private void fwdStepButton_Click(object sender, EventArgs e)
        {
            amc.FrameStep(1);
        }

        private void amc_OnNewImage(object sender, EventArgs e)
        {
            // Update progress bar
            if (MediaDuration > 0)
            {
                ulong scale = (ulong)(progressBar1.Maximum - progressBar1.Minimum);
                if (amc.CurrentPosition64 > MediaDuration)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value = (int)(((amc.CurrentPosition64 * scale) / MediaDuration));
                }
            }
            else
            {
                progressBar1.Value = 0;
            }

            // Update time text box
            TimeSpan currentTime = new TimeSpan((long)amc.CurrentPosition64 * 10000); // ms -> 100-nanosecond
            TimeSpan currentDuration = new TimeSpan((long)MediaDuration * 10000); // ms -> 100-nanosecond

            string timeFormat = (currentTime.Days > 0 || currentDuration.Days > 0) ?
                "({6}) {0:D2}:{1:D2}:{2:D2} / ({7}) {3:D2}:{4:D2}:{5:D2}" :
                "{0:D2}:{1:D2}:{2:D2} / {3:D2}:{4:D2}:{5:D2}";

            string timeinfo = String.Format(timeFormat,
                currentTime.Hours, currentTime.Minutes, currentTime.Seconds,
                currentDuration.Hours, currentDuration.Minutes, currentDuration.Seconds,
                currentTime.Days, currentDuration.Days);

            currentTimeTextBox.Text = timeinfo;
        }

        private void trackBar1_KeyUp(object sender, KeyEventArgs e)
        {
            // only needed in compatibility mode
            if (compatibilityMode)
            {
                UpdateMediaPositionFromSlider(true);
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            // only needed in compatibility mode
            if (compatibilityMode)
            {
                UpdateMediaPositionFromSlider(true);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // remove this line to make seek only when slider nob is released
            UpdateMediaPositionFromSlider(false);
        }
    }
}
