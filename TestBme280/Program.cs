using System;
using System.Threading;
using System.Threading.Tasks;

using Nick.Rpi.Driver;

namespace TestBme280
{
    using static Constants;
    public static class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Bme280 test");
            try
            {
                CancellationToken ct = default;

                var bme280 = new BME280("/dev/i2c-1", 0x76);
                var settings = new bme280_settings
                {
                    osr_h = BME280_OVERSAMPLING_1X,
                    osr_p = BME280_OVERSAMPLING_1X,
                    osr_t = BME280_OVERSAMPLING_1X,
                    filter = BME280_FILTER_COEFF_OFF,
                };

                bme280.SetSensorSettings(ref settings, BME280_OSR_HUM_SEL | BME280_OSR_PRESS_SEL | BME280_OSR_TEMP_SEL);

                while (!ct.IsCancellationRequested)
                {
                    bme280.SetSensorMode(BME280_FORCED_MODE);
                    await Task.Delay(100, ct).ConfigureAwait(false);
                    var data = bme280.GetSensorData(BME280_ALL);
                    Console.WriteLine(FormattableString.Invariant($"T: {data.temperature / 100.0} degC, P: {data.pressure / 100.0} Pascal, H: {data.humidity / 1024.0} %rH"));
                    await Task.Delay(1000, ct).ConfigureAwait(false);
                }
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
