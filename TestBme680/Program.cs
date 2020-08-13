using System;
using System.Threading.Tasks;

using Nick.Rpi.Driver;

namespace TestBme680
{
    internal static class Program
    {
        public static async Task Main()
        {
            try
            {
                var bme680 = new BME680("/dev/i2c-1", 0x76);
                await bme680.Test(TimeSpan.FromSeconds(1), default).ConfigureAwait(false);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Console.WriteLine(FormattableString.Invariant($"Error: {ex}"));
            }
        }
    }
}
