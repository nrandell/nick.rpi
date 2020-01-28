using System.Runtime.InteropServices;
using int32_t = System.Int32;
using uint32_t = System.UInt32;

namespace Nick.Rpi.Driver.Bme280
{
    /*!
     * @brief bme280 sensor structure which comprises of temperature, pressure and
     * humidity data
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct bme280_data
    {
        /*! Compensated pressure */
        public uint32_t pressure;

        /*! Compensated temperature */
        public int32_t temperature;

        /*! Compensated humidity */
        public uint32_t humidity;

        public double HumidityPercent => humidity / 1024.0;
        public double PressureHPa => pressure / 10000.0;
        public double TemperatureCentigrade => temperature / 100.0;
    };
}
