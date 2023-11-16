using AForge.Video;
using System;

using AForge.Video.DirectShow;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System.ComponentModel;
using System.Management;
using System.Security.Policy;
using System.Windows.Forms;

using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using InTheHand.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CameraCaptureDemo
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filterInfo;
        VideoCaptureDevice videoDevice;

        BackgroundWorker backgroundWorker;

        private string micLvl = "";
        private bool audioOn = false;
        private bool camOn = false;
        private WaveInEvent waveIn;
        private bool hasBt;

        private int mouseTestIdx = 0;

        private int curr_x;
        private int curr_y;

        private bool[] mouse_test = new bool[4] { false, false, false, false };

        private string[] mouseTestLabels = new string[]
        {
            "Move mouse up out of this region",
            "Move mouse down out of this region",
            "Move mouse left out of this region",
            "Move mouse right out of this region"
        };

        private List<String> btNames = new List<String>();
        public Form1()
        {
            InitializeComponent();
            filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);



            waveIn = new NAudio.Wave.WaveInEvent
            {
                DeviceNumber = 0, // customize this to select your microphone device
                WaveFormat = new NAudio.Wave.WaveFormat(rate: 44100, bits: 16, channels: 2),
                BufferMilliseconds = 50
            };
            waveIn.DataAvailable += ShowPeakMono;
            waveIn.StartRecording();
            audioOn = true;




            // add ui update worker stuff
            //  backgroundWorker = new BackgroundWorker();
            //    backgroundWorker.DoWork += UpdateMicLvl;
        }



        private void button1_Click(object sender, EventArgs e)
        {   // create the video
            if (filterInfo.Count > 0)
            {
                videoDevice = new VideoCaptureDevice(filterInfo[0].MonikerString);
                videoDevice.NewFrame += VideoCapture_NewFrame;
                videoDevice.Start();
                camOn = true;
            }


        }

        private bool BatteryChargeOk()
        {
            //  using System.Management;

            PowerStatus pwr = SystemInformation.PowerStatus;
            String strBatterylife;

            if (pwr.BatteryLifePercent >= .80)
            {
                MessageBox.Show("Battery over 80%");
                return true;
            }
            else
            {
                strBatterylife = pwr.BatteryLifePercent.ToString();
                MessageBox.Show("Battery life: " + strBatterylife);
                return false;
            }

        }



        private void VideoCapture_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbx1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"sample-6s.wav");
            player.Play();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            CheckForDvdDrive();
        }



        private string GetBars(double fraction, int barCount = 35)
        {
            int barsOn = (int)(barCount * fraction);
            int barsOff = barCount - barsOn;
            return new string('#', barsOn) + new string('-', barsOff);
        }
        private void ShowPeakMono(object? sender, NAudio.Wave.WaveInEventArgs args)
        {
            float maxValue = 32767;
            int peakValue = 0;
            int bytesPerSample = 2;
            for (int index = 0; index < args.BytesRecorded; index += bytesPerSample)
            {
                int value = BitConverter.ToInt16(args.Buffer, index);
                peakValue = Math.Max(peakValue, value);
            }
            if (audioOn)
            {
                lblMicLevel.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    lblMicLevel.Text = GetBars(peakValue / maxValue);
                });
            }

        }
        // stop the microphone and worker thread
        private void StopRecording(object sender, FormClosingEventArgs e)
        {
            if (audioOn)
            {
                audioOn = false;
                waveIn.DataAvailable -= ShowPeakMono;
                waveIn.StopRecording();
            }
            if (camOn)
            {
                videoDevice.SignalToStop();
                videoDevice.NewFrame -= VideoCapture_NewFrame;
                //  videoDevice.Stop();
                camOn = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BatteryChargeOk();
        }

        private void CheckForDvdDrive()
        {
            ManagementScope rootScope = new ManagementScope("\\root\\cimv2");
            rootScope.Connect();

            ObjectQuery query = new ObjectQuery("Select * from Win32_CDROMDrive");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(rootScope, query);


            var cd_drives = searcher.Get();

            if (cd_drives.Count > 0)
            {
                // MessageBox.Show("DVD Drive detected.  Please insert disk and check in windows explorer");

                foreach (var drive in DriveInfo.GetDrives()
                               .Where(d => d.DriveType == DriveType.CDRom))
                {
                    if(!drive.IsReady)
                    {
                        MessageBox.Show($"Please insert a DVD into {drive.Name} and try again.");
                    }
                    else
                    {
                        MessageBox.Show($"{drive.Name} is ready");
                    }
                }
                   
            }
            else
            {
                MessageBox.Show("NO DVD DRIVE");
            }



        }

        private void CheckForBt()
        {
            try
            {
                BluetoothClient client = new BluetoothClient();
                hasBt = true;
            }
            catch (PlatformNotSupportedException exc)
            {
                Console.WriteLine(exc.Message);
                hasBt = false;
                this.lblBtDevices.Text = exc.Message;
            }

        }



        private void ListBtDevices()
        {
            // enumerate
            // Query for extra properties you want returned
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

            DeviceWatcher deviceWatcher =
                        DeviceInformation.CreateWatcher(
                                BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                requestedProperties,
                                DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            // Added, Updated and Removed are required to get all nearby devices

            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            // EnumerationCompleted and Stopped are optional to implement.
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start the watcher.
            deviceWatcher.Start();

            //    Console.ReadLine();

        }

        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
            //    throw new NotImplementedException();
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            lblBtDevices.Text += "\nFinished looking for devices";
        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            //   throw new NotImplementedException();
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            //   throw new NotImplementedException();
        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {

            if (args.Name.Length > 0)
            {
                btNames.Add(args.Name);
                this.lblBtDevices.Text += $"\n{args.Name}";
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            CheckForBt();
            if (hasBt)
            {
                ListBtDevices();
            }
            // Console.ReadLine();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //   MessageBox.Show("Mouse left");
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            curr_x = e.Location.X;
            curr_y = e.Location.Y;

            lblCursorX.Text = curr_x.ToString();
            lblCursorY.Text = curr_y.ToString();

            // test
            if (curr_y <= 5)
                mouse_test[0] = true;
            if (curr_y >= 160)
                mouse_test[1] = true;
            if (curr_x <= 5)
                mouse_test[2] = true;
            if (curr_x >= 240)
                mouse_test[3] = true;


        }

        private void lblMouseTest_MouseEnter(object sender, EventArgs e)
        {
            curr_x = this.Cursor.HotSpot.X;
            curr_y = this.Cursor.HotSpot.Y;


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }*/
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}