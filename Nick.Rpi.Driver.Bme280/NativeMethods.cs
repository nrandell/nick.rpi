using System;
using System.Runtime.InteropServices;

using int8_t = System.SByte;
using uint16_t = System.UInt16;
using uint8_t = System.Byte;

namespace Nick.Rpi.Driver
{
    internal static class NativeMethods
    {
        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_init(ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_set_regs(in uint8_t[] reg_addr, in uint8_t[] reg_data, uint8_t len, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_get_regs(uint8_t reg_addr, ref uint8_t[] reg_data, uint16_t len, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_set_sensor_settings(uint16_t desired_settings, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_get_sensor_settings(ref uint16_t settings, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int bme280_create(ref bme280_dev sensor, string device, int address);

        [DllImport("bme280", SetLastError = true)]
        public static extern int bme280_delete(ref bme280_dev sensor);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_set_sensor_mode(uint8_t sensor_mode, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_get_sensor_mode(ref uint8_t sensor_mode, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_soft_reset(ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_get_sensor_data(uint8_t sensor_comp, ref bme280_data comp_data, ref bme280_dev dev);

        [DllImport("bme280", SetLastError = true)]
        public static extern void bme280_parse_sensor_data(ref uint8_t[] reg_data, ref bme280_uncomp_data uncomp_data);

        [DllImport("bme280", SetLastError = true)]
        public static extern int8_t bme280_compensate_data(uint8_t sensor_comp,
                              ref bme280_uncomp_data uncomp_data,
                              ref bme280_data comp_data,
                              ref bme280_calib_data calib_data);

        private static void CheckError(string name, int result)
        {
            if (result < 0)
            {
                var error = Marshal.GetLastWin32Error();
                throw new System.InvalidOperationException(FormattableString.Invariant($"{name} error: {error}"));
            }
        }

        public static void Create(ref bme280_dev sensor, string device, int address) => CheckError("Create", bme280_create(ref sensor, device, address));

        public static void Delete(ref bme280_dev sensor) => CheckError("Delete", bme280_delete(ref sensor));

        public static void SetSensorSettings(uint16_t settings_sel, ref bme280_dev sensor) => CheckError("Set sensor settings", bme280_set_sensor_settings(settings_sel, ref sensor));

        public static void GetSensorData(byte sensor_comp, ref bme280_data comp_data, ref bme280_dev sensor) =>
            CheckError("Get sensor data", bme280_get_sensor_data(sensor_comp, ref comp_data, ref sensor));
    }
}
