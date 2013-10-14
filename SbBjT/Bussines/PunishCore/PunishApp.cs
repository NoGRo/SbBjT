using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishApp : IPunish
    {
        public PunishApp(string appPath)
        {
            AppPath = appPath;
        }

        public PunishApp(string appPath, string command)
        {
            AppPath = appPath;
            Command = command;
        }

        public string AppPath { get; set; }
        public string Command { get; set; }
        public void Punish()
        {
            System.Diagnostics.Process.Start(AppPath, Command);
        }
    }
}
