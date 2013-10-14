using System.Drawing;

namespace SbBjT.Bussines.ColorDetectorCore
{
    public class ColorDetector
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private Bitmap _image;
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                _image = value;
                _detected = null;
            }
        }

        public Rectangle Area { get; set; }
        public Color Color { get; set; }

        private bool? _detected;
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


        private int _acurassi;
        public int Acurassi
        {
            get { return _acurassi; }
            set
            {
                _acurassi = value;
                Min = AddAcurassi(Color, -Acurassi);
                Max = AddAcurassi(Color, Acurassi);

            }
        }


        private Color Min;
        private Color Max;
        


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
        
        private bool Detect()
        {
            for (int y = Area.Y; y < Area.Height; y++)
            {
                for (int x = Area.X; x < Area.Width; x++)
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
    }
}
