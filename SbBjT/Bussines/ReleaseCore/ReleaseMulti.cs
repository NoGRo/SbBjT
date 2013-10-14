using System.Collections.Generic;

namespace SbBjT.Bussines.ReleaseCore
{
    public class ReleaseMulti : IRelease
    {
        public List<IRelease> Releases { get; set; }
        public void Release()
        {
            Releases.ForEach(x=> x.Release());
        }
    }
}
