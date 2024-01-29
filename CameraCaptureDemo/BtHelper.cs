using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCaptureDemo
{
    public class BtHelper
    {

        private List<String> btDevices;

        private bool hasBt;

        

        public BtHelper()
        {
            btDevices = new List<String>();
            CheckForBt();

        }

        public bool HasBt { get => this.hasBt; }

        void CheckForBt()
        {
            try
            {
                BluetoothClient client = new BluetoothClient();
                hasBt = true;

                var devices = client.DiscoverDevices();

                foreach (var device in devices)
                {
                    this.btDevices.Add(device.DeviceName);
                }
            }
            catch (PlatformNotSupportedException exc)
            {
                //  Console.WriteLine(exc.Message);
                hasBt = false;

            }

        }
        public List<String> getBtNames() { return this.btDevices; }

    }
}
