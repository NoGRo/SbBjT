using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace SbBjT.Bussines.VoiceCore
{


    public class Voice
    {
        public string Name { get; set; }
        public string FolderName { get; set; }
        private Dictionary<Say,SaySound> SaySounds = new Dictionary<Say, SaySound>();
        private SoundPlayer Player = new SoundPlayer();

        public void Talk(Say say)
        {
            Player.Stop();
            Player.SoundLocation = GetSayPath(say);
            Player.Play();
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
