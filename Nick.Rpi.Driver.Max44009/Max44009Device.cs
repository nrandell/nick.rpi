using System.Runtime.InteropServices;

namespace Nick.Rpi.Driver
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct Max44009Device
    {
        public int fd;
    }
}
