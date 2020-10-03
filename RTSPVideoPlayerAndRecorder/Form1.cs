using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.MediaFramework.RTSPSource;
using VisioForge.Types.OutputFormat;
using VisioForge.Types.Sources;

namespace RTSPVideoPlayerAndRecorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            
            videoCapture1.IP_Camera_Source = new VisioForge.Types.Sources.IPCameraSourceSettings() { URL = "rtsp://localhost:8554/streaming", Type = VisioForge.Types.VFIPSource.Auto_LAV};
            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;
            videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.IPPreview;

            videoCapture1.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            videoCapture1.Stop();
        }

        private void btRecord_Click(object sender, EventArgs e)
        {
            videoCapture1.IP_Camera_Source = new VisioForge.Types.Sources.IPCameraSourceSettings() { URL = "rtsp://localhost:8554/streaming", Type = VisioForge.Types.VFIPSource.Auto_LAV };
            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;
            videoCapture1.Output_Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "\\streamed.mp4";
            videoCapture1.Output_Format = new VFWMVOutput();
            videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.IPCapture;

            videoCapture1.Start();
        }
    }
}
