using System.Runtime.InteropServices;

using int32_t = System.Int32;
using uint32_t = System.UInt32;

namespace Nick.Rpi.Driver
{
    /*!
     * @brief bme280 sensor structure which comprises of temperature, pressure and
     * humidity data
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public struct bme280_data : System.IEquatable<bme280_data>
#pragma warning restore CA1707 // Identifiers should not contain underscores
    {
        /*! Compensated pressure */
#pragma warning disable CA1051 // Do not declare visible instance fields
        public uint32_t pressure;

        /*! Compensated temperature */
        public int32_t temperature;

        /*! Compensated humidity */
        public uint32_t humidity;
#pragma warning restore CA1051 // Do not declare visible instance fields

        public double HumidityPercent => humidity / 1024.0;
        public double PressureHPa => pressure / 10000.0;
        public double TemperatureCentigrade => temperature / 100.0;

        public override bool Equals(object? obj)
        {
            return obj is bme280_data data && Equals(data);
        }

        public bool Equals(bme280_data other)
        {
            return pressure == other.pressure &&
                   temperature == other.temperature &&
                   humidity == other.humidity;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(pressure, temperature, humidity);
        }

        public static bool operator ==(bme280_data left, bme280_data right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(bme280_data left, bme280_data right)
        {
            return !(left == right);
        }
    };
}
