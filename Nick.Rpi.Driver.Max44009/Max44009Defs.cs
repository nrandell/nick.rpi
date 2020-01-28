using System.Runtime.InteropServices;

using int8_t = System.SByte;

namespace Nick.Rpi.Driver.Max44009
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct Max44009Device
    {
        public int fd;
    }

    public static class Api
    {
#pragma warning disable IDE1006 // Naming Styles
        [DllImport("max44009", SetLastError = true)]
        public static extern int max44009_create(ref Max44009Device sensor, string device, int address);

        [DllImport("max44009", SetLastError = true)]
        public static extern int8_t max44009_reset(ref Max44009Device sensor);

        [DllImport("max44009", SetLastError = true)]
        public static extern int8_t max44009_read(ref Max44009Device sensor, out float luminance);
#pragma warning restore IDE1006 // Naming Styles

        public static void Create(ref Max44009Device sensor, string device, int address) =>
            CheckError("Create", max44009_create(ref sensor, device, address));

        public static void Reset(ref Max44009Device sensor) => CheckError("Reset", max44009_reset(ref sensor));

        public static float Read(ref Max44009Device sensor)
        {
            CheckError("Read", max44009_read(ref sensor, out var result));
            return result;
        }

        private static void CheckError(string name, int result)
        {
            if (result < 0)
            {
                var error = Marshal.GetLastWin32Error();
                throw new System.InvalidOperationException($"{name} error: {error}");
            }
        }
    }
}
