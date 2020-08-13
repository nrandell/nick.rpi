using System;
using System.Runtime.InteropServices;

using uint8_t = System.Byte;

#pragma warning disable MA0048 // File name must match type name
#pragma warning disable IDE1006 // Naming Styles
namespace Nick.Rpi.Driver
{
    /*!
     * @brief bme280 sensor settings structure which comprises of mode,
     * oversampling and filter settings.
     */
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public struct bme280_settings : IEquatable<bme280_settings>
#pragma warning restore CA1707 // Identifiers should not contain underscores
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

        public override bool Equals(object? obj)
        {
            return obj is bme280_settings settings && Equals(settings);
        }

        public bool Equals(bme280_settings other)
        {
            return osr_p == other.osr_p &&
                   osr_t == other.osr_t &&
                   osr_h == other.osr_h &&
                   filter == other.filter &&
                   standby_time == other.standby_time;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(osr_p, osr_t, osr_h, filter, standby_time);
        }

        public static bool operator ==(bme280_settings left, bme280_settings right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(bme280_settings left, bme280_settings right)
        {
            return !(left == right);
        }
    };
}
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore MA0048 // File name must match type name
