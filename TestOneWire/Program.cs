using Nick.Rpi.Driver.Temperature;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                    var readings = await oneWire.Read(ct);
                    foreach (var reading in readings)
                    {
                        Console.WriteLine(reading);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(10), ct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
