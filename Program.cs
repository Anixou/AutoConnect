using System;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        BluetoothClient client = new BluetoothClient();
        BluetoothDeviceInfo airpod = null;
        int connected = 1;
        int try_number = 10;
        int delay_between_try = 3;

        // Recherche des périphériques Bluetooth
        var devices = client.DiscoverDevices();

        if (devices.Length > 0)
        {
            foreach (var device in devices)
            {
                if (device.DeviceAddress.ToString() == "1CB3C9F12B2D")
                {
                    airpod = device;
                }
            }
            Console.WriteLine($"Connexion au périphérique : {airpod.DeviceName}, Adresse : {airpod.DeviceAddress}");

            while (connected != 0 && connected < try_number + 1)
            {
                try
                {
                    client.Connect(airpod.DeviceAddress, BluetoothService.Handsfree);
                    connected = 0;

                }
                catch (Exception ex)
                {
                    connected++;
                    Console.WriteLine(ex.ToString());
                    Thread.Sleep(delay_between_try * 1000);
                }
            }
        }
        else
        {
            Console.WriteLine("Aucun périphérique Bluetooth trouvé.");
        }
    }
}
