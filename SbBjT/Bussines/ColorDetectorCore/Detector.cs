using System;
using System.Collections.Generic;
using System.Drawing;
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
        public byte Accurasi
        {
            get { return _accurasi; }
            set {
                _accurasi = value; 
                Detectors.ForEach(x=> x.Acurassi = value);
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



        private void VideoOnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (Detect)
            {
                CurrentFrame = (Bitmap)eventArgs.Frame.Clone();
                //Detectors.ForEach(x => x.Image = (Bitmap)eventArgs.Frame.Clone());
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
