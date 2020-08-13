using System;
using System.Runtime.InteropServices;

using int8_t = System.SByte;
using uint16_t = System.UInt16;
using uint8_t = System.Byte;

#pragma warning disable IDE1006 // Naming Styles
namespace Nick.Rpi.Driver
{
    internal static class NativeMethods
    {
        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_init(ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_set_regs(in uint8_t[] reg_addr, in uint8_t[] reg_data, uint8_t len, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_get_regs(uint8_t reg_addr, ref uint8_t[] reg_data, uint16_t len, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_soft_reset(ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_set_sensor_mode(ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_get_sensor_mode(ref bme680_dev dev);

        [DllImport("bme680")]
        public static extern void bme680_set_profile_dur(uint16_t duration, ref bme680_dev dev);

        [DllImport("bme680")]
        public static extern void bme680_get_profile_dur(ref uint16_t duration, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_get_sensor_data(ref bme680_field_data data, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_set_sensor_settings(uint16_t desired_settings, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true)]
        public static extern int8_t bme680_get_sensor_settings(ref uint16_t settings, ref bme680_dev dev);

        [DllImport("bme680", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int bme680_create(ref bme680_dev sensor, string device, int address);

        [DllImport("bme680", SetLastError = true)]
        public static extern int bme680_delete(ref bme680_dev sensor);

        public static void Create(ref bme680_dev sensor, string device, int address) => CheckError("Create", bme680_create(ref sensor, device, address));

        public static void Delete(ref bme680_dev sensor) => CheckError("Delete", bme680_delete(ref sensor));

        public static void SetSensorMode(ref bme680_dev dev) => CheckError("Set sensor mode", bme680_set_sensor_mode(ref dev));

        public static void SetSensorSettings(uint16_t desired_settings, ref bme680_dev dev) => CheckError("Set sensor settings", bme680_set_sensor_settings(desired_settings, ref dev));

        public static void GetSensorData(ref bme680_field_data data, ref bme680_dev dev) => CheckError("Get sensor data", bme680_get_sensor_data(ref data, ref dev));

        public static uint16_t GetProfileDuration(ref bme680_dev dev)
        {
            uint16_t duration = 0;
            bme680_get_profile_dur(ref duration, ref dev);
            return duration;
        }

        private static void CheckError(string name, int result)
        {
            if (result < 0)
            {
                var error = Marshal.GetLastWin32Error();
                throw new System.InvalidOperationException(FormattableString.Invariant($"{name} error: {error}"));
            }
        }
    }
}

#pragma warning restore IDE1006 // Naming Styles

