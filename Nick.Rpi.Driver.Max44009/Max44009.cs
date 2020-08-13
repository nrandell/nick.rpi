namespace Nick.Rpi.Driver
{
    public class Max44009
    {
        private Max44009Device _sensor;

        public Max44009(string device, int address)
        {
            NativeMethods.Create(ref _sensor, device, address);
        }

        public void Reset() => NativeMethods.Reset(ref _sensor);

        public float Read() => NativeMethods.Read(ref _sensor);
    }
}
