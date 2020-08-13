using int8_t = System.SByte;
using uint8_t = System.Byte;

namespace Nick.Rpi.Driver
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public static class Constants
    {
        /**\name I2C addresses */
        public const uint8_t BME280_I2C_ADDR_PRIM = 0x76;
        public const uint8_t BME280_I2C_ADDR_SEC = 0x77;

        /**\name BME280 chip identifier */
        public const uint8_t BME280_CHIP_ID = 0x60;

        /**\name Register Address */
        public const uint8_t BME280_CHIP_ID_ADDR = 0xD0;
        public const uint8_t BME280_RESET_ADDR = 0xE0;
        public const uint8_t BME280_TEMP_PRESS_CALIB_DATA_ADDR = 0x88;
        public const uint8_t BME280_HUMIDITY_CALIB_DATA_ADDR = 0xE1;
        public const uint8_t BME280_PWR_CTRL_ADDR = 0xF4;
        public const uint8_t BME280_CTRL_HUM_ADDR = 0xF2;
        public const uint8_t BME280_CTRL_MEAS_ADDR = 0xF4;
        public const uint8_t BME280_CONFIG_ADDR = 0xF5;
        public const uint8_t BME280_DATA_ADDR = 0xF7;

        /**\name API success code */
        public const int8_t BME280_OK = 0;

        /**\name API error codes */
        public const int8_t BME280_E_NULL_PTR = -1;
        public const int8_t BME280_E_DEV_NOT_FOUND = -2;
        public const int8_t BME280_E_INVALID_LEN = -3;
        public const int8_t BME280_E_COMM_FAIL = -4;
        public const int8_t BME280_E_SLEEP_MODE_FAIL = -5;
        public const int8_t BME280_E_NVM_COPY_FAILED = -6;

        /**\name API warning codes */
        public const int8_t BME280_W_INVALID_OSR_MACRO = 1;

        /**\name Macros related to size */
        public const uint8_t BME280_TEMP_PRESS_CALIB_DATA_LEN = 26;
        public const uint8_t BME280_HUMIDITY_CALIB_DATA_LEN = 7;
        public const uint8_t BME280_P_T_H_DATA_LEN = 8;

        /**\name Sensor power modes */
        public const uint8_t BME280_SLEEP_MODE = 0x00;
        public const uint8_t BME280_FORCED_MODE = 0x01;
        public const uint8_t BME280_NORMAL_MODE = 0x03;

        /**\name Macro to combine two 8 bit data's to form a 16 bit data */

        /**\name Macros for bit masking */
        public const uint8_t BME280_SENSOR_MODE_MSK = 0x03;
        public const uint8_t BME280_SENSOR_MODE_POS = 0x00;

        public const uint8_t BME280_CTRL_HUM_MSK = 0x07;
        public const uint8_t BME280_CTRL_HUM_POS = 0x00;

        public const uint8_t BME280_CTRL_PRESS_MSK = 0x1C;
        public const uint8_t BME280_CTRL_PRESS_POS = 0x02;

        public const uint8_t BME280_CTRL_TEMP_MSK = 0xE0;
        public const uint8_t BME280_CTRL_TEMP_POS = 0x05;

        public const uint8_t BME280_FILTER_MSK = 0x1C;
        public const uint8_t BME280_FILTER_POS = 0x02;

        public const uint8_t BME280_STANDBY_MSK = 0xE0;
        public const uint8_t BME280_STANDBY_POS = 0x05;

        /**\name Sensor component selection macros
         * These values are internal for API implementation. Don't relate this to
         * data sheet.
         */
        public const uint8_t BME280_PRESS = 1;
        public const uint8_t BME280_TEMP = 1 << 1;
        public const uint8_t BME280_HUM = 1 << 2;
        public const uint8_t BME280_ALL = 0x07;

        /**\name Settings selection macros */
        public const uint8_t BME280_OSR_PRESS_SEL = 1;
        public const uint8_t BME280_OSR_TEMP_SEL = 1 << 1;
        public const uint8_t BME280_OSR_HUM_SEL = 1 << 2;
        public const uint8_t BME280_FILTER_SEL = 1 << 3;
        public const uint8_t BME280_STANDBY_SEL = 1 << 4;
        public const uint8_t BME280_ALL_SETTINGS_SEL = 0x1F;

        /**\name Oversampling macros */
        public const uint8_t BME280_NO_OVERSAMPLING = 0x00;
        public const uint8_t BME280_OVERSAMPLING_1X = 0x01;
        public const uint8_t BME280_OVERSAMPLING_2X = 0x02;
        public const uint8_t BME280_OVERSAMPLING_4X = 0x03;
        public const uint8_t BME280_OVERSAMPLING_8X = 0x04;
        public const uint8_t BME280_OVERSAMPLING_16X = 0x05;

        /**\name Standby duration selection macros */
        public const uint8_t BME280_STANDBY_TIME_0_5_MS = 0x00;
        public const uint8_t BME280_STANDBY_TIME_62_5_MS = 0x01;
        public const uint8_t BME280_STANDBY_TIME_125_MS = 0x02;
        public const uint8_t BME280_STANDBY_TIME_250_MS = 0x03;
        public const uint8_t BME280_STANDBY_TIME_500_MS = 0x04;
        public const uint8_t BME280_STANDBY_TIME_1000_MS = 0x05;
        public const uint8_t BME280_STANDBY_TIME_10_MS = 0x06;
        public const uint8_t BME280_STANDBY_TIME_20_MS = 0x07;

        /**\name Filter coefficient selection macros */
        public const uint8_t BME280_FILTER_COEFF_OFF = 0x00;
        public const uint8_t BME280_FILTER_COEFF_2 = 0x01;
        public const uint8_t BME280_FILTER_COEFF_4 = 0x02;
        public const uint8_t BME280_FILTER_COEFF_8 = 0x03;
        public const uint8_t BME280_FILTER_COEFF_16 = 0x04;

        public const uint8_t BME280_STATUS_REG_ADDR = 0xF3;
        public const uint8_t BME280_SOFT_RESET_COMMAND = 0xB6;
        public const uint8_t BME280_STATUS_IM_UPDATE = 0x01;
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
