using int32_t = System.Int32;
using int8_t = System.SByte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint8_t = System.Byte;

namespace Nick.Rpi.Driver.Bme680
{
    public static class Constants
    {
        /** BME680 General config */
        public const uint8_t BME680_POLL_PERIOD_MS = 10;

        /** BME680 I2C addresses */
        public const uint8_t BME680_I2C_ADDR_PRIMARY = 0x76;
        public const uint8_t BME680_I2C_ADDR_SECONDARY = 0x77;

        /** BME680 unique chip identifier */
        public const uint8_t BME680_CHIP_ID = 0x61;

        /** BME680 coefficients related defines */
        public const uint8_t BME680_COEFF_SIZE = 41;
        public const uint8_t BME680_COEFF_ADDR1_LEN = 25;
        public const uint8_t BME680_COEFF_ADDR2_LEN = 16;

        /** BME680 field_x related defines */
        public const uint8_t BME680_FIELD_LENGTH = 15;
        public const uint8_t BME680_FIELD_ADDR_OFFSET = 17;

        /** Soft reset command */
        public const uint8_t BME680_SOFT_RESET_CMD = 0xb6;

        /** Error code definitions */
        public const int8_t BME680_OK = 0;
        /* Errors */
        public const int8_t BME680_E_NULL_PTR = -1;
        public const int8_t BME680_E_COM_FAIL = -2;
        public const int8_t BME680_E_DEV_NOT_FOUND = -3;
        public const int8_t BME680_E_INVALID_LENGTH = -4;

        /* Warnings */
        public const int8_t BME680_W_DEFINE_PWR_MODE = 1;
        public const int8_t BME680_W_NO_NEW_DATA = 2;

        /* Info's */
        public const uint8_t BME680_I_MIN_CORRECTION = 1;
        public const uint8_t BME680_I_MAX_CORRECTION = 2;

        /** Register map */
        /** Other coefficient's address */
        public const uint8_t BME680_ADDR_RES_HEAT_VAL_ADDR = 0x00;
        public const uint8_t BME680_ADDR_RES_HEAT_RANGE_ADDR = 0x02;
        public const uint8_t BME680_ADDR_RANGE_SW_ERR_ADDR = 0x04;
        public const uint8_t BME680_ADDR_SENS_CONF_START = 0x5A;
        public const uint8_t BME680_ADDR_GAS_CONF_START = 0x64;

        /** Field settings */
        public const uint8_t BME680_FIELD0_ADDR = 0x1d;

        /** Heater settings */
        public const uint8_t BME680_RES_HEAT0_ADDR = 0x5a;
        public const uint8_t BME680_GAS_WAIT0_ADDR = 0x64;

        /** Sensor configuration registers */
        public const uint8_t BME680_CONF_HEAT_CTRL_ADDR = 0x70;
        public const uint8_t BME680_CONF_ODR_RUN_GAS_NBC_ADDR = 0x71;
        public const uint8_t BME680_CONF_OS_H_ADDR = 0x72;
        public const uint8_t BME680_MEM_PAGE_ADDR = 0xf3;
        public const uint8_t BME680_CONF_T_P_MODE_ADDR = 0x74;
        public const uint8_t BME680_CONF_ODR_FILT_ADDR = 0x75;

        /** Coefficient's address */
        public const uint8_t BME680_COEFF_ADDR1 = 0x89;
        public const uint8_t BME680_COEFF_ADDR2 = 0xe1;

        /** Chip identifier */
        public const uint8_t BME680_CHIP_ID_ADDR = 0xd0;

        /** Soft reset register */
        public const uint8_t BME680_SOFT_RESET_ADDR = 0xe0;

        /** Heater control settings */
        public const uint8_t BME680_ENABLE_HEATER = 0x00;
        public const uint8_t BME680_DISABLE_HEATER = 0x08;

        /** Gas measurement settings */
        public const uint8_t BME680_DISABLE_GAS_MEAS = 0x00;
        public const uint8_t BME680_ENABLE_GAS_MEAS = 0x01;

