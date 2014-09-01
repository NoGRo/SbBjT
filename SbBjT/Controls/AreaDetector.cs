using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using SbBjT.Bussines.ColorDetectorCore;
using SbBjT.Bussines;

namespace SbBjT.Controls
{

    
    public partial class AreaDetector : UserControl
    {
        
        private bool Pickcolor = false;
        public Detector Detector;
        public bool Paint = true;
        
        private Point OrigPoiny= new Point();
        private ColorDetector currentColorDetector;
         [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public Dick Dick { get; set; }

        public AreaDetector()
        {

            InitializeComponent();
        }
        private void AreaDetector_Load(object sender, EventArgs e)
        {

            
            

        }



        private void DetectorOnDetection(object sender, EventArgs eventArgs)
        {

            if (Detector.CurrentFrame != null)
            {

                try
                {



                    Graphics gImg = Graphics.FromImage(Detector.CurrentFrame);
                    if (Detector.Detectors != null && Detector.Detectors.Count > 0)
                    {
                        Pen p = new Pen(Color.Black, 2);
                        foreach (ColorDetector colorDetector in Detector.Detectors)
                        {
                            if (Paint)
                                colorDetector.Paint(Color.Green);
                            
                            gImg.DrawRectangle(p, colorDetector.Area);
                            

                        }
                   }
                    gImg = null;
                    Graphics g = pnlWebCam.CreateGraphics();
                    g.DrawImage(Detector.CurrentFrame, 0, 0);
                }
                catch (Exception)
                {

                    
                }
              
                
            }

        }

        private bool isMouseDown;

        


        public void start()
        {

            Detector = Detector == null ? new Detector() : Detector;

            Detector.Detection += DetectorOnDetection;
            Dick = new Dick(Detector);
            if (!Detector.Detectors.Any())
            {
                for (int i = 0; i < 4; i++)
                {
                    Detector.Detectors.Add(new ColorDetector());
                }
            }
            Detector.Detectors.ForEach(x=> x.Detector = Detector);

            var cd = Detector.Detectors[0];
            Dick.DickParts.Add(new DickPart(PartName.Tip, cd));
            cd = Detector.Detectors[1];
            Dick.DickParts.Add(new DickPart(PartName.Medium, cd));
            cd = Detector.Detectors[2];
            Dick.DickParts.Add(new DickPart(PartName.Deep, cd));
            cd = Detector.Detectors[3];
            Dick.DickParts.Add(new DickPart(PartName.RealyDeep, cd));

            cmbDickPart.DataSource = Dick.DickParts;
            cmbDickPart.DisplayMember = "strName";

            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Detector.Video = new VideoCaptureDevice(videoDevices[0].MonikerString);
            Detector.Start();
            
        }
    
        private void cmbDickPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentColorDetector = ((DickPart) cmbDickPart.SelectedItem).ColorDetector;
        }

        private void pnlWebCam_MouseDown(object sender, MouseEventArgs e)
        {
            if (Pickcolor) return;
             
            isMouseDown = true;
            Paint = false;
            var cd = currentColorDetector;

            OrigPoiny.X = e.X;
            OrigPoiny.Y = e.Y ;
            cd.Area = new Rectangle(e.X, e.Y, 0, 0);
            
        }

        private void pnlWebCam_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown) return;

            var cd = currentColorDetector;
            
            int x, y, xs , ys;
            
            if (e.X > OrigPoiny.X)
            {
                x = OrigPoiny.X;
                xs = e.X - OrigPoiny.X;
            }
            else
            {
                x = e.X;
                xs = OrigPoiny.X  - e.X ;
            }
            if (e.Y > OrigPoiny.Y)
            {
                y = OrigPoiny.Y;
                ys = e.Y - OrigPoiny.Y;
            }
            else
            {
                y = e.Y;
                ys = OrigPoiny.Y - e.Y;
            }


            cd.Area =  new Rectangle(x,y,xs,ys);
        }

        private void pnlWebCam_MouseUp(object sender, MouseEventArgs e)
        {

            Bitmap picColor = null;
            bool ok = false;
            while (!ok)
            {
                try
                {
                    picColor = (Bitmap)Detector.CurrentFrame.Clone();
                    ok = true;
                }
                catch (Exception)
                {

                }

            }

            if (Pickcolor)
            {
                Detector.Detectors.ForEach(x => x.Color = picColor.GetPixel(e.X, e.Y));
                btnPick.Enabled = true;
                Pickcolor = false;
                return;
            }
            var cd = currentColorDetector;
       
           

            cd.Color = picColor.GetPixel(cd.Area.X + cd.Area.Width / 2, cd.Area.Y + cd.Area.Height / 2);    
            


            cmbDickPart.SelectedIndex = cmbDickPart.SelectedIndex == cmbDickPart.Items.Count -1
                                            ? cmbDickPart.SelectedIndex
                                            : cmbDickPart.SelectedIndex + 1;


            isMouseDown = false;
            Paint = true;
        }

        private void pnlWebCam_MouseLeave(object sender, EventArgs e)
        {
            isMouseDown = false;
            
        }

        private void pnlWebCam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            Pickcolor = true;
            btnPick.Enabled = false;
        }



    }
}
