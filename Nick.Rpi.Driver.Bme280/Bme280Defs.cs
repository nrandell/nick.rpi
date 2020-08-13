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

#pragma warning disable MA0048 // File name must match type name
#pragma warning disable IDE1006 // Naming Styles
namespace Nick.Rpi.Driver
{
    /*!
     * @brief Interface selection Enums
     */
    internal enum bme280_intf
    {
        /*! SPI interface */
        BME280_SPI_INTF,

        /*! I2C interface */
        BME280_I2C_INTF,
    };

    /*!
     * @brief Type definitions
     */

    /*!
     * @brief Calibration data
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct bme280_calib_data
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
    internal struct bme280_uncomp_data
    {
        /*! un-compensated pressure */
        public uint32_t pressure;

        /*! un-compensated temperature */
        public uint32_t temperature;

        /*! un-compensated humidity */
        public uint32_t humidity;
    };
#pragma warning restore CA1051 // Do not declare visible instance fields

    /*!
     * @brief bme280 device structure
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct bme280_dev
    {
        /*! Chip Id */
        public uint8_t chip_id;

        public IntPtr intf_ptr;

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
}
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore MA0048 // File name must match type name