        /** Over-sampling settings */
        public const uint8_t BME680_OS_NONE = 0;
        public const uint8_t BME680_OS_1X = 1;
        public const uint8_t BME680_OS_2X = 2;
        public const uint8_t BME680_OS_4X = 3;
        public const uint8_t BME680_OS_8X = 4;
        public const uint8_t BME680_OS_16X = 5;

        /** IIR filter settings */
        public const uint8_t BME680_FILTER_SIZE_0 = 0;
        public const uint8_t BME680_FILTER_SIZE_1 = 1;
        public const uint8_t BME680_FILTER_SIZE_3 = 2;
        public const uint8_t BME680_FILTER_SIZE_7 = 3;
        public const uint8_t BME680_FILTER_SIZE_15 = 4;
        public const uint8_t BME680_FILTER_SIZE_31 = 5;
        public const uint8_t BME680_FILTER_SIZE_63 = 6;
        public const uint8_t BME680_FILTER_SIZE_127 = 7;

        /** Power mode settings */
        public const uint8_t BME680_SLEEP_MODE = 0;
        public const uint8_t BME680_FORCED_MODE = 1;

        /** Delay related macro declaration */
        public const uint32_t BME680_RESET_PERIOD = 10;

        /** SPI memory page settings */
        public const uint8_t BME680_MEM_PAGE0 = 0x10;
        public const uint8_t BME680_MEM_PAGE1 = 0x00;

        /** Ambient humidity shift value for compensation */
        public const uint8_t BME680_HUM_REG_SHIFT_VAL = 4;

        /** Run gas enable and disable settings */
        public const uint8_t BME680_RUN_GAS_DISABLE = 0;
        public const uint8_t BME680_RUN_GAS_ENABLE = 1;

        /** Buffer length macro declaration */
        public const uint8_t BME680_TMP_BUFFER_LENGTH = 40;
        public const uint8_t BME680_REG_BUFFER_LENGTH = 6;
        public const uint8_t BME680_FIELD_DATA_LENGTH = 3;
        public const uint8_t BME680_GAS_REG_BUF_LENGTH = 20;

        /** Settings selector */
        public const uint16_t BME680_OST_SEL = 1;
        public const uint16_t BME680_OSP_SEL = 2;
        public const uint16_t BME680_OSH_SEL = 4;
        public const uint16_t BME680_GAS_MEAS_SEL = 8;
        public const uint16_t BME680_FILTER_SEL = 16;
        public const uint16_t BME680_HCNTRL_SEL = 32;
        public const uint16_t BME680_RUN_GAS_SEL = 64;
        public const uint16_t BME680_NBCONV_SEL = 128;
        public const uint16_t BME680_GAS_SENSOR_SEL = BME680_GAS_MEAS_SEL | BME680_RUN_GAS_SEL | BME680_NBCONV_SEL;

        /** Number of conversion settings*/
        public const uint8_t BME680_NBCONV_MIN = 0;
        public const uint8_t BME680_NBCONV_MAX = 10;

        /** Mask definitions */
        public const uint8_t BME680_GAS_MEAS_MSK = 0x30;
        public const uint8_t BME680_NBCONV_MSK = 0X0F;
        public const uint8_t BME680_FILTER_MSK = 0X1C;
        public const uint8_t BME680_OST_MSK = 0XE0;
        public const uint8_t BME680_OSP_MSK = 0X1C;
        public const uint8_t BME680_OSH_MSK = 0X07;
        public const uint8_t BME680_HCTRL_MSK = 0x08;
        public const uint8_t BME680_RUN_GAS_MSK = 0x10;
        public const uint8_t BME680_MODE_MSK = 0x03;
        public const uint8_t BME680_RHRANGE_MSK = 0x30;
        public const uint8_t BME680_RSERROR_MSK = 0xf0;
        public const uint8_t BME680_NEW_DATA_MSK = 0x80;
        public const uint8_t BME680_GAS_INDEX_MSK = 0x0f;
        public const uint8_t BME680_GAS_RANGE_MSK = 0x0f;
        public const uint8_t BME680_GASM_VALID_MSK = 0x20;
        public const uint8_t BME680_HEAT_STAB_MSK = 0x10;
        public const uint8_t BME680_MEM_PAGE_MSK = 0x10;
        public const uint8_t BME680_SPI_RD_MSK = 0x80;
        public const uint8_t BME680_SPI_WR_MSK = 0x7f;
        public const uint8_t BME680_BIT_H1_DATA_MSK = 0x0F;

