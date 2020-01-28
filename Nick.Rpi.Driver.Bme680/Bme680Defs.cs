using System.Runtime.InteropServices;
using bme680_com_fptr_t = System.IntPtr;
using bme680_delay_fptr_t = System.IntPtr;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int8_t = System.SByte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint8_t = System.Byte;

namespace Nick.Rpi.Driver.Bme680
{


    public enum bme680_intf
    {
        /*! SPI interface */
        BME680_SPI_INTF,
        /*! I2C interface */
        BME680_I2C_INTF
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme680_field_data
    {
        /*! Contains new_data, gasm_valid & heat_stab */
        public uint8_t status;
        /*! The index of the heater profile used */
        public uint8_t gas_index;
        /*! Measurement index to track order */
        public uint8_t meas_index;
        /*! Temperature in degree celsius x100 */
        public int16_t temperature;
        /*! Pressure in Pascal */
        public uint32_t pressure;
        /*! Humidity in % relative humidity x1000 */
        public uint32_t humidity;
        /*! Gas resistance in Ohms */
        public uint32_t gas_resistance;
    }

    /*!
	 * @brief Structure to hold the Calibration data
	 */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme680_calib_data
    {
        /*! Variable to store calibrated humidity data */
        public uint16_t par_h1;
        /*! Variable to store calibrated humidity data */
        public uint16_t par_h2;
        /*! Variable to store calibrated humidity data */
        public int8_t par_h3;
        /*! Variable to store calibrated humidity data */
        public int8_t par_h4;
        /*! Variable to store calibrated humidity data */
        public int8_t par_h5;
        /*! Variable to store calibrated humidity data */
        public uint8_t par_h6;
        /*! Variable to store calibrated humidity data */
        public int8_t par_h7;
        /*! Variable to store calibrated gas data */
        public int8_t par_gh1;
        /*! Variable to store calibrated gas data */
        public int16_t par_gh2;
        /*! Variable to store calibrated gas data */
        public int8_t par_gh3;
        /*! Variable to store calibrated temperature data */
        public uint16_t par_t1;
        /*! Variable to store calibrated temperature data */
        public int16_t par_t2;
        /*! Variable to store calibrated temperature data */
        public int8_t par_t3;
        /*! Variable to store calibrated pressure data */
        public uint16_t par_p1;
        /*! Variable to store calibrated pressure data */
        public int16_t par_p2;
        /*! Variable to store calibrated pressure data */
        public int8_t par_p3;
        /*! Variable to store calibrated pressure data */
        public int16_t par_p4;
        /*! Variable to store calibrated pressure data */
        public int16_t par_p5;
        /*! Variable to store calibrated pressure data */
        public int8_t par_p6;
        /*! Variable to store calibrated pressure data */
        public int8_t par_p7;
        /*! Variable to store calibrated pressure data */
        public int16_t par_p8;
        /*! Variable to store calibrated pressure data */
        public int16_t par_p9;
        /*! Variable to store calibrated pressure data */
        public uint8_t par_p10;

        /*! Variable to store t_fine size */
        public int32_t t_fine;

        /*! Variable to store heater resistance range */
        public uint8_t res_heat_range;
        /*! Variable to store heater resistance value */
        public int8_t res_heat_val;
        /*! Variable to store error range */
        public int8_t range_sw_err;
    };

    /*!
	 * @brief BME680 sensor settings structure which comprises of ODR,
	 * over-sampling and filter settings.
	 */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme680_tph_sett
    {
        /*! Humidity oversampling */
        public uint8_t os_hum;
        /*! Temperature oversampling */
        public uint8_t os_temp;
        /*! Pressure oversampling */
        public uint8_t os_pres;
        /*! Filter coefficient */
        public uint8_t filter;
    };

    /*!
	 * @brief BME680 gas sensor which comprises of gas settings
	 *  and status parameters
	 */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme680_gas_sett
    {
        /*! Variable to store nb conversion */
        public uint8_t nb_conv;
        /*! Variable to store heater control */
        public uint8_t heatr_ctrl;
        /*! Run gas enable value */
        public uint8_t run_gas;
        /*! Heater temperature value */
        public uint16_t heatr_temp;
        /*! Duration profile value */
        public uint16_t heatr_dur;
    };

    /*!
	 * @brief BME680 device structure
	 */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme680_dev
    {
        /*! Chip Id */
        public uint8_t chip_id;
        /*! Device Id */
        public uint8_t dev_id;
        /*! SPI/I2C interface */
        public bme680_intf intf;
        /*! Memory page used */
        public uint8_t mem_page;
        /*! Ambient temperature in Degree C */
        public int8_t amb_temp;
        /*! Sensor calibration data */
        public bme680_calib_data calib;
        /*! Sensor settings */
        public bme680_tph_sett tph_sett;
        /*! Gas Sensor settings */
        public bme680_gas_sett gas_sett;
        /*! Sensor power modes */
        public uint8_t power_mode;
        /*! New sensor fields */
        public uint8_t new_fields;
        /*! Store the info messages */
        public uint8_t info_msg;
        /*! Bus read function pointer */
        public bme680_com_fptr_t read;
        /*! Bus write function pointer */
        public bme680_com_fptr_t write;
        /*! delay function pointer */
        public bme680_delay_fptr_t delay_ms;
        /*! Communication function result */
        public int8_t com_rslt;
    };

    public static class Api
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

        [DllImport("bme680", SetLastError = true)]
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
                throw new System.InvalidOperationException($"{name} error: {error}");
            }
        }
    }
}

