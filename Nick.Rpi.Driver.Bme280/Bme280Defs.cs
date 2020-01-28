using System;
using System.Runtime.InteropServices;
using bme280_com_fptr_t = System.IntPtr;
using bme280_delay_fptr_t = System.IntPtr;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int8_t = System.SByte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint8_t = System.Byte;

namespace Nick.Rpi.Driver.Bme280
{
    /*!
     * @brief Interface selection Enums
     */
    public enum bme280_intf
    {
        /*! SPI interface */
        BME280_SPI_INTF,

        /*! I2C interface */
        BME280_I2C_INTF
    };

    /*!
     * @brief Type definitions
     */

    /*!
     * @brief Calibration data
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme280_calib_data
    {
        /**
         * @ Trim Variables
         */

        /**@{*/
        public uint16_t dig_T1;
        public int16_t dig_T2;
        public int16_t dig_T3;
        public uint16_t dig_P1;
        public int16_t dig_P2;
        public int16_t dig_P3;
        public int16_t dig_P4;
        public int16_t dig_P5;
        public int16_t dig_P6;
        public int16_t dig_P7;
        public int16_t dig_P8;
        public int16_t dig_P9;
        public uint8_t dig_H1;
        public int16_t dig_H2;
        public uint8_t dig_H3;
        public int16_t dig_H4;
        public int16_t dig_H5;
        public int8_t dig_H6;
        public int32_t t_fine;

        /**@}*/
    };

    /*!
     * @brief bme280 sensor structure which comprises of uncompensated temperature,
     * pressure and humidity data
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme280_uncomp_data
    {
        /*! un-compensated pressure */
        public uint32_t pressure;

        /*! un-compensated temperature */
        public uint32_t temperature;

        /*! un-compensated humidity */
        public uint32_t humidity;
    };

    /*!
     * @brief bme280 sensor settings structure which comprises of mode,
     * oversampling and filter settings.
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme280_settings
    {
        /*! pressure oversampling */
        public uint8_t osr_p;

        /*! temperature oversampling */
        public uint8_t osr_t;

        /*! humidity oversampling */
        public uint8_t osr_h;

        /*! filter coefficient */
        public uint8_t filter;

        /*! standby time */
        public uint8_t standby_time;
    };

    /*!
     * @brief bme280 device structure
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme280_dev
    {
        /*! Chip Id */
        public uint8_t chip_id;

        /*! Device Id */
        public uint8_t dev_id;

        /*! SPI/I2C interface */
        public bme280_intf intf;

        /*! Read function pointer */
        public bme280_com_fptr_t read;

        /*! Write function pointer */
        public bme280_com_fptr_t write;

        /*! Delay function pointer */
        public bme280_delay_fptr_t delay_ms;

        /*! Trim data */
        public bme280_calib_data calib_data;

        /*! Sensor settings */
        public bme280_settings settings;
    }

    public static class Api
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

        [DllImport("bme280", SetLastError = true)]
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
                throw new System.InvalidOperationException($"{name} error: {error}");
            }
        }

        public static void Create(ref bme280_dev sensor, string device, int address) => CheckError("Create", bme280_create(ref sensor, device, address));

        public static void Delete(ref bme280_dev sensor) => CheckError("Delete", bme280_delete(ref sensor));

        public static void SetSensorSettings(uint16_t settings_sel, ref bme280_dev sensor) => CheckError("Set sensor settings", bme280_set_sensor_settings(settings_sel, ref sensor));

        public static void GetSensorData(byte sensor_comp, ref bme280_data comp_data, ref bme280_dev sensor) =>
            CheckError("Get sensor data", bme280_get_sensor_data(sensor_comp, ref comp_data, ref sensor));
    }
}
