namespace Nick.Rpi.Driver.Max44009
{
    public class Max44009
    {
        private Max44009Device _sensor;

        public Max44009(string device, int address)
        {
            Api.Create(ref _sensor, device, address);
        }

        public void Reset() => Api.Reset(ref _sensor);

        public float Read() => Api.Read(ref _sensor);

        //public async Task Test(TimeSpan delay, CancellationToken ct)
        //{
        //    Api.Reset(ref _sensor);
        //    while (!ct.IsCancellationRequested)
        //    {
        //        var luminance = Api.Read(ref _sensor);
        //        Console.WriteLine($"L: {luminance} lux");
        //        await Task.Delay(delay, ct);
        //    }
        //}
    }
}
