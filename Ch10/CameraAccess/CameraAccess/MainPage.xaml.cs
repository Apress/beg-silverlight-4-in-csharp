using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CameraAccess
{
    public partial class MainPage : UserControl
    {
        CaptureSource source;

        public MainPage()
        {
            InitializeComponent();
        }

        private void StartCapture(object sender, RoutedEventArgs e)
        {
            if (source != null)
            {
                source.Stop();
            }

            source = new CaptureSource();
            source.VideoCaptureDevice = 
                CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();
            source.AudioCaptureDevice = 
                CaptureDeviceConfiguration.GetDefaultAudioCaptureDevice();

            VideoBrush video = new VideoBrush();
            video.SetSource(source);
            CaptureDisplay.Fill = video;

            if (CaptureDeviceConfiguration.AllowedDeviceAccess || 
                CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                source.Start();
            }
        }

        private void StopCapture(object sender, RoutedEventArgs e)
        {
            if (source != null)
            {
                source.Stop();
            }
        }
    }
}