        /** Bit position definitions for sensor settings */
        public const uint8_t BME680_GAS_MEAS_POS = 4;
        public const uint8_t BME680_FILTER_POS = 2;
        public const uint8_t BME680_OST_POS = 5;
        public const uint8_t BME680_OSP_POS = 2;
        public const uint8_t BME680_RUN_GAS_POS = 4;

        /** Array Index to Field data mapping for Calibration Data*/
        public const uint8_t BME680_T2_LSB_REG = 1;
        public const uint8_t BME680_T2_MSB_REG = 2;
        public const uint8_t BME680_T3_REG = 3;
        public const uint8_t BME680_P1_LSB_REG = 5;
        public const uint8_t BME680_P1_MSB_REG = 6;
        public const uint8_t BME680_P2_LSB_REG = 7;
        public const uint8_t BME680_P2_MSB_REG = 8;
        public const uint8_t BME680_P3_REG = 9;
        public const uint8_t BME680_P4_LSB_REG = 11;
        public const uint8_t BME680_P4_MSB_REG = 12;
        public const uint8_t BME680_P5_LSB_REG = 13;
        public const uint8_t BME680_P5_MSB_REG = 14;
        public const uint8_t BME680_P7_REG = 15;
        public const uint8_t BME680_P6_REG = 16;
        public const uint8_t BME680_P8_LSB_REG = 19;
        public const uint8_t BME680_P8_MSB_REG = 20;
        public const uint8_t BME680_P9_LSB_REG = 21;
        public const uint8_t BME680_P9_MSB_REG = 22;
        public const uint8_t BME680_P10_REG = 23;
        public const uint8_t BME680_H2_MSB_REG = 25;
        public const uint8_t BME680_H2_LSB_REG = 26;
        public const uint8_t BME680_H1_LSB_REG = 26;
        public const uint8_t BME680_H1_MSB_REG = 27;
        public const uint8_t BME680_H3_REG = 28;
        public const uint8_t BME680_H4_REG = 29;
        public const uint8_t BME680_H5_REG = 30;
        public const uint8_t BME680_H6_REG = 31;
        public const uint8_t BME680_H7_REG = 32;
        public const uint8_t BME680_T1_LSB_REG = 33;
        public const uint8_t BME680_T1_MSB_REG = 34;
        public const uint8_t BME680_GH2_LSB_REG = 35;
        public const uint8_t BME680_GH2_MSB_REG = 36;
        public const uint8_t BME680_GH1_REG = 37;
        public const uint8_t BME680_GH3_REG = 38;

        /** BME680 register buffer index settings*/
        public const uint8_t BME680_REG_FILTER_INDEX = 5;
        public const uint8_t BME680_REG_TEMP_INDEX = 4;
        public const uint8_t BME680_REG_PRES_INDEX = 4;
        public const uint8_t BME680_REG_HUM_INDEX = 2;
        public const uint8_t BME680_REG_NBCONV_INDEX = 1;
        public const uint8_t BME680_REG_RUN_GAS_INDEX = 1;
        public const uint8_t BME680_REG_HCTRL_INDEX = 0;

        /** BME680 pressure calculation macros */
        /*! This max value is used to provide precedence to multiplication or division
         * in pressure compensation equation to achieve least loss of precision and
         * avoiding overflows.
         * i.e Comparing value, BME680_MAX_OVERFLOW_VAL = INT32_C(1 << 30;
         */
        public const int32_t BME680_MAX_OVERFLOW_VAL = 0x40000000;

    }
}
