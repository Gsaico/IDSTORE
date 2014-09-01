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
//paratrabajar con archivos
using System.IO;
using System.Reflection;
//referencia axis
using AXISMEDIACONTROLLib;
namespace IDstore
{
    //  enum MediaType
    //   {
    //      mjpeg,
    //      h264,
    //      mpeg4
    //   }
    public partial class AbastecerCombustible : Form
    {



        public AbastecerCombustible(String idregistrotemp)
        {
            InitializeComponent();

            this.idregistro = idregistrotemp;
            // We set AMC properties here for clarity
            amc.StretchToFit = true;
            amc.MaintainAspectRatio = true;
            amc.ShowStatusBar = true;
            amc.BackgroundColor = 0; // black
            amc.VideoRenderer = (int)AMC_VIDEO_RENDERER.AMC_VIDEO_RENDERER_VMR9;
            amc.EnableOverlays = true;

            // Configure context menu
            amc.EnableContextMenu = true;
            amc.ToolbarConfiguration = "+play,+fullscreen,-settings"; //"-pixcount" to remove pixel counter

            // AMC messaging setting
            amc.Popups = (int)AMC_POPUPS.AMC_POPUPS_LOGIN_DIALOG; // Allow login dialog
            amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_NO_VIDEO; // "No Video" message when stopped
            //amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_MESSAGES; // Yellow-balloon notification

            //  this.myTypeBox.Items.AddRange(new object[] { MediaType.h264, MediaType.mpeg4, MediaType.mjpeg });
            //  this.myTypeBox.SelectedIndex = 2;
        }
        String idregistro;
        String pathsnapshotvideo;
        private void gbCombustible_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodigoAbastecimiento_TextChanged(object sender, EventArgs e)
        {


            //listar los datos del codigo de abastecimiento   sp_listar_Abastecimiento

            //sp_Volumen_Autorizado

            // sp_Sumar_Volumen_Retirado


        }

        private void txtCodigoAbastecimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //recupero la informacion del codigo de abastecimiento asignado al chofer
                CE_Abastecimiento objce_abastecimiento = new CE_Abastecimiento();
                CN_Abastecimiento objcn_abastecimiento = new CN_Abastecimiento();
                objce_abastecimiento.codigo_abastecimiento = txtCodigoAbastecimiento.Text;
                objce_abastecimiento = objcn_abastecimiento.ListarAbastecimiento(objce_abastecimiento);

                this.lblDNI.Text = objce_abastecimiento.dni;
                this.lblvolumen_autorizado.Text = Convert.ToString(objce_abastecimiento.volumen_autorizado);
                this.lblidplacavehiculo.Text = objce_abastecimiento.idplacavehiculo;
                this.lblIdtanque.Text = objce_abastecimiento.idtanque;
                this.rbActivo.Checked = (objce_abastecimiento.estado == "1" ? true : false);
                this.rbActivo.Text = (this.rbActivo.Checked == true ? "Habilitado" : "Deshabilitado");

                // recupero la cantidad de volumen retirado
                CE_TanqueDetalleMov objce_tanquedetallemov = new CE_TanqueDetalleMov();
                CN_TanqueDetalleMov objcn_tanquedetallemov = new CN_TanqueDetalleMov();

