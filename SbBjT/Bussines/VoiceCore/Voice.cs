using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using WMPLib;

namespace SbBjT.Bussines.VoiceCore
{


    public class Voice
    {
        public string Name { get; set; }
        public string FolderName { get; set; }
        private Dictionary<Say,SaySound> SaySounds = new Dictionary<Say, SaySound>();
        private List<SoundPlayer> Players = new List<SoundPlayer>();
        WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        private int lastuse = 0;
        public void Talk(Say say)
        {

            
            
            //player.URL = GetSayPath(say);
            Players[0].SoundLocation = GetSayPath(say);
            Players[0].Play();

            /*
            lastuse = lastuse == 0 ? 1 : 0;
            SoundPlayer Playtemp = Players[lastuse];
            Playtemp.Stop();
            Playtemp.SoundLocation = GetSayPath(say);*/

        }

        private string GetSayPath(Say say)
        {
            string audioPath;
            SaySound saySound = SaySounds[say];
            if (saySound.Have)
            {
                return saySound.GetRandom();
            }
            else
            {
                //logica de remplazo para desarrollar caca
            }

            return "";
        }

   

        public Voice(string name, string folderName)
        {
            Name = name;
            FolderName = folderName;
            Players.Add(new SoundPlayer());
            ;

            string path = Application.StartupPath;
            path = path + "\\Voices\\" + FolderName + "\\";
            foreach (Say say in Enum.GetValues(typeof(Say)))
            {
                SaySounds.Add(say,new SaySound(say));
                string sSay = say.ToString();

                for (int i = -1; i < 30; i++)
                {

                    FileInfo fileInfo = new FileInfo(path +
                        sSay +
                        (i == -1 ? "": i.ToString() ) +
                        ".wav");
                    
                    if (fileInfo.Exists)
                    {
                        SaySounds[say].AddSound(fileInfo.FullName);

                    }
                    
                }
                


            }
        }
        
    }
            
}
