using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SbBjT.Bussines;
using SbBjT.Bussines.ColorDetectorCore;
using SbBjT.Bussines.BlowJobCore;
using SbBjT.Bussines.VoiceCore;
using AForge.Video;
using AForge.Video.DirectShow;

namespace SbBjT
{
    public partial class Form1 : Form
    {
        Master master = new Master();
        FilterInfoCollection videoDevices;
        public Form1()
        {
            InitializeComponent();

            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }

                for (int i = 1, n = videoDevices.Count; i <= n; i++)
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;

                    camera1Combo.Items.Add(cameraName);
                }

                camera1Combo.SelectedIndex = 0;
            }
            catch
            {
                camera1Combo.Items.Add("No cameras found");

                camera1Combo.SelectedIndex = 0;

                camera1Combo.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            master.Voice = new Voice("Woman", "Woman");
            master.Dick = new Dick();
           
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[camera1Combo.SelectedIndex].MonikerString);
            //videoSource1.DesiredFrameRate = 10;

            videoSourcePlayer1.VideoSource = videoSource1;
            //videoSourcePlayer1.Start();

            Detector detector = new Detector();
            detector.Video = videoSource1;
            detector.Start();
            
            /*
            master.Personality =  new Personality();
            master.Personality.BlowJobType=  new BlowJobType();
            master.Personality.BlowJobType.Sucks = durSuck.Duration;

            BlowJob blowJob = master.GetBlowJob();
            
            blowJob.Start();
            */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

     
        
        private void camera1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
    
}
