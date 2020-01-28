using uint8_t = System.Byte;

namespace Nick.Rpi.Driver.Bme280
{
    public class BME280
    {
        private bme280_dev _sensor;

        public BME280(string device, int address)
        {
            Api.Create(ref _sensor, device, address);
        }

        public void SetSensorSettings(ref bme280_settings settings, ushort flags)
        {
            _sensor.settings = settings;
            Api.SetSensorSettings(flags, ref _sensor);
        }

        public void SetSensorMode(uint8_t sensorMode)
        {
            Api.bme280_set_sensor_mode(sensorMode, ref _sensor);
        }

        public bme280_data GetSensorData(uint8_t flags)
        {
            var data = new bme280_data();
            Api.GetSensorData(flags, ref data, ref _sensor);
            return data;
        }

        //public async Task Test(TimeSpan delay, CancellationToken ct)
        //{
        //    uint8_t settings_sel;
        //    var comp_data = new bme280_data();

        //    /* Recommended mode of operation: Indoor navigation */
        //    _sensor.settings.osr_h = BME280_OVERSAMPLING_1X;
        //    _sensor.settings.osr_p = BME280_OVERSAMPLING_16X;
        //    _sensor.settings.osr_t = BME280_OVERSAMPLING_2X;
        //    _sensor.settings.filter = BME280_FILTER_COEFF_16;

        //    settings_sel = BME280_OSR_PRESS_SEL | BME280_OSR_TEMP_SEL | BME280_OSR_HUM_SEL | BME280_FILTER_SEL;

        //    Api.SetSensorSettings(settings_sel, ref _sensor);

        //    while (!ct.IsCancellationRequested)
        //    {
        //        Api.bme280_set_sensor_mode(BME280_FORCED_MODE, ref _sensor);
        //        await Task.Delay(40, ct).ConfigureAwait(false);
        //        Api.GetSensorData(BME280_ALL, ref comp_data, ref _sensor);
        //        Console.WriteLine($"T: {comp_data.temperature / 100.0} degC, P: {comp_data.pressure / 100.0} Pascal, H: {comp_data.humidity / 1024.0} %rH");

        //        await Task.Delay(delay, ct);
        //    }
    }
}

