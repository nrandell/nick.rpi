using System;
using System.Threading;
using System.Threading.Tasks;

using Nick.Rpi.Driver;

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
                    Console.WriteLine(FormattableString.Invariant($"Lux = {lux}"));
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
