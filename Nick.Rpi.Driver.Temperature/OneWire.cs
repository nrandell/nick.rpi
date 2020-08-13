using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Nick.Rpi.Driver.Temperature
{
    public class OneWire
    {
        public string BaseFolder { get; }

        public OneWire(string baseFolder = "/sys")
        {
            BaseFolder = baseFolder;
        }

        private static async Task<OneWireReading> ReadDevice(DirectoryInfo deviceDirectory, CancellationToken ct)
        {
            var deviceFile = Path.Combine(deviceDirectory.FullName, "w1_slave");
            var lines = await File.ReadAllLinesAsync(deviceFile, ct).ConfigureAwait(false);
            if (lines.Length != 2)
            {
                throw new InvalidOperationException($"Read {lines.Length} lines ({string.Join(",", lines)}");
            }
            var crcOk = lines[0].EndsWith("YES", StringComparison.InvariantCultureIgnoreCase);
            var temperatureLine = lines[1];
            if (temperatureLine.Length > 1)
            {
                var equals = temperatureLine.LastIndexOf('=');
                var temperatureString = temperatureLine.Substring(equals + 1);
                if (int.TryParse(temperatureString, NumberStyles.Integer, CultureInfo.InvariantCulture, out var temperature))
                {
                    return new OneWireReading(DateTimeOffset.UtcNow, deviceDirectory.Name, crcOk, temperature / 1000.0);
                }

                throw new InvalidOperationException($"Failed to read temperature string from '{temperatureString}' extracted from '{temperatureLine}'");
            }

            throw new InvalidOperationException($"Failed to extract from '{temperatureLine}'");
        }

        public async Task<OneWireReading[]> Read(CancellationToken ct)
        {
            var devicesDirectory = new DirectoryInfo($"{BaseFolder}/bus/w1/devices");
            var readings = new List<OneWireReading>();
            foreach (var deviceDirectory in devicesDirectory.EnumerateDirectories("28-*", SearchOption.TopDirectoryOnly))
            {
                var reading = await ReadDevice(deviceDirectory, ct).ConfigureAwait(false);
                readings.Add(reading);
            }
            return readings.ToArray();
        }
    }
}