                objce_tanquedetallemov.codigo_abastecimiento = txtCodigoAbastecimiento.Text;
                objce_tanquedetallemov = objcn_tanquedetallemov.SumarVolumenRetirado(objce_tanquedetallemov);
                this.lblVolumenRetirado.Text = Convert.ToString(objce_tanquedetallemov.totalretirado );
                // muestro la cantidad decombustible por retirar
                this.lblVolumenxretirar.Text = Convert.ToString(objce_abastecimiento.volumen_autorizado - Convert.ToDouble(objce_tanquedetallemov.totalretirado));
            }
        }

        private void btnAbastecerCombustible_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(txtGalones.Text) <= Convert.ToInt64(lblVolumenxretirar.Text))
            {

                timer1.Enabled = true;
               

              

                CE_TanqueDetalleMov objce_tanquedetallemov = new CE_TanqueDetalleMov();
                CN_TanqueDetalleMov objcn_tanquedetallemov = new CN_TanqueDetalleMov();
                string pathsnapshot;
                pathsnapshot = @"C:\AXIS\" + idregistro + ".jpg";
                pathsnapshotvideo = @"C:\AXIS\" + idregistro + ".asf";
                btnsavejpeg(pathsnapshot);
                myRecordButton(pathsnapshotvideo);
             

                objce_tanquedetallemov.idtanque = lblIdtanque.Text;
                objce_tanquedetallemov.idregistro = idregistro;
                objce_tanquedetallemov.codigo_abastecimiento = txtCodigoAbastecimiento.Text;
                objce_tanquedetallemov.volumen_retirado = Convert.ToDouble(txtGalones.Text);
                objce_tanquedetallemov.snapshotpicture = pathsnapshot;
                objce_tanquedetallemov.snapshotvideo = pathsnapshotvideo;
                objce_tanquedetallemov.idtipooperacion = "0";//0= salida de conbustible
                objcn_tanquedetallemov.NuevoTanqueDetalleMov(objce_tanquedetallemov);
            }
            else 
            {
                MessageBox.Show("Usted no puede retirar mas combustible", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void myPlay()
        {
            //Stop possible streams
            amc.Stop();

            // Set properties, deciding what url completion to use by MediaType.
            amc.MediaUsername = "ROOT";
            amc.MediaPassword = "12345";
            amc.MediaURL = CompleteURL("169.254.1.55", MediaType.mjpeg);

            //  textBox1.Text = CompleteURL(myUrlBox.Text, (MediaType)myTypeBox.SelectedItem);
            // Start the streaming
            amc.Play();

            // check for stream errors in OnError event
        }
        private void myPlayFileButton()
        { // Set the MediaFile property to the selected file.
            FileDialog aDialog = new OpenFileDialog();
            if (aDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Stop possible streams
                amc.Stop();

                amc.MediaFile = aDialog.FileName;
                amc.Play();
            }
        }
        private void myStopButton()
        {
            // Stop the stream (will also stop any recording in progress).
            amc.Stop();
        }

        private void myRecordButton(String pathsrc)
        {

            //capturar video
            if ((amc.Status & (int)AMC_STATUS.AMC_STATUS_RECORDING) > 0)
            {
                amc.StopRecordMedia();
            }
            else
            {
                // Start the recording (video and audio)
                int recordingFlag = (int)AMC_RECORD_FLAG.AMC_RECORD_FLAG_AUDIO_VIDEO;
                if (MediaType.mjpeg == MediaType.mjpeg)
                {
                    // Audio recording is not supported for Motion JPEG over HTTP
                    recordingFlag = (int)AMC_RECORD_FLAG.AMC_RECORD_FLAG_VIDEO;
                }

                amc.StartRecordMedia(AppPath(pathsrc), recordingFlag, "");
            }
        }
        private string AppPath(String pathsrc)
        {
            string strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            string strFullPathToMyFile = Path.Combine(strAppDir, pathsrc);

            return strFullPathToMyFile;

        }
        private void btnsavejpeg(string pathsnapshot)
        {
            //capturar foto
            amc.SaveCurrentImage(0, pathsnapshot);
        }
        private string CompleteURL(string theMediaURL, MediaType theMediaType)
        {
            string anURL = theMediaURL;
            if (!anURL.EndsWith("/")) anURL += "/";

            switch (theMediaType)
            {
                case MediaType.mjpeg:
                    anURL += "axis-cgi/mjpg/video.cgi";
                    break;
                case MediaType.mpeg4:
                    anURL += "mpeg4/media.amp";
                    break;
                case MediaType.h264:
                    anURL += "axis-media/media.amp?videocodec=h264";
                    break;
            }

            anURL = CompleteProtocol(anURL, theMediaType);
            return anURL;
        }
        private string CompleteProtocol(string theMediaURL, MediaType theMediaType)
        {
            if (theMediaURL.IndexOf("://") >= 0) return theMediaURL;

            string anURL = theMediaURL;

            switch (theMediaType)
            {
                case MediaType.mjpeg:
                    // This example streams Motion JPEG over HTTP multipart (only video)
                    // See docs on how to receive unsynchronized audio with Motion JPEG
                    anURL = "http://" + anURL;
                    break;
                case MediaType.mpeg4:
                case MediaType.h264:
                    // Use RTP over RTSP over HTTP (for other transport mechanisms see docs)
                    anURL = "axrtsphttp://" + anURL;
                    break;
            }

            return anURL;
        }

        private void AbastecerCombustible_Load(object sender, EventArgs e)
        {
            myPlay();
        }

        private void amc_OnStatusChange(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnStatusChangeEvent e)
        {
            if ((e.theOldStatus & (int)AMC_STATUS.AMC_STATUS_RECORDING) == 0 && // was not recording
                   (e.theNewStatus & (int)AMC_STATUS.AMC_STATUS_RECORDING) > 0) // is recording
            {
                lblestadoaxisrecord.Text = "Stop Recording";
            }
            else
            {
                lblestadoaxisrecord.Text = "Record";
            }
        }

        private void amc_OnError(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnErrorEvent e)
        {
            System.Windows.Forms.MessageBox.Show(this, e.theErrorInfo, "Error code " + e.theErrorCode.ToString("X8"));
        }

        private void amc_OnNewVideoSize(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnNewVideoSizeEvent e)
        {
            //if (e.theWidth >= 320 && e.theHeight >= 240)
            //{
            //    // Adapt window size to video size
            //    Width += e.theWidth - amc.Width;
            //    Height += e.theHeight - amc.Height;

            //    if (amc.ShowStatusBar)
            //    {
            //        Height += 22;
            //    }

            //    if (amc.ShowToolbar)
            //    {
            //        Height += 32;
            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
          

             amc.Stop();

             timer1.Enabled = false;
        }


    }
}
