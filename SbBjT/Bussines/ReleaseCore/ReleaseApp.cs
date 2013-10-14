namespace SbBjT.Bussines.ReleaseCore
{
    public class ReleaseApp :IRelease
    {
        public string AppPath { get; set; }
        public string Command { get; set; }
        public void Release()
        {
            System.Diagnostics.Process.Start(AppPath,Command);
        }
    }
}
