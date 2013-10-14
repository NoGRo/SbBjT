using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SbBjT.Bussines;
namespace SbBjT.Controls
{
    public partial class DurationSelect : UserControl
    {

        public bool ShowRandom { get { return chkRandom.Visible; }
            set { chkRandom.Visible = value; }
        }
        private bool _showMax;
        public bool ShowMax
        {
            get { return _showMax; }
            set
            {
                lblMax.Visible = value;
                nrMax.Visible = value;
                _showMax = value;
            }
        }
        private string _metric;
        public string Metric
        {
            get
            {
                if (string.IsNullOrEmpty(_metric)) _metric = "Value:";
                
                return _metric;
            }
            set
            {
                _metric = value.Replace(":", "") + ":";
                lblValue.Text = "";
            }
        }

        public string Title { 
            get { return gbTitle.Text; }
            set{ gbTitle.Text = value;}
        }

        private Duration _duration = new Duration();
        

        public Duration Duration
        {
            get
            {
                Fill();
                return _duration;
            }
            set
            {
                _duration = value;
                Load();
            }
        }

        private void Fill()
        {
            _duration.Randomize = chkRandom.Checked;
            if (_duration.Randomize)
            {
                _duration.Max = int.Parse(nrMax.Text);
                _duration.Min = int.Parse(nrMin.Text);

            }
            else
            {
                _duration.Value = int.Parse(nrValue.Text);
                if (ShowMax)
                    _duration.Max = int.Parse(nrMax.Text);
            }
        }

        public void Load()
        {
            chkRandom.Checked = ShowRandom && _duration.Randomize;
            
            chkRandom_CheckedChanged(null, null);

            if (_duration.Randomize)
            {
                nrMax.Value = _duration.Max;
                nrMin.Value = _duration.Min;    
            }
            else
            {
                nrValue.Value = _duration.Value;
                if (ShowMax)
                    nrMax.Value = _duration.Max;
            }
        }

        public DurationSelect()
        {
            InitializeComponent();

        }

        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            
            nrValue.Visible = !chkRandom.Checked;
            nrMin.Visible = chkRandom.Checked;
            lblMin.Visible = chkRandom.Checked;

            if (!ShowMax)
            {
                nrMax.Visible = chkRandom.Checked;
                lblMax.Visible = chkRandom.Checked;
            }
        }

        private void gbTitle_Enter(object sender, EventArgs e)
        {

        }
    }
}
