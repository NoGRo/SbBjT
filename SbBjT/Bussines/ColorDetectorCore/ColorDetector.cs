﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
namespace SbBjT.Bussines.ColorDetectorCore
{
    
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class ColorDetector 
    {
        public ColorDetector()
        {
        }


        public ColorDetector(Detector detector)
        {
            Detector = detector;
            Detector.Detection += DetectorOnDetection;
        }

        private void DetectorOnDetection(object sender, EventArgs eventArgs)
        {
            _detected = null;
        }

        [JsonIgnore]
        public Detector Detector
        {
            private get { return _detector; }
            set
            {

                if (_detector ==  null)
                    value.Detection += DetectorOnDetection;
                _detector = value;
                
            }
        }

        private Bitmap Image
        {
            get { return Detector.CurrentFrame; }
            set { Detector.CurrentFrame = value; }
        }
        
        public Rectangle Area { get; set; }
        public Color Color
        {
            get { return _color; }
            set 
            {
                _color = value;
                CalculateMinMax();
            }
        }

        
        private bool? _detected;
        [JsonIgnore]
        public bool Detected
        {
            get
            {
                if (!_detected.HasValue)
                    _detected = Detect();
                return _detected.Value;
            }
            set { _detected = value; }
        }


        private byte _acurassi;
        public byte Acurassi
        {
            get { return _acurassi; }
            set
            {
                _acurassi = value;
                CalculateMinMax();

            }
        }

        private void CalculateMinMax()
        {
            Min = AddAcurassi(Color, -Acurassi);
            Max = AddAcurassi(Color, Acurassi);
        }
        private byte AddAcurassi(byte value, int tolerance)
        {
            int temp = value + tolerance;
            if (temp < 0)
                return 0;
            if (temp > 255)
                return 255;

            return (byte)temp;

        }
        private Color AddAcurassi(Color orig, int tolerance)
        {
            int R = AddAcurassi(Color.R, tolerance);
            int G = AddAcurassi(Color.G, tolerance);
            int B = AddAcurassi(Color.B, tolerance);
            return Color.FromArgb(R, G, B);
        }

        private Color Min;
        private Color Max;
        private Color _color;
        private Detector _detector;


        private bool Detect()
        {
            for (int y = Area.Y; y < Area.Y + Area.Height; y++)
            {
                for (int x = Area.X; x < Area.X + Area.Width; x++)
                {
                    Color pix = Image.GetPixel(x, y);
                    if ((pix.R >= Min.R && pix.R <= Max.R)
                        && (pix.G >= Min.G && pix.G <= Max.G)
                        && (pix.B >= Min.B && pix.B <= Max.B))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Paint(Color color)
        {
            if (Area.Bottom==0) return;
            BitmapData _bmp = Image.LockBits(Area, ImageLockMode.ReadWrite, Image.PixelFormat);

            unsafe
            {
                int _pixelSize = 3;
                byte* _current = (byte*) (void*) _bmp.Scan0;
                int _nWidth = _bmp.Width*_pixelSize;
                int _nHeight = _bmp.Height;

                
                for (int y =0; y < _nHeight; y++)
                {
                    for (int x =0; x < _nWidth;x++ )
                    {
                         if (x % _pixelSize ==0|| x ==0)
                        {
                             
                         }
                      _current++;
                     }
                }
            }

            

            return;
            for (int y = Area.Y; y < Area.Y +Area.Height; y++)
            {
                for (int x = Area.X; x < Area.X + Area.Width; x++)
                {
                    Color pix = Image.GetPixel(x, y);

                    float avghue = (pix.GetHue() + _color.GetHue())/2;
                    float distance = Math.Abs(_color.GetHue() - avghue);
                    
                    if (distance < Acurassi)
                        Image.SetPixel(x, y, color);
                    
                }
            }
        }

    }
}
