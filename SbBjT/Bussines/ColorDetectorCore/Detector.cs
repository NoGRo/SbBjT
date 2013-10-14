using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Linq;

namespace SbBjT.Bussines.ColorDetectorCore
{

    public class Detector
    {
        public VideoCaptureDevice Video { get; set; }
        public List<ColorDetector> Detectors { get; set; }

        public void Start()
        {
            Video.NewFrame += VideoOnNewFrame;
            Video.Start();

        }

        private void VideoOnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            foreach (ColorDetector colorDetector in Detectors)
            {
                colorDetector.Image = eventArgs.Frame;
            }
            OnDetection();
        }

        public event EventHandler Detection;
        protected virtual void OnDetection()
        {
            EventHandler handler = Detection;
            if (handler != null) handler(this, EventArgs.Empty);
        }

    }
}
