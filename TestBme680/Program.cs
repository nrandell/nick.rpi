using Nick.Rpi.Driver.Bme680;
using System;
using System.Threading.Tasks;

namespace TestBme680
{
    internal static class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Hello World!");
            try
            {
                var bme680 = new BME680("/dev/i2c-1", 0x76);
                await bme680.Test(TimeSpan.FromSeconds(1), default);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
