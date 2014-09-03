using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Linq;
using Newtonsoft.Json;

namespace SbBjT.Bussines.ColorDetectorCore
{

    [Serializable]
    public class Detector
    {
        [JsonIgnore]
        public VideoCaptureDevice Video { get; set; }

        public List<ColorDetector> Detectors { get; set; }
        public bool Detect { get; set; }
        private byte _accurasi;
        public Color PaintColor { get; set; }
        public bool Paint { get; set; }
        public byte Accurasi
        {
            get { return _accurasi; }
            set
            {
                _accurasi = value;
                Detectors.ForEach(x => x.Acurassi = value);
            }
        }

        [JsonIgnore]
        public Bitmap CurrentFrame { get; set; }

        public Detector()
        {
            Detect = true;
            Detectors = new List<ColorDetector>();
        }

        public void Start()
        {
            Video.NewFrame += VideoOnNewFrame;
            Video.Start();

        }


        public void Process()
        {
            if (!Detect && !Paint) return;

            Detectors.ForEach(x=> x.Detected=false);

            BitmapData _bmp = CurrentFrame.LockBits(new Rectangle(0, 0, CurrentFrame.Width, CurrentFrame.Height), ImageLockMode.ReadWrite, CurrentFrame.PixelFormat);

            unsafe
            {
                int _pixelSize = 3;
                byte* _current = (byte*) (void*) _bmp.Scan0;
                int _nWidth = _bmp.Width;
                int _nHeight = _bmp.Height;


                for (int y = 0; y < _nHeight; y++)
                {

                    for (int x = 0; x < _nWidth; x++)
                    {


                        foreach (var colorDetector in Detectors)
                        {
                            if (colorDetector.Area.Contains(x, y))
                            {

                                Color colPix = Color.FromArgb(255, _current[0], _current[1], _current[2]);
         
                                if (Math.Abs(colPix.GetHue() - colorDetector.Color.GetHue()) < colorDetector.Acurassi
                                    && (Math.Abs(colorDetector.Color.GetSaturation() - colPix.GetSaturation()) < (colorDetector.Acurassi * 0.01))
                                    && (Math.Abs(colorDetector.Color.GetBrightness() - colPix.GetBrightness()) < (colorDetector.Acurassi * 0.01)))
                                {
                                    if (Detect)
                                    {
                                        colorDetector.Detected = true;
                                    }

                                    if (Paint)
                                    {
                                        _current[0] = PaintColor.R;
                                        _current[1] = PaintColor.G;
                                        _current[2] = PaintColor.B;
                                    }


                                }
                            }

                        }
                        

                        for (int i = 0; i < _pixelSize; i++)
                            _current++;
                        
                    }
                }
            }
            CurrentFrame.UnlockBits(_bmp);
        }

        


        private void VideoOnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (Detect)
            {
                CurrentFrame = (Bitmap)eventArgs.Frame.Clone();
                //Detectors.ForEach(x => x.Image = (Bitmap)eventArgs.Frame.Clone());
                Process();

                OnDetection();
            }
        }

        public event EventHandler Detection;
        protected virtual void OnDetection()
        {
            EventHandler handler = Detection;
            if (handler != null) handler(this, EventArgs.Empty);
        }

    }
}
