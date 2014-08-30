using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//referencia axis
using AXISMEDIACONTROLLib;


namespace IDstore
{
    enum MediaType
    {
        mjpeg,
        h264,
        mpeg4
    }

    public partial class AxisCamaraIP : Form
    {
        public AxisCamaraIP()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

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

            this.myTypeBox.Items.AddRange(new object[] { MediaType.h264, MediaType.mpeg4, MediaType.mjpeg });
            this.myTypeBox.SelectedIndex = 2;
        }

        private void AxisCamaraIP_Load(object sender, EventArgs e)
        {

        }

        private void myPlayButton_Click(object sender, EventArgs e)
        {
            //Stop possible streams
            amc.Stop();

            // Set properties, deciding what url completion to use by MediaType.
            amc.MediaUsername = myUserBox.Text;
            amc.MediaPassword = myPassBox.Text;
            amc.MediaURL = CompleteURL(myUrlBox.Text, (MediaType)myTypeBox.SelectedItem);

            //  textBox1.Text = CompleteURL(myUrlBox.Text, (MediaType)myTypeBox.SelectedItem);
            // Start the streaming
            amc.Play();

            // check for stream errors in OnError event
        }

        private void myPlayFileButton_Click(object sender, EventArgs e)
        {
            // Set the MediaFile property to the selected file.
            FileDialog aDialog = new OpenFileDialog();
            if (aDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Stop possible streams
                amc.Stop();

                amc.MediaFile = aDialog.FileName;
                amc.Play();
            }
        }
       
        private void myStopButton_Click(object sender, EventArgs e)
        {
            // Stop the stream (will also stop any recording in progress).
            amc.Stop();
        }

        private void myRecordButton_Click(object sender, EventArgs e)
        {//capturar video
            if ((amc.Status & (int)AMC_STATUS.AMC_STATUS_RECORDING) > 0)
            {
                amc.StopRecordMedia();
            }
            else
            {
                // Start the recording (video and audio)
                int recordingFlag = (int)AMC_RECORD_FLAG.AMC_RECORD_FLAG_AUDIO_VIDEO;
                if (MediaType.mjpeg == (MediaType)myTypeBox.SelectedItem)
                {
                    // Audio recording is not supported for Motion JPEG over HTTP
                    recordingFlag = (int)AMC_RECORD_FLAG.AMC_RECORD_FLAG_VIDEO;
                }

                amc.StartRecordMedia(myFileBox.Text, recordingFlag, "");
            }
        }

        private void myFileDialogButton_Click(object sender, EventArgs e)
        {
            FileDialog aDialog = new SaveFileDialog();
            if (aDialog.ShowDialog(this) == DialogResult.OK)
            {
                myFileBox.Text = aDialog.FileName;
            }
        }

        private void btnsavejpeg_Click(object sender, EventArgs e)
        {//capturar foto
            amc.SaveCurrentImage(0, "C:\\AXIS\\AXIS.jpg");
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
       

       

       

        private void amc_OnStatusChange(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnStatusChangeEvent e)
        {
            if ((e.theOldStatus & (int)AMC_STATUS.AMC_STATUS_RECORDING) == 0 && // was not recording
                    (e.theNewStatus & (int)AMC_STATUS.AMC_STATUS_RECORDING) > 0) // is recording
            {
                myRecordButton.Text = "Stop Recording";
            }
            else
            {
                myRecordButton.Text = "Record";
            }
        }

        private void amc_OnError(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnErrorEvent e)
        {
            System.Windows.Forms.MessageBox.Show(this, e.theErrorInfo, "Error code " + e.theErrorCode.ToString("X8"));
        }

        private void amc_OnNewVideoSize(object sender, AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnNewVideoSizeEvent e)
        {
            if (e.theWidth >= 320 && e.theHeight >= 240)
            {
                // Adapt window size to video size
                Width += e.theWidth - amc.Width;
                Height += e.theHeight - amc.Height;

                if (amc.ShowStatusBar)
                {
                    Height += 22;
                }

                if (amc.ShowToolbar)
                {
                    Height += 32;
                }
            }
        }

    }
}
