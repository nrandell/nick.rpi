using System;
using System.Threading;
using System.Threading.Tasks;

using Nick.Rpi.Driver.Temperature;

namespace TestOneWire
{
    internal static class Program
    {
        public static async Task Main()
        {
            try
            {
                var ct = CancellationToken.None;
                var oneWire = new OneWire();
                while (true)
                {
                    var readings = await oneWire.Read(ct).ConfigureAwait(false);
                    foreach (var reading in readings)
                    {
                        Console.WriteLine(reading);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(10), ct).ConfigureAwait(false);
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
