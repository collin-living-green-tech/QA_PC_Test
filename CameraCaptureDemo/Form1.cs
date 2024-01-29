using AForge.Video;
using System;

using AForge.Video.DirectShow;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System.ComponentModel;
using System.Management;
using System.Security.Policy;
using System.Windows.Forms;

using InTheHand.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;

namespace CameraCaptureDemo
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filterInfo;
        VideoCaptureDevice? videoDevice;



        private bool audioOn = false;
        private bool camOn = false;
        private WaveInEvent? waveIn;





        private int curr_x;
        private int curr_y;

        private bool[] mouse_test = new bool[4] { false, false, false, false };

        private delegate void AsyncInitAudion();


        private List<String> btNames = new List<String>();
        public Form1()
        {
            InitializeComponent();
            filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);




            // start audio
            // StartMicLevel();
            // start cam



            try
            {
                waveIn = new NAudio.Wave.WaveInEvent
                {
                    DeviceNumber = 0, // customize this to select your microphone device
                    WaveFormat = new NAudio.Wave.WaveFormat(rate: 44100, bits: 16, channels: 2),
                    BufferMilliseconds = 50
                };
                waveIn.DataAvailable += ShowPeakMono;
                waveIn.StartRecording();
                audioOn = true;

                new Task(CheckForBt).Start();
                new Task(StartCam).Start();

                // check bluetooth


                // battery
                new Task(BatteryChargeOk).Start();

                // dvd
                new Task(CheckForDvdDrive).Start();

                // activatation
                new Task(IsWindowsActivated).Start();
                // add ui update worker stuff

                new Task(CheckForTouchscreen).Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void StartMicLevel()
        {
            waveIn = new NAudio.Wave.WaveInEvent
            {
                DeviceNumber = 0, // customize this to select your microphone device
                WaveFormat = new NAudio.Wave.WaveFormat(rate: 44100, bits: 16, channels: 2),
                BufferMilliseconds = 50
            };
            waveIn.DataAvailable += ShowPeakMono;
            waveIn.StartRecording();
            audioOn = true;

        }

        private void StartCam()
        {
            // create the video
            if (filterInfo.Count > 0)
            {
                videoDevice = new VideoCaptureDevice(filterInfo[0].MonikerString);
                videoDevice.NewFrame += VideoCapture_NewFrame;
                videoDevice.Start();
                camOn = true;
            }
        }



        private void BatteryChargeOk()
        {
            //  using System.Management;

            PowerStatus pwr = SystemInformation.PowerStatus;


            string battStatus = "Not Over 80%";
            if (pwr.BatteryLifePercent >= .80)
            {
                battStatus = "Over 80%";


            }

            lblBattery.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                lblBattery.Text = battStatus;
            });

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
            string lvlString = new string('#', barsOn) + new string('-', barsOff);
            int maxLength = lvlString.Length > 20 ? 20 : lvlString.Length;

            string lvlStr2 = lvlString.Substring(0, maxLength);

            return lvlStr2;
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

        private void CheckForTouchscreen()
        {
            ManagementScope rootScope = new ManagementScope("\\root\\cimv2");
            rootScope.Connect();

            ObjectQuery query = new ObjectQuery("Select * from Win32_PnpSignedDriver Where DeviceName = \"HID-compliant touch screen\"");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(rootScope, query);


            var ts = searcher.Get();
            var touchResult = "No driver found.";
            if (ts.Count > 0)
            {
                touchResult = "PLEASE TEST TOUCHSCREEN";

            }

            lblTouchVal.Invoke((MethodInvoker)delegate
            {
                lblTouchVal.Text = touchResult;
            });




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
                    if (!drive.IsReady)
                    {
                        lblDvd.Invoke((MethodInvoker)delegate
                        {
                            // MessageBox.Show("Please insert DVD to test drive and rerun this app.");

                            lblDvd.Text = $"Insert DVD INTO {drive.Name}";
                        });

                    }
                    else
                    {
                        lblDvd.Invoke((MethodInvoker)delegate
                        {
                            lblDvd.Text = $"{drive.Name} is ready";
                        });

                    }
                }

            }
            else
            {
                lblDvd.Invoke((MethodInvoker)delegate { lblDvd.Text += "NO DVD DRIVE"; });
            }



        }

        private void CheckForBt()
        {
            BtHelper btHelper = new BtHelper();
            int devCount = 0;
            if (btHelper.HasBt)
            {

                var devices = btHelper.getBtNames();

                devCount = devices.Count;

                foreach (var device in devices)
                {
                    lblBtDevices.Invoke((MethodInvoker)delegate
                    {

                        lblBtDevices.Text += $"\n{device}";
                    });

                }
            }
            else
            {
                lblBtDevices.Invoke((MethodInvoker)delegate
                {

                    lblBtDevices.Text += "\nNo bluetooth protocol stack found.";
                });

            }

            // show devices count
            lblBtCount.Invoke((MethodInvoker)delegate
            {
                lblBtCount.Text = devCount.ToString();
            });

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




        }

        private void lblMouseTest_MouseEnter(object sender, EventArgs e)
        {
            curr_x = this.Cursor.HotSpot.X;
            curr_y = this.Cursor.HotSpot.Y;


        }



        public void IsWindowsActivated()
        {
            ManagementScope scope = new ManagementScope("\\root\\cimv2");
            scope.Connect();

            SelectQuery searchQuery = new SelectQuery("SELECT * FROM SoftwareLicensingProduct WHERE ApplicationID = '55c92734-d682-4d71-983e-d6ec3f16059f' and LicenseStatus = 1");
            ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);
            string isActivated = "false";
            using (ManagementObjectCollection obj = searcherObj.Get())
            {
                if (obj.Count > 0)
                    isActivated = "true";
            }

            lblActivation.Invoke((MethodInvoker)delegate { lblActivation.Text = isActivated; });
        }
    }
}