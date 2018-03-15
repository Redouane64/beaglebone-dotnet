using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LEDBlink
{
    class Program
    {
        /// <summary>
        /// Path to LED 3 device.
        /// </summary>
        const string UserLed3 = "/sys/devices/platform/leds/leds/beaglebone:green:usr3/brightness";

        static async Task Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Exit);

            const int delay = 250; // ms.


            while (true)
            {
                await Led3('0');

                await Task.Delay(delay);

                await Led3('1');

                await Task.Delay(delay);
            }
        }

        private static async Task Led3(char value)
        {
            using (var led = new StreamWriter(UserLed3))
            {
                await led.WriteAsync(value);
            }
        }

        private static async void Exit(object sender, ConsoleCancelEventArgs e) => await Led3('0');

    }
}
