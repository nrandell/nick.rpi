using uint8_t = System.Byte;

namespace Nick.Rpi.Driver
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using static Constants;

    public class BME680
    {
        private bme680_dev _sensor;

        public BME680(string device, int address)
        {
            NativeMethods.Create(ref _sensor, device, address);
        }

        public async Task Test(TimeSpan delay, CancellationToken ct)
        {
            uint8_t set_required_settings;

            /* Set the temperature, pressure and humidity settings */
            _sensor.tph_sett.os_hum = BME680_OS_2X;
            _sensor.tph_sett.os_pres = BME680_OS_4X;
            _sensor.tph_sett.os_temp = BME680_OS_8X;
            _sensor.tph_sett.filter = BME680_FILTER_SIZE_3;

            /* Set the remaining gas sensor settings and link the heating profile */
            _sensor.gas_sett.run_gas = BME680_ENABLE_GAS_MEAS;
            /* Create a ramp heat waveform in 3 steps */
            _sensor.gas_sett.heatr_temp = 320; /* degree Celsius */
            _sensor.gas_sett.heatr_dur = 150; /* milliseconds */

            /* Select the power mode */
            /* Must be set before writing the sensor configuration */
            _sensor.power_mode = BME680_FORCED_MODE;

            /* Set the required sensor settings needed */
            set_required_settings = BME680_OST_SEL | BME680_OSP_SEL | BME680_OSH_SEL | BME680_FILTER_SEL
                | BME680_GAS_SENSOR_SEL;

            /* Set the desired sensor configuration */
            NativeMethods.SetSensorSettings(set_required_settings, ref _sensor);

            /* Set the power mode */
            NativeMethods.SetSensorMode(ref _sensor);

            /* Get the total measurement duration so as to sleep or wait till the
                 * measurement is complete */
            var meas_period = NativeMethods.GetProfileDuration(ref _sensor);

            bme680_field_data data = new bme680_field_data();

            while (!ct.IsCancellationRequested)
            {
                /* Trigger the next measurement if you would like to read data out continuously */
                if (_sensor.power_mode == BME680_FORCED_MODE)
                {
                    NativeMethods.SetSensorMode(ref _sensor);
                }
                await Task.Delay(meas_period, ct).ConfigureAwait(false);

                NativeMethods.GetSensorData(ref data, ref _sensor);
                Console.Write(FormattableString.Invariant($"T: {data.temperature / 100.0} degC, P: {data.pressure / 100.0} hPa, H {data.humidity / 1000.0} %rH"));
                if ((data.status & BME680_GASM_VALID_MSK) == BME680_GASM_VALID_MSK)
                {
                    Console.Write($", G: {data.gas_resistance} ohms");
                }
                Console.WriteLine();

                await Task.Delay(delay, ct).ConfigureAwait(false);
            }
        }
    }
}

