using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using SbBjT.Bussines;
using SbBjT.Bussines.ColorDetectorCore;
using SbBjT.Bussines.BlowJobCore;
using SbBjT.Bussines.PunishCore;
using SbBjT.Bussines.VoiceCore;
using AForge.Video;
using AForge.Video.DirectShow;
using Newtonsoft.Json;

namespace SbBjT
{
    public partial class Form1 : Form
    {
        #region Reg help
        public bool RegWrite(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = Registry.CurrentUser;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey("SOFTWARE\\" + Application.ProductName);
                // Save the value
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                return false;
            }
        }
        public string RegRead(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = Registry.CurrentUser;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey("SOFTWARE\\" + Application.ProductName);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    // AAAAAAAAAAARGH, an error!

                    return null;
                }
            }
        }
        #endregion
        Master master = new Master();
        private BlowJob blowJob = null;
        FilterInfoCollection videoDevices;
        public Form1()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();


            #region combo camaras


            //try
            //{
            //    // enumerate video devices
            //    videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //    if (videoDevices.Count == 0)
            //    {
            //        throw new Exception();
            //    }

            //    for (int i = 1, n = videoDevices.Count; i <= n; i++)
            //    {
            //        string cameraName = i + " : " + videoDevices[i - 1].Name;

            //        camera1Combo.Items.Add(cameraName);
            //    }

            //    camera1Combo.SelectedIndex = 0;
            //}
            //catch
            //{
            //    camera1Combo.Items.Add("No cameras found");

            //    camera1Combo.SelectedIndex = 0;

            //    camera1Combo.Enabled = false;
            //}

            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            master.Voice = new Voice("Beep", "Beep");
            
            areaDetector1.Detector = JsonConvert.DeserializeObject<Detector>(RegRead("Detector"));

            areaDetector1.start();

            /*
             *             Dick = new Dick(Detector);
                
            var cd = new ColorDetector(Detector);
            Dick.DickParts.Add(new DickPart(PartName.Tip, cd));
            cd = new ColorDetector(Detector);
            Dick.DickParts.Add(new DickPart(PartName.Medium, cd));
            cd = new ColorDetector(Detector);
            Dick.DickParts.Add(new DickPart(PartName.Deep, cd));
            cd = new ColorDetector(Detector);
            Dick.DickParts.Add(new DickPart(PartName.RealyDeep, cd));
             */




        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           
        }




        private void areaDetector1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            areaDetector1.Detector.Accurasi = (byte)trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            areaDetector1.Paint = false;
            RegWrite("Detector", JsonConvert.SerializeObject(areaDetector1.Detector));
            
            master.Dick = areaDetector1.Dick;
            master.Personality =  new Personality()
                {
                    BlowJobType=new BlowJobType()
                        {
                            Rest= new Rest(){Have=false},
                            Speed = new Duration(3),
                            Sucks = new Duration(40),
                            Behavior = new EveryRandom(3,10,PartName.Deep)
                        }
                };

            blowJob = master.GetBlowJob();
            //blowJob.Punish.Punishes.Add(new PunishSuckDo(blowJob,PartName.RealyDeep));
            blowJob.Punish.Punishes.Add(new PunishSuckIncrease(blowJob,new Duration(1,5)));

            blowJob.SuckLeftChange += BlowJobOnSuckLeftChange;

            blowJob.Start();

        }

        private void BlowJobOnSuckLeftChange(object sender, EventArgs eventArgs)
        {
            //lblLeft.Text = blowJob.SucksLeft.ToString();
        }
    }
    
}
