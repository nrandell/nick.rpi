using System;

namespace Nick.Rpi.Driver.Temperature
{
    public class OneWireReading
    {
        public DateTimeOffset Timestamp { get; }
        public string Device { get; }
        public bool Valid { get; }
        public double DegreesCentigrade { get; }

        public OneWireReading(DateTimeOffset timestamp, string device, bool valid, double degreesCentigrade)
        {
            Timestamp = timestamp;
            Device = device;
            Valid = valid;
            DegreesCentigrade = degreesCentigrade;
        }

        public override string ToString() => $"{Timestamp}:{Device} @ {DegreesCentigrade} ({Valid})";
    }
}
