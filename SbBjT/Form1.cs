using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SbBjT.Bussines;
using SbBjT.Bussines.BlowJobCore;
using SbBjT.Bussines.VoiceCore;

namespace SbBjT
{
    public partial class Form1 : Form
    {
        Master master = new Master();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            master.Voice = new Voice("Woman", "Woman");
            master.Dick = new Dick();
            original = pictureBox1.Image;
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {            
            master.Personality =  new Personality();
            master.Personality.BlowJobType=  new BlowJobType();
            master.Personality.BlowJobType.Sucks = durSuck.Duration;

            BlowJob blowJob = master.GetBlowJob();
            
            blowJob.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = (char)e.KeyChar;
            switch (key.ToString())
            {
                case "1":
                    master.Dick.FeelWhat(new DickPart(PartName.Out));
                    break;
                case "2":
                    master.Dick.FeelWhat(new DickPart(PartName.Medium));
                    break;
                case "3":
                    master.Dick.FeelWhat(new DickPart(PartName.Deep));
                    break;
            }

        }

     


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Tolerance = trackBar1.Value;
            BuscarColor();
        }

    }
    
}
