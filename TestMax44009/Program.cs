using Nick.Rpi.Driver.Max44009;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestMax44009
{
    public static class Program
    {
        private static async Task Main()
        {
            CancellationToken ct = default;
            Console.WriteLine("Hello Max44009!");
            try
            {
                var max44009 = new Max44009("/dev/i2c-1", 0x4A);
                max44009.Reset();

                while (!ct.IsCancellationRequested)
                {
                    var lux = max44009.Read();
                    Console.WriteLine($"Lix = {lux}");
                    await Task.Delay(1000, ct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
